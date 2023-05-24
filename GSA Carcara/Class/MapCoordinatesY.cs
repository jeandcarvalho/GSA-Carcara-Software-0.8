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
    public class MapCoordinatesY : IGetCoordinates
    {
        public IQueryable<float> GetCoordinates()
        {
            var collections = new GetCollections();
            var Measurements = collections.CarCollection();
            var queryY = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_Y;
            return queryY;
        }
        public List<float> ListCoordinates(IQueryable<float> queryY)
        {
            List<float> gpsY = new List<float>();
            if (queryY.Any())
            { foreach (var coordinate in queryY) { gpsY.Add(coordinate); } }
            return gpsY;
        }
    }
}
