﻿using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class CsvInsert : IInsertCsv
    {
   
        public void Insert(FileInfo file)
        {
            var Measurements = new GetCollections().CarCollection();
            string[] csvLines = System.IO.File.ReadAllLines(file.FullName);
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] data = csvLines[i].Split(',');  
                float angle = float.Parse(data[10], CultureInfo.InvariantCulture.NumberFormat);
                string curve = "Straight line";
                if (angle < -20) { curve = "Right turn"; }
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

    }
}
