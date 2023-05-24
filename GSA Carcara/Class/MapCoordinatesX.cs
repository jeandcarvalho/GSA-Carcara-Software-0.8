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
    public class MapCoordinatesX : IGetCoordinates
    {
        public IQueryable<float> GetCoordinates()
        {
            var collections = new GetCollections();
            var Measurements = collections.CarCollection();
            var queryX = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_X;
            return queryX;
        }
        public List<float> ListCoordinates(IQueryable<float> queryX)
        {
            List<float> gpsX = new List<float>();
            if (queryX.Any())
            {foreach (var coordinate in queryX) { gpsX.Add(coordinate); }}
            return gpsX;
        }
    }

  
    
}
