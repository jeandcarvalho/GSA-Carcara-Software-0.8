using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;

namespace GSA_Carcara.Classes
{
    public class FilesVerification
    {
        public IQueryable<string> CsvVerification(IMongoCollection<Vehicle> Measurements, string fileName)
        {
            var query =
                        from e in Measurements.AsQueryable<Vehicle>()
                        where e.VideoName == fileName.Substring(0, 28)
                        select e.VideoName;
            return query;
        }

        public IQueryable<string> LogVerification(IMongoCollection<Rating> Ratings, string fileName)
        {
            var query =
                                from e in Ratings.AsQueryable<Rating>()
                                where e.LogName == fileName
                                select e.LogName;
            return query;
        }

        public void SaveDBdir(string DBfolder)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(DBfolder);
            }
        }  
        
        public string GetDBfodler()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\dbInfo\\dbInfo.txt".ToString();
            using (StreamReader reader = new StreamReader(path))
            {
                string oi = reader.ReadLine();
                return oi;
            }
        }
    }
}
