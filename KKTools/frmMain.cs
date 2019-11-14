
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
        public frmMain()
        {
            InitializeComponent();
            LoadDefaultSelection();
            setDefaultAllCombobox();
            
            //Tạo các folder tương ứng với các ServiceTTS Name
            util.CreateSoundDirectory(listServiceTTS);
            //timerCheckInternet.Start();
            util.informStatusConnectionToInternet(lblConnection);
           
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
            //Xử lý input
            string input = txtInput.Text;
            string[] parts = input.Split('.');
            Api api = new Api();
            foreach (var item in parts)
            {
                if(item.Length> chunkSize)
                {
                    // Nếu một sentence quá dài (lớn hơn chunkSize = 80 ký tự). Phân tách thành từng đoạn chunkSize để request
                    for (int i = 0; i < item.Length; i += chunkSize)
                    {
                        if (i + chunkSize > item.Length) chunkSize = item.Length - i;
                        string text = item.Substring(i, chunkSize);
                        //  bool isSuccess = api.requestFPTAPI(input, voiceName, "", allowDownloadSound);
                    }
                }
              //  bool isSuccess = api.requestFPTAPI(input, voiceName, "", allowDownloadSound);
            }
            
            
           // MessageBox.Show("Tạo giọng nói thành công!");
        }

        private void timerCheckInternet_Tick(object sender, EventArgs e)
        {
           
            util.informStatusConnectionToInternet(lblConnection);
        }

        private void wmpMain_Enter(object sender, EventArgs e)
        {

           var listResult = util._context.Results.Where(x => x.Downloaded == true).ToList();
            wmpMain.URL = listResult[listResult.Count - 1].SoundPath;
        }

    



        //==================================================================================
        //Don't delete these two following 
    }
}