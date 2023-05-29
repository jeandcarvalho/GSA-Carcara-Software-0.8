using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class Csv : IInsertCsv, ICsvVerification
    {
        ICarCollection car = new GetCollections();
        public void InsertCsv(FileInfo file)
        {
            var Measurements = car.CarCollection();
            string[] csvLines = System.IO.File.ReadAllLines(file.FullName);
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');
                float angle = float.Parse(data[10], CultureInfo.InvariantCulture.NumberFormat);
                string curve = "Straight line";
                if (angle < -20) { curve = "Right turn"; }  //needs to be improved
                if (angle > 20) { curve = "Left turn"; }
                Measurements.InsertOne(new Vehicle
                {
                    VideoName = file.Name.Substring(0, 28),
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
        public bool CsvVerification(string fileName)
        {
            var Measurements = car.CarCollection();
            var query =
                       from e in Measurements.AsQueryable<Vehicle>()
                       where e.VideoName == fileName.Substring(0, 28)
                       select e.VideoName;
            if (!query.Any())
            {
                return true;
            }
            return false;
        }
    }
}
