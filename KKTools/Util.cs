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
            for(int i = 0; i <= listResult.Count; i++)
            {
                try
                {
                    downloadSound(listResult[i].SoundUrl, listResult[i].SoundPath);
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    
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
            ret = System.IO.Directory.GetCurrentDirectory() + "\\Sound\\" + serviceTTS.Name + "\\" +
                        voiceName + generateNumberFileName(totalExisted + 1) + "." + FormatSoundFile;
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
    }
}