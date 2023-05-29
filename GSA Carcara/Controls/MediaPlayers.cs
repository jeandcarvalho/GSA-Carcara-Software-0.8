using AxWMPLib;
using GSA_Carcara.Class;
using GSA_Carcara.Classes;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Controls
{
    public class MediaPlayers : IMediaPlayerSet
    {
        IClickedVideos videoInfo = new MediaPlayerHandler();
        ICloseMP closeMP = new MediaPlayerControls();
        IDefinePositionSec define = new MediaPlayerControls();
        IPlayMP playMP = new MediaPlayerControls();
        ISetURLVideos url = new MediaPlayerSettings();
        public void SetVideos(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6,
                              List<Vehicle> CarFiltred, System.Windows.Forms.ListView listView1)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                DateTime moment = Convert.ToDateTime(item.Text.ToString());                                       //get Datetime from moment doubleclicked in listview
                string videoName = videoInfo.FindClickedVideos(CarFiltred, moment);                                  // get videos file name from the moment DateTime
                DateTime begin = videoInfo.VideoStartDateTime(videoName);                                                  // get start moment Datetime of videos
                double secIni = videoInfo.DefinePosition(moment, begin);

                closeMP.CloseMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,                                    //if videos are already playing, "close" players
                                axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
                url.SetURLVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6, videoName);
                define.DefinePositionSec(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3, axWindowsMediaPlayer4,          //define videos start position to moment doublecliked
                                         axWindowsMediaPlayer5, axWindowsMediaPlayer6, secIni);
                playMP.PlayMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,                                              //start 6 videos player sync
                              axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
            }
        }
    }
}
