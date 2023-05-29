using AxWMPLib;
using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class MediaPlayerSettings : IMPInitialSettings,  ISetURLVideos
    {
        public void InitSettings(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2,
                                 AxWindowsMediaPlayer axWindowsMediaPlayer3, AxWindowsMediaPlayer axWindowsMediaPlayer4,
                                 AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlenabled = false; axWindowsMediaPlayer1.uiMode = "None";
            axWindowsMediaPlayer3.Ctlenabled = false; axWindowsMediaPlayer2.uiMode = "None";
            axWindowsMediaPlayer4.Ctlenabled = false; axWindowsMediaPlayer3.uiMode = "None";
            axWindowsMediaPlayer6.Ctlenabled = false; axWindowsMediaPlayer4.uiMode = "None";
            axWindowsMediaPlayer5.Ctlenabled = false; axWindowsMediaPlayer6.uiMode = "None";
            axWindowsMediaPlayer2.Ctlenabled = false; axWindowsMediaPlayer5.uiMode = "None";
        }

        public void SetURLVideos(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                             AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6, string videoName)
        {
            string DBfolder = new DirectoryDB().GetFolderDB();
            string[] dirs = Directory.GetDirectories(DBfolder);
            foreach (string dir in dirs)
            {
                DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);                                          //percorre pastas para achar videos exatos
                foreach (FileInfo file in DBdirectoryInfo.GetFiles())
                {
                    if (file.Extension.Contains("avi") && file.Name == videoName + ".avi") { axWindowsMediaPlayer1.URL = file.FullName; }
                    if (file.Extension.Contains("avi") && file.Name == videoName + "_m1.avi") { axWindowsMediaPlayer2.URL = file.FullName; }
                    if (file.Extension.Contains("avi") && file.Name == videoName + "_m0.avi") { axWindowsMediaPlayer3.URL = file.FullName; }
                    if (file.Extension.Contains("avi") && file.Name == videoName + "_m2.avi") { axWindowsMediaPlayer4.URL = file.FullName; }
                    if (file.Extension.Contains("avi") && file.Name == videoName + "_m4.avi") { axWindowsMediaPlayer5.URL = file.FullName; }
                    if (file.Extension.Contains("avi") && file.Name == videoName + "_m3.avi") { axWindowsMediaPlayer6.URL = file.FullName; }
                }
            }
        }
    }
}
