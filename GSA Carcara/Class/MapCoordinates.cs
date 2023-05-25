using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class MapCoordinates : IGetCoordinates
    {
        ICarCollection car = new GetCollections();
        List<float> gpsX = new List<float>();
        List<float> gpsY = new List<float>();
        public IQueryable<float> GetCoordinatesX()
        {
            var Measurements = car.CarCollection();
            var queryX = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_X;
            return queryX;
        }
        public IQueryable<float> GetCoordinatesY()
        {
            var Measurements = car.CarCollection();
            var queryY = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_Y;
            return queryY;
        }
        public List<float> ListCoordinatesX(IQueryable<float> queryX)
        {
            if (queryX.Any())
            {
                foreach (var coordinate in queryX)
                {
                    gpsX.Add(coordinate); 
                }
            }
            return gpsX;
        }
        public List<float> ListCoordinatesY(IQueryable<float> queryY)
        {
            if (queryY.Any())
            { foreach (var coordinate in queryY) { gpsY.Add(coordinate); } }
            return gpsY;
        }
    }

  
    
}
