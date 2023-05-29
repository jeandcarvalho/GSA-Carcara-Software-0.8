using AxWMPLib;
using GSA_Carcara.Classes;
using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class MediaPlayerButtons : IMediaPlayerButtons
    {
        IPlayMP playMP = new MediaPlayerControls();
        IPauseVideos pauseMP = new MediaPlayerControls();
        ILessSecondsToVideos lessMP = new MediaPlayerControls();
        IMoreSecondsToVideos moreMP = new MediaPlayerControls();
        IForwardVideos forwMP = new MediaPlayerControls();
        IBackwardVideos backMP = new MediaPlayerControls();
        public void PlayMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            playMP.PlayMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                          axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        public void PauseMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                            AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            pauseMP.PauseMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                            axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        public void LessMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            lessMP.LessSecondsMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                            axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        public void MoreMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            moreMP.MoreSecondsMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        public void ForwMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            forwMP.ForwardMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                            axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        public void BackMP(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                           AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6)
        {
            backMP.BackwardMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                              axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
    }
}
