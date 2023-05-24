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

namespace GSA_Carcara
{
    public class Extract
    {
        public void ExtractFiles(List<Vehicle> CarFiltred, List<Rating> RatingFiltred)                                     //extract(copy videos to output folder)
        {
            string outputFolder = new Directory_Handler().Directory_Finder();               
            if (outputFolder != null)            
            {
                var VideoFiles = new VideosFileName().FindVideoToExtract(CarFiltred);                                    //finds videos to copy(in list filtred.VideoName)
                string DBinfo = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
                string[] DBfolder = File.ReadAllLines(DBinfo);
                foreach (var VideoFile in VideoFiles)                                                                   //for every video to copy do this:
                {
                    string[] dirs = Directory.GetDirectories(DBfolder[0]);
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
                
                new Extract().ExtractCsv(CarFiltred, RatingFiltred, outputFolder);                        //extract csv to same folder
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
