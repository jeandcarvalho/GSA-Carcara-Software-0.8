using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSA_Carcara.Class;
using GSA_Carcara.Classes;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;

namespace GSA_Carcara.Controls
{
    public class Extract : IExtract
    {
        IDirectorySelect getDir = new GetDirectory();
        IExtractFiles extractFiles= new ExtractFiles();
        public void ExtractToFolder(List<Vehicle> CarFiltred, List<Rating> RatingFiltred)                                                                                                            //extract(copy videos to output folder)
        {     
            List<string> VideoFiles = extractFiles.GetVideosToExtract(CarFiltred);
            string outputFolder = getDir.SelectDirectory();
            if (outputFolder != null)
            {                                                                                                                                                                                        //finds videos to copy(in list filtred.VideoName)    
                foreach (var VideoFile in VideoFiles)                                                                                                                                                //for every video to copy do this:
                {
                    extractFiles.ExtractVideos(VideoFile, outputFolder);
                }
                extractFiles.ExtractCsv(CarFiltred, RatingFiltred, outputFolder);                                                                                                               //extract csv to same folder
            }
        }
    }
}
