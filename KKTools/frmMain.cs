
using KKTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace KKTools
{
    public partial class frmMain : Form
    {
        private static List<ServiceTTS> listServiceTTS = new List<ServiceTTS>();
        Util util = new Util();
        //Số ký tự tối đa cho một request.
        int chunkSize = 80;
        int streamIDHistory;
        public frmMain()
        {
            InitializeComponent();
            LoadDefaultSelection();
            setDefaultAllCombobox();
            //loadHistoryRequst
            loadHistoryRequest();
            //Tạo các folder tương ứng với các ServiceTTS Name
            util.CreateSoundDirectory(listServiceTTS);
            //timerCheckInternet.Start();
            util.informStatusConnectionToInternet(lblConnection);
            util.getNotDownloadedSound();
        }

        private void LoadDefaultSelection()
        {
            KKToolsDbContext _context = new KKToolsDbContext();
            listServiceTTS = _context.ServiceTTSs.ToList();
            for (int i = 0; i < listServiceTTS.Count; i++)
            {
                //Viết vào cbox Service
                cboxService.Items.Add(listServiceTTS[i].Name);
                //Lấy dữ liệu tập ServiceSupported cho từng ServiceTTS
                int id = listServiceTTS[i].ID;
                listServiceTTS[i].ServiceSupporteds = (IEnumerable<ServiceSupported>)_context.ServiceSupporteds.Where(x => x.ServiceTTSID ==id ).ToList();
            }
        }

        private void setDefaultAllCombobox()
        {
            setDefaultOneCombobox(cboxService);
            setDefaultOneCombobox(cboxVoice);
            setDefaultOneCombobox(cboxSpeed);
        }

        private void setDefaultOneCombobox(ComboBox cbox)
        {
            if (cbox.Items.Count > 0)
            {
                cbox.SelectedIndex = 0;
            }
        }

        private void ClearSubCbox()
        {
            cboxSpeed.Items.Clear();
            cboxVoice.Items.Clear();
        }

        private void cboxService_SelectedIndexChanged(object sender, EventArgs e)
        {
            string serviceTTS_Selected = cboxService.SelectedItem.ToString();
            FillServiceSupportedCbox(serviceTTS_Selected);
            setDefaultOneCombobox(cboxSpeed);
            setDefaultOneCombobox(cboxVoice);
        }

        private void FillServiceSupportedCbox(string serviceName)
        {
           
            int i = listServiceTTS.FindIndex(x => x.Name == serviceName);
            List<ServiceSupported> listServiceSupported = new List<ServiceSupported>();
            //Không có dữ liệu cho dịch vụ tương ứng --> Return
            if (listServiceTTS[i].ServiceSupporteds == null) return;
            ClearSubCbox();
            listServiceSupported = listServiceTTS[i].ServiceSupporteds.ToList();
            for (int j = 0; j < listServiceSupported.Count; j++)
            {
                char SymbolSeparate = ',';
                if (listServiceSupported[j].SeparateSymbol!=null)
                    SymbolSeparate = listServiceSupported[j].SeparateSymbol[0];
                string[] parts = listServiceSupported[j].Selections.Split(SymbolSeparate);
                //Nếu hỗ trợ Voice thì thêm vào cboxVoice
                if (listServiceSupported[j].Name.ToLower() == "Voice".ToLower())
                {
                    foreach (string item in parts)
                    {
                        cboxVoice.Items.Add(item);
                    }
                }
                //Nếu hỗ trợ Speed thì thêm vào cboxSpeed
                if (listServiceSupported[j].Name.ToLower() == "Speed".ToLower())
                {
                    foreach (string item in parts)
                    {
                        cboxSpeed.Items.Add(item);
                    }
                }
            }
        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
            bool allowDownloadSound = checkBoxDownloadSound.Checked;
            string voiceName = cboxVoice.SelectedItem.ToString();
            string speed = cboxSpeed.SelectedItem.ToString();
            var streamOld = util._context.Streams.OrderByDescending(x => x.ID).FirstOrDefault();
            if (txtInput.Text != streamOld.Content || streamOld.voiceName != voiceName || streamOld.speed != speed)
            {
                //Xử lý input
                string input = txtInput.Text;
                List<string> stringRequests = util.getStringRequests(input, chunkSize);
                if (stringRequests.Count < 1)
                {
                    MessageBox.Show("Phai nhap vao input");
                    return;
                }
                int totalRequest = stringRequests.Count;
                int totalDone = 0;
                var newStream = new Stream()
                {
                    Content = input,
                    DoneSentence = totalDone,
                    TotalSentence = totalRequest,
                    CreatedDate = DateTime.Now,
                    voiceName = voiceName,
                    speed = speed
                };
                util._context.Streams.Add(newStream);
                util._context.SaveChanges();
                var stream = util._context.Streams.OrderByDescending(x => x.ID).FirstOrDefault();
                int lastStreamID = stream.ID;
                var api = new Api();
                for (int i = 0; i < totalRequest; i++)
                {
                    bool isSuccess = api.requestFPTAPI(stringRequests[i], lastStreamID, voiceName, "", allowDownloadSound);
                    if (isSuccess) totalDone++;
                    else
                    {
                        MessageBox.Show("Request is Faild");
                        break;
                    }
                }
                if (totalDone > 0)
                {
                    stream.DoneSentence = totalDone;
                    util._context.SaveChanges();
                }

                MessageBox.Show("Tạo giọng nói thành công!");
                speakListPlayMedia(stream);
            }
            else
            {
                var util = new Util();
                util.reCreate(streamOld.ID, chunkSize, voiceName, allowDownloadSound);
                speakListPlayMedia(streamOld);
            }

        }

        private void timerCheckInternet_Tick(object sender, EventArgs e)
        {
           
            util.informStatusConnectionToInternet(lblConnection);
        }

        private void wmpMain_Enter(object sender, EventArgs e)
        {

           var listResult = util._context.Results.Where(x => x.Downloaded == true).ToList();
            wmpMain.URL = System.IO.Directory.GetCurrentDirectory() + "\\" + listResult[listResult.Count - 1].SoundPath;
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if(txtInput.Text!= null)
            {
                btnSpeak.Text = "Tạo giọng nói";
                btnSpeak.Visible = false;
            }
        }
        public void loadHistoryRequest()
        {
            KKToolsDbContext _context = new KKToolsDbContext();
            var historyRequsts = _context.Streams.ToList();
            dgvHistoryQuery.DataSource = historyRequsts;
        }
        public void speakListPlayMedia(Stream str)
        {
            var newestStream = str.ID;
            var listMusicOfStream = util._context.Results.OrderBy(x => x.ID).Where(x => x.StreamID == newestStream).ToList();
            WMPLib.IWMPPlaylist pl;
            pl = wmpMain.playlistCollection.newPlaylist("Stream");
            bool flag = true;
            foreach (var result in listMusicOfStream)
            {
                WMPLib.IWMPMedia m1 = wmpMain.newMedia(System.IO.Directory.GetCurrentDirectory() + "\\" + result.SoundPath);
                pl.appendItem(m1);
                wmpMain.currentPlaylist = pl;
                if (flag == true)
                {
                    wmpMain.Ctlcontrols.play();
                    flag = false;
                }
            }
            wmpMain.currentPlaylist = pl;
        }

        private void dgvHistoryQuery_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            streamIDHistory = Convert.ToInt32(dgvHistoryQuery.Rows[numrow].Cells[0].Value.ToString());
        }

        private void btnRepeat_Click(object sender, EventArgs e)
        {
            var stream = util._context.Streams.Where(x => x.ID == streamIDHistory).FirstOrDefault();
            speakListPlayMedia(stream);
        }

        //==================================================================================
        //Don't delete these two following 
    }
}