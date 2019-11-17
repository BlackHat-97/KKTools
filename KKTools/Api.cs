using KKTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace KKTools
{
   public  class Api
    {
       
        public bool requestFPTAPI(string input,int streamID, string voiceName = "banmai", string speed = "normal", bool allowDownloadSound=true)
        {
            KKToolsDbContext _context = new KKToolsDbContext();
            var serviceTTS = _context.ServiceTTSs.FirstOrDefault(x => x.Name.ToLower() == "FPT".ToLower());
            bool isSuccess = true;
            using (var client = new HttpClient())
            {
                var result = sendFPTRequest(client, input, _context,voiceName,streamID);                                    
                //Kiểm tra response có dữ liêu hay không
                if (result.IsSuccessStatusCode)
                {
                    // isSuccess thì  Reponse có thể có hoặc KHÔNG có link download file sound
                    //{
                    //    "async": "https://s3-ap-southeast-1.amazonaws.com/text2speech-v4/male.0.pro.4b5b15285847e83acbb3beb945434453.mp3",
                    //    "error": 0,
                    //    "message": "The content will be returned after a few seconds under the async link.",
                    //    "request_id": "4b5b15285847e83acbb3beb945434453"
                    //}
                    //{
                    //    "error": 1,
                    //    "message": "Internal server error happened",
                    //}

                    var addedResponse = receiveResponseFPT(result, _context);
                    /* Tạo đường dẫn cho local Sound path
                     * Nếu chưa tải sẽ đánh dấu Downloaded=false và Soundpath=""
                     */
                    var util = new Util();
                    string pathToFPTSound = "";
                    bool isDownloaded = false;
                    if (allowDownloadSound == true && addedResponse.error=="0")
                    {
                        if(addedResponse.async!=null || addedResponse.async != "")
                        {
                            pathToFPTSound = util.getPathToSound(serviceTTS, voiceName);
                            isDownloaded = util.downloadSound(addedResponse.async, pathToFPTSound);
                        }                                      
                    }
                    int requestHaveBeenAdded = _context.Requests.OrderByDescending(x => x.ID).FirstOrDefault().ID;
                    //Lưu bảng Result - Dữ liệu thống kê response
                    var newResult = new Result()
                    {
                        ResponseID = addedResponse.ID,
                        CreatedDate = DateTime.Now,
                        DateGetWav = DateTime.Now,
                        RequestID = requestHaveBeenAdded,
                        SoundUrl = addedResponse.async,
                        SoundPath= pathToFPTSound,
                        Text= input,
                        Downloaded = isDownloaded,
                        ServiceTTSID =serviceTTS.ID ,
                        StreamID=streamID  
                    };
                    _context.Results.Add(newResult);
                    _context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Lỗi: Gửi yêu cầu tới server không thành công! Hãy kiểm tra kết nối mạng.");
                    isSuccess = false;
                }
            }
            return isSuccess;
        }
        HttpResponseMessage sendFPTRequest(HttpClient client,string input, KKToolsDbContext _context, string voiceName, int streamID)
        {
            HttpResponseMessage result = new HttpResponseMessage();

            client.BaseAddress = new Uri("https://api.fpt.ai/hmi/tts/v5");
            //HTTP GET

            StringContent content = new StringContent(input);
            client.DefaultRequestHeaders.Add("api_key", "dRZ17MlcRYKI5Uz4yL1NJYzIt1k5NgGw");
            client.DefaultRequestHeaders.Add("voice", voiceName);
            //Lấy thông tin của request
            string contentRequest = "Content:" + input+";"+ client.BaseAddress.ToString() + ";" +
                                                 client.DefaultRequestHeaders.ToString() ;
            try
            {
                var responseTask = client.PostAsync("", content);
                responseTask.Wait();
                 result = responseTask.Result;
            }
            catch 
            {
                result.StatusCode = HttpStatusCode.BadRequest;
            }
            //Lưu bảng Request
            var newRequest = new Request()
            {
                Content = contentRequest,
                CreatedDate = DateTime.Now,
                Status = result.IsSuccessStatusCode,
                StreamID = streamID
            };
            _context.Requests.Add(newRequest);
            _context.SaveChanges();
            return result;
        }
        Response receiveResponseFPT(HttpResponseMessage result, KKToolsDbContext _context)
        {
            //ĐỌc dữ liệu response
            var readTask = result.Content.ReadAsStringAsync();
            readTask.Wait();
            var ret = readTask.Result;
            //Chuyển dữ liệu json vào Object
            var js = new JavaScriptSerializer();
            Response newResponse = js.Deserialize<Response>(ret);
            //Lưu bảng Response - từ ServiceTTS response
            _context.Responses.Add(newResponse);
            _context.SaveChanges();
            var addedResponse = _context.Responses.OrderByDescending(x => x.ID).FirstOrDefault();
            return addedResponse;
        }
     
    }
}
