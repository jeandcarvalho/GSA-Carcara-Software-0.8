using AxWMPLib;
using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSA_Carcara.Classes
{
    public class MediaPlayerControls : ICloseMP, IPlayMP, IDefinePositionSec, IPauseVideos, ILessSecondsToVideos, IMoreSecondsToVideos, IForwardVideos, IBackwardVideos
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
        public void PauseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            axWindowsMediaPlayer2.Ctlcontrols.pause();
            axWindowsMediaPlayer3.Ctlcontrols.pause();
            axWindowsMediaPlayer4.Ctlcontrols.pause();
            axWindowsMediaPlayer5.Ctlcontrols.pause();
            axWindowsMediaPlayer6.Ctlcontrols.pause();
        }
        public void LessSecondsMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                  AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition -= 5;
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition -= 5;
            axWindowsMediaPlayer3.Ctlcontrols.currentPosition -= 5;
            axWindowsMediaPlayer4.Ctlcontrols.currentPosition -= 5;
            axWindowsMediaPlayer5.Ctlcontrols.currentPosition -= 5;
            axWindowsMediaPlayer6.Ctlcontrols.currentPosition -= 5;
        }
        public void MoreSecondsMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                  AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition += 5;
            axWindowsMediaPlayer2.Ctlcontrols.currentPosition += 5;
            axWindowsMediaPlayer3.Ctlcontrols.currentPosition += 5;
            axWindowsMediaPlayer4.Ctlcontrols.currentPosition += 5;
            axWindowsMediaPlayer5.Ctlcontrols.currentPosition += 5;
            axWindowsMediaPlayer6.Ctlcontrols.currentPosition += 5;
        }
        public void ForwardMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastForward();
            axWindowsMediaPlayer2.Ctlcontrols.fastForward();
            axWindowsMediaPlayer3.Ctlcontrols.fastForward();
            axWindowsMediaPlayer4.Ctlcontrols.fastForward();
            axWindowsMediaPlayer5.Ctlcontrols.fastForward();
            axWindowsMediaPlayer6.Ctlcontrols.fastForward();
        }
        public void BackwardMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                               AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            axWindowsMediaPlayer1.Ctlcontrols.fastReverse();
            axWindowsMediaPlayer2.Ctlcontrols.fastReverse();
            axWindowsMediaPlayer3.Ctlcontrols.fastReverse();
            axWindowsMediaPlayer4.Ctlcontrols.fastReverse();
            axWindowsMediaPlayer5.Ctlcontrols.fastReverse();
            axWindowsMediaPlayer6.Ctlcontrols.fastReverse();
        }
    }
}
