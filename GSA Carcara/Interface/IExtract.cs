using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IExtract
    {
        void ExtractToFolder(List<Vehicle> CarFiltred, List<Rating> RatingFiltred);
    }
    interface IExtractFiles
    {
        List<string> GetVideosToExtract(List<Vehicle> CarFiltred);
        void ExtractVideos(string VideoFile, string outputFolder);
        void ExtractCsv(List<Vehicle> CarFiltred, List<Rating> RatingFiltred, string outputFolder);
    }
}
