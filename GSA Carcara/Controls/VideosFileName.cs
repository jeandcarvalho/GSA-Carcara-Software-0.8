using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                if (data.TimeStemp == moment)                       // get video name from the moment clicked
                {
                    videoName = data.VideoName; break;
                }
            }
            return videoName;
        }

        public List<string> FindVideoToExtract(List<Vehicle> CarFiltred)
        {
            List<string> VideoFiles = new List<string>();
            foreach (var file in CarFiltred)
            {
                if (!VideoFiles.Any())
                {
                    VideoFiles.Add(file.VideoName);             //find the name of videos to extract
                }
                if (!VideoFiles.Contains(file.VideoName))
                {
                    VideoFiles.Add(file.VideoName);
                }
            }
            return VideoFiles;
        }

   
    }
}
