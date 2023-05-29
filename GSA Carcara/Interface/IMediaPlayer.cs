using AxWMPLib;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace GSA_Carcara.Interface
{
    interface IMPInitialSettings
    {
        void InitSettings(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, 
                          AxWindowsMediaPlayer axWindowsMediaPlayer3, AxWindowsMediaPlayer axWindowsMediaPlayer4, 
                          AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IMediaPlayerSet
    {
        void SetVideos(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                       AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6,
                       List<Vehicle> CarFiltred, System.Windows.Forms.ListView listView1);
    }
    interface ISetURLVideos
    {
        void SetURLVideos(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                          AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6, string videoName);
    }
    interface IMediaPlayerButtons
    {
        void PlayMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
        void PauseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                    AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
        void LessMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                  AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
        void MoreMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                   AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
        void ForwMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                  AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
        void BackMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                                   AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface ICloseMP
    {
        void CloseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                     AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IPlayMP
    {
        void PlayMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IDefinePositionSec
    {
        void DefinePositionSec(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                             AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6, double secIni);
    }
    interface IPauseVideos
    {
        void PauseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface ILessSecondsToVideos
    {
        void LessSecondsMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IMoreSecondsToVideos
    {
        void MoreSecondsMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IForwardVideos
    {
        void ForwardMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
    interface IBackwardVideos
    {
        void BackwardMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6);
    }
}
