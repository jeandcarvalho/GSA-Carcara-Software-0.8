using AxWMPLib;
using GSA_Carcara.Interface;
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
    public class MediaPlayerHandler : IClickedVideos
    {
        public string FindClickedVideos(List<Vehicle> CarFiltred, DateTime moment)
        {
            string videoName = null;
            foreach (var data in CarFiltred)
            {
                if (data.TimeStemp == moment)                       // get video name from the moment clicked
                {
                    videoName = data.VideoName; break;
                }
            }
            return videoName;
        }
        public DateTime VideoStartDateTime(string videoName)
        {
            string InicioNoDir = videoName.Substring(9, 19);
            string year = InicioNoDir.Substring(0, 4);
            string month = InicioNoDir.Substring(5, 2);
            string day = InicioNoDir.Substring(8, 2);
            string hour = InicioNoDir.Substring(11, 2);
            string min = InicioNoDir.Substring(14, 2);
            string sec = InicioNoDir.Substring(17, 2);
            string videoIni = day + "/" + month + "/" + year + " " + hour + ":" + min + ":" + sec;              //get datetime from video start
            DateTime begin = Convert.ToDateTime(videoIni);
            return begin;
        }
        public double DefinePosition(DateTime moment, DateTime begin)
        {
            TimeSpan VideoIni = moment - begin;
            double secIni = VideoIni.TotalSeconds;
            return secIni;
        }  
    }
}
