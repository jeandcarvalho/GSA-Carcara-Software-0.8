using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IInitialSettings
    {
        void InitSettings(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, 
                          AxWindowsMediaPlayer axWindowsMediaPlayer3, AxWindowsMediaPlayer axWindowsMediaPlayer4, 
                          AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
}
