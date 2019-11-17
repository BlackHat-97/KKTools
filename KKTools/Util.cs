using KKTools.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;
using System.Linq;
namespace KKTools
{
    public class Util
    {
        public KKToolsDbContext _context = new KKToolsDbContext();
        public void CreateSoundDirectory(List<ServiceTTS> listServiceTTS)
        {
            /*Tạo các folder tương ứng với các ServiceTTS Name
             * Ví dụ:
             * Folder Sound
             * ---- Folder Google
             * ---- Folder FPT
            */
            string dirSoundPath = System.IO.Directory.GetCurrentDirectory() + "\\Sound";
            CreateWavDirectoryIfNotExisted(dirSoundPath);
         
            for(int i = 0; i < listServiceTTS.Count; i++)
            {
                string dir = dirSoundPath + "\\"+ listServiceTTS[i].Name;
                CreateWavDirectoryIfNotExisted(dir);
            }
            
        }

        public void CreateWavDirectoryIfNotExisted(string path)
        {
            try
            {
                bool exists = System.IO.Directory.Exists(path);
                if (!exists)
                    System.IO.Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return;
            }
        }
        public bool getNotDownloadedSound()
        {
            bool isSuccess = true;
           
            var listResult = _context.Results.Where(x=>x.Downloaded!=true).ToList();
            //Kiểm tra kết nối mạng

            //Nếu có mạng thì tiếp tục tải các file sound chưa download
            for(int i = 0; i < listResult.Count; i++)
            {
                try
                {
                    int id = listResult[i].ServiceTTSID;
                    var serviceTTS = _context.ServiceTTSs.FirstOrDefault(x => x.ID == id);
                    string soundPath = System.IO.Directory.GetCurrentDirectory() + "\\" + getPathToSound(serviceTTS,"banmai");
                    downloadSound(listResult[i].SoundUrl, soundPath);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message.ToString());
                    
                }
            }
            return isSuccess;
        }
        public bool downloadSound(string url, string Path)
        {
            try
            {
                WebClient webclient = new WebClient();
                webclient.DownloadFile(url, Path);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        public string getPathToSound(ServiceTTS serviceTTS, string voiceName)
        {
            string ret = "";
            int totalExisted = _context.Results.Where(x => x.ServiceTTSID == serviceTTS.ID && x.Downloaded==true).Count();
            string FormatSoundFile = serviceTTS.FormatSoundFile;
            if (FormatSoundFile == null || FormatSoundFile == "") FormatSoundFile = "wav";
            ret = "Sound\\" + serviceTTS.Name + "\\" +
                        voiceName + generateNumberFileName(totalExisted + 1) + "." + FormatSoundFile;
            //ret = System.IO.Directory.GetCurrentDirectory() + "\\Sound\\" + serviceTTS.Name + "\\" +
            //            voiceName + generateNumberFileName(totalExisted + 1) + "." + FormatSoundFile;
            return ret;
        }
        public string generateNumberFileName(int num)
        {
            string ret = "";
            int length = 6;
            ret = num.ToString().PadLeft(length, '0');
            if (ret == "") ret = DateTime.Now.ToLongTimeString();
            return ret;
        }
        bool IsConnectedToInternet()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("id.fpt.ai");
                return true;
            }
            catch 
            {
                return false;
            }
            
        }
        public void informStatusConnectionToInternet(Label lblConnection)
        {
            if (IsConnectedToInternet())
            {
                lblConnection.Text = "Đang có kết nối mạng!";
                lblConnection.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblConnection.Text = "Không có kết nối mạng!";
                lblConnection.ForeColor = System.Drawing.Color.Red;
            }
        }
        /// <summary>
        /// Tách đoạn văn thành các đoạn văn nhỏ hơn cho mỗi lần request
        /// </summary>
        /// <param name="input"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public List<string> getStringRequests(string input, int chunkSize)
        {
            List<string> stringRequests = new List<string>();
            string[] Sentences = input.Split('.');
            foreach (var sentence in Sentences)
            {
                if (sentence == "" || sentence == null) continue;
                else
                {
                    if (sentence.Length > chunkSize)
                    {
                        // Nếu một sentence quá dài (lớn hơn chunkSize = 80 ký tự). Phân tách thành từng đoạn chunkSize để request
                        for (int i = 0; i < sentence.Length; i += chunkSize)
                        {
                            if (i + chunkSize > sentence.Length) chunkSize = sentence.Length - i;
                            string text = sentence.Substring(i, chunkSize);
                            stringRequests.Add(text);
                            //bool isSuccess = api.requestFPTAPI(input, voiceName, "", allowDownloadSound);
                        }
                    }
                    else
                    {
                        stringRequests.Add(sentence);
                        //bool issSuccess = api.requestFPTAPI(input, voiceName, "", allowDownloadSound);
                    }

                }

            }
            return stringRequests;
        }
        /// <summary>
        /// Hàm tạo lại giọng nói
        /// </summary>
        /// <param name="streamID"></param>
        /// <param name="chunkSize"></param>
        /// <param name="voiceName"></param>
        /// <param name="allowDownloadSound"></param>
        /// <returns></returns>
        public bool reCreate(int streamID, int chunkSize, string voiceName, bool allowDownloadSound)
        {
            try
            {
                var api = new Api();
                var stream = _context.Streams.Where(x => x.ID == streamID).FirstOrDefault();
                string input = stream.Content;
                int totalDone = stream.DoneSentence;
                List<string> stringRequests = getStringRequests(input, chunkSize);
                for(int i = totalDone; i < stream.TotalSentence; i++)
                {
                    bool isSuccess = api.requestFPTAPI(stringRequests[i], stream.ID, voiceName, "", allowDownloadSound);
                    if (isSuccess) stream.DoneSentence++;
                }
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}