using GSA_Carcara.Classes;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSA_Carcara;
using System.Windows.Forms;
using GSA_Carcara.Class;
using GSA_Carcara.Interface;

namespace GSA_Carcara
{
    public class ExtractFiles : IExtractFiles
    {
        IGetDBdirectory getDB = new DirectoryDB();
        public List<string> GetVideosToExtract(List<Vehicle> CarFiltred)
        {
            List<string> VideoFiles = new List<string>();
            VideoFiles.Clear();
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
            } return VideoFiles;
        }
        public void ExtractVideos(string VideoFile, string outputFolder)
        {
            string DBinfo = getDB.GetFolderDB();
            string[] dirs = Directory.GetDirectories(DBinfo);
            foreach (string dir in dirs)
            {
                DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);
                foreach (FileInfo file in DBdirectoryInfo.GetFiles())
                {
                    if (file.Name == VideoFile + ".avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                    if (file.Name == VideoFile + "_m0.avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                    if (file.Name == VideoFile + "_m1.avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                    if (file.Name == VideoFile + "_m2.avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                    if (file.Name == VideoFile + "_m3.avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                    if (file.Name == VideoFile + "_m4.avi") { FileInfo fi = new FileInfo(file.FullName); fi.CopyTo(outputFolder + "\\" + file.Name, true); }
                }
            }
        }
        public void ExtractCsv(List<Vehicle> CarFiltred, List<Rating> RatingFiltred, string outputFolder)                          
        {
            using (FileStream fs = File.Create(outputFolder + "\\Data extracted.csv")) { }
            using (StreamWriter writer = new StreamWriter(outputFolder + "\\Data extracted.csv"))
            {
                writer.WriteLine("TimeStemp|Vehicle Speed|Wheel Angle|Gps X|Gps Y|Gps Z|Day Period|Weather|Visibility|Traffic|RoadConditions|Road Type|Road Numbers|Driver");
                for (int i = 0; i < CarFiltred.Count; i++)
                {
                    writer.WriteLine(CarFiltred[i].TimeStemp + "|" + CarFiltred[i].VehicleSpeed + "|" + CarFiltred[i].WheelAngle + "|" +
                                     CarFiltred[i].Gps_X + "|" + CarFiltred[i].Gps_Y + "|" + CarFiltred[i].Gps_Z + "|" + RatingFiltred[i].DayPeriod.ToString() + "|" +
                                     RatingFiltred[i].Weather.ToString() + "|" + RatingFiltred[i].Visibility.ToString() + "|" + RatingFiltred[i].Traffic.ToString() + "|" + RatingFiltred[i].RoadConditions.ToString() + "|" +
                                     RatingFiltred[i].RoadType.ToString() + "|" + RatingFiltred[i].RoadNumbers.ToString() + "|" + RatingFiltred[i].Driver.ToString());
                }
            }
        }  
    }
}
