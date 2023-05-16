using AxWMPLib;
using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class MediaPlayerConfig : IInitialSettings
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
    }
}
