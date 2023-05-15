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
    public class MapCoordinates : QueryGpsXToList, QueryGpsYToList
    {
        public IQueryable<float> GetCoordinatesX()
        {
            var collections = new GetCollections();
            var Measurements = collections.CarCollection();
            var queryX = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_X;
            return queryX;
        }
        public List<float> ListCoordinatesX(IQueryable<float> queryX)
        {
            List<float> gpsX = new List<float>();
            if (queryX.Any())
            {foreach (var coordinate in queryX) { gpsX.Add(coordinate); }}
            return gpsX;
        }
        public IQueryable<float> GetCoordinatesY()
        {
            var collections = new GetCollections();
            var Measurements = collections.CarCollection();
            var queryY = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_Y;
            return queryY;
        }
        public List<float> ListCoordinatesY(IQueryable<float> queryY)
        {
            List<float> gpsY = new List<float>();
            if (queryY.Any())
            {foreach (var coordinate in queryY) { gpsY.Add(coordinate); }}
            return gpsY;
        }
    }
}
