using DnsClient.Protocol;
using GSA_Carcara.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GSA_Carcara.Classes
{
    public class FilesFunctions
    {
        public string auxLog;

        public void CsvHandler(string dir, IMongoCollection<Vehicle> Measurements)
        {
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);                        //csv handler
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {
                var filter = Builders<Vehicle>.Filter.Eq("VideoName", file.Name);
                var results =  Measurements.Find(filter).CountDocuments();

                if (file.Extension.Contains(".csv") && results==0)
                {
                    string[] csvLines = System.IO.File.ReadAllLines(file.FullName);
                    for (int i = 1; i < csvLines.Length; i++)
                    {
                        string[] data = csvLines[i].Split(',');

                        string curve = "Straight line";
                        float angle = float.Parse(data[10], CultureInfo.InvariantCulture.NumberFormat);
                        if(angle < -20)
                        {
                            curve = "Right turn";
                        }
                        if (angle > 20)
                        {
                            curve = "Left turn";
                        }
                        Measurements.InsertOne(new Vehicle 
                        {
                            VideoName = file.Name,
                            TimeStemp = Convert.ToDateTime(data[0].Substring(0, 19)),
                            Gps_Y = float.Parse(data[7], CultureInfo.InvariantCulture.NumberFormat),
                            Gps_X = float.Parse(data[8], CultureInfo.InvariantCulture.NumberFormat),
                            Gps_Z = float.Parse(data[9], CultureInfo.InvariantCulture.NumberFormat),
                            VehicleSpeed = float.Parse(data[11], CultureInfo.InvariantCulture.NumberFormat),
                            WheelAngle = float.Parse(data[10], CultureInfo.InvariantCulture.NumberFormat),
                        Curves = curve
                        });                       
                    }
                }
            }
        }

        public void LogHandler(string dir, IMongoCollection<Rating> Ratings)
        {
            DirectoryInfo DBdirectoryInfo = new DirectoryInfo(dir);                        //log handler
            foreach (FileInfo file in DBdirectoryInfo.GetFiles())
            {      
                if (file.Extension.Contains(".log"))
                {
                    string[] logLines = System.IO.File.ReadAllLines(file.FullName);
                    for (int i = 1; i < logLines.Length; i++)
                    {
                        string[] data = logLines[i].Split(',');
                        var filter = Builders<Rating>.Filter.Eq("TimeStemp", Convert.ToDateTime(data[0]));
                        var results = Ratings.Find(filter).ToList();
                        if (results.Count != 0) { break; }
                        Ratings.InsertOne(new Rating
                        {
                            TimeStemp = Convert.ToDateTime(data[0]),
                            RoadType = data[2],
                            RoadConditions = data[4],
                            Visibility = data[7],
                            RoadNumbers = data[6],
                            Traffic = data[8],
                            DayPeriod = data[9],
                            Weather = data[3],
                            Driver = data[5]
                        });
                    }
                }
            }
        }
    }
}
