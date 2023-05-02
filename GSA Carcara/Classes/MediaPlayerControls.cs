using AxWMPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSA_Carcara.Classes
{
    public class MediaPlayerControls
    {
        public void CloseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.close();
            axWindowsMediaPlayer2.close();
            axWindowsMediaPlayer3.close();
            axWindowsMediaPlayer4.close();
            axWindowsMediaPlayer5.close();
            axWindowsMediaPlayer6.close();
        }

        public void PlayMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            axWindowsMediaPlayer2.Ctlcontrols.play();
            axWindowsMediaPlayer3.Ctlcontrols.play();
            axWindowsMediaPlayer4.Ctlcontrols.play();
            axWindowsMediaPlayer5.Ctlcontrols.play();
            axWindowsMediaPlayer6.Ctlcontrols.play();
            Thread.Sleep(1500);
        }

        public void DefinePositionSec(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6, double secIni)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = secIni;
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition = secIni;
            axWindowsMediaPlayer3.Ctlcontrols.currentPosition = secIni;
            axWindowsMediaPlayer4.Ctlcontrols.currentPosition = secIni;
            axWindowsMediaPlayer5.Ctlcontrols.currentPosition = secIni;
            axWindowsMediaPlayer6.Ctlcontrols.currentPosition = secIni;
        }

        public void InitSettings(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                 AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlenabled = false;
            axWindowsMediaPlayer3.Ctlenabled = false;
            axWindowsMediaPlayer4.Ctlenabled = false;
            axWindowsMediaPlayer6.Ctlenabled = false;
            axWindowsMediaPlayer5.Ctlenabled = false;
            axWindowsMediaPlayer2.Ctlenabled = false;
            axWindowsMediaPlayer1.uiMode = "None";
            axWindowsMediaPlayer2.uiMode = "None";
            axWindowsMediaPlayer3.uiMode = "None";
            axWindowsMediaPlayer4.uiMode = "None";
            axWindowsMediaPlayer6.uiMode = "None";
            axWindowsMediaPlayer5.uiMode = "None";
        }
    }
}
