using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Classes
{
    public class DateTimeTools
    {
        public DateTime ItemToDateTime(string DateTime)
        {
            DateTime moment = Convert.ToDateTime(DateTime);
            return moment;
        }

        public DateTime VideoNameToDateTime(string videoName)
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

        public double VideosStartSeconds(DateTime moment, DateTime begin) 
        {
            TimeSpan VideoIni = moment - begin;
            double secIni = VideoIni.TotalSeconds;
            return secIni;
        }
    }
}
