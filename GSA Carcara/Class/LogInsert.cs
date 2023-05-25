using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class LogInsert : IInsertLog
    {
        IRatingCollection rating = new GetCollections();
        public void Insert(FileInfo file)
        {
            var Ratings = rating.RatingCollection();
            string[] logLines = System.IO.File.ReadAllLines(file.FullName);
            for (int i = 1; i < logLines.Length; i++)
            {
                string[] data = logLines[i].Split(',');
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
                    Driver = data[5],
                    LogName = file.Name
                });
            }
        }
    }
}
