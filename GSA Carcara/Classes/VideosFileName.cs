using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Classes
{
    public class VideosFileName
    {
        public string FindVideoFileByMoment(List<Vehicle> CarFiltred, DateTime moment) 
        {
            string videoName = null;
            foreach (var data in CarFiltred)
            {
                if (data.TimeStemp == moment)                       // get video name from the moment 
                {
                    videoName = data.VideoName; break;
                }
            }
            return videoName;
        }
    }
}
