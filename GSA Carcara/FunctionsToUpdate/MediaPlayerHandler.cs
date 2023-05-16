using AxWMPLib;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class MediaPlayerHandler
    {
        public void SetVideos(AxWindowsMediaPlayer axWindowsMediaPlayer1, AxWindowsMediaPlayer axWindowsMediaPlayer2, AxWindowsMediaPlayer axWindowsMediaPlayer3,
                              AxWindowsMediaPlayer axWindowsMediaPlayer4, AxWindowsMediaPlayer axWindowsMediaPlayer5, AxWindowsMediaPlayer axWindowsMediaPlayer6,
                              List<Vehicle> CarFiltred, List<Rating> RatingFiltred, System.Windows.Forms.ListView listView1)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                DateTime moment = new DateTimeTools().ItemToDateTime(item.Text.ToString());         //get Datetime from moment doubleclicked in listview
                string videoName = new VideosFileName().FindVideoFileByMoment(CarFiltred, moment);    // get videos file name from the moment DateTime
                DateTime begin = new DateTimeTools().VideoNameToDateTime(videoName);                    // get start moment Datetime of videos

                new MediaPlayerControls().CloseMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,      //if videos are already playing, "close" players
                                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);

                new MediaPlayerSettings().SetURLVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                                       axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6, videoName);

                double secIni = new DateTimeTools().VideosStartSeconds(moment, begin);                                   

                new MediaPlayerControls().DefinePositionSec(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3, axWindowsMediaPlayer4,     //define videos start position to moment doublecliked
                                                            axWindowsMediaPlayer5, axWindowsMediaPlayer6, secIni);

                new MediaPlayerControls().PlayMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,             //start 6 videos player sync
                                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
            }
        }
    }
}
