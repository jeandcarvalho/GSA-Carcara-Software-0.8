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
    public class TimeStempCollections : IGetDateTimeCollections
    {
        ICarCollection car = new GetCollections();
        IRatingCollection rating = new GetCollections();
        List<DateTime> listCar = new List<DateTime>();
        List<DateTime> listRat = new List<DateTime>();
        
        public List<DateTime> CarDateTime()
        {
            listCar.Clear();
            var Measurements = car.CarCollection();           
            var query = from e in Measurements.AsQueryable<Vehicle>() where e.TimeStemp != null select e.TimeStemp;
            foreach (var time in query) { listCar.Add(time); }  
            return listCar;
        }
        public List<DateTime> RatingDateTime()
        {
            listRat.Clear();
            var Ratings = rating.RatingCollection();
            var query = from e in Ratings.AsQueryable<Rating>() where e.TimeStemp != null select e.TimeStemp;
            foreach (var time in query) { listRat.Add(time); }
            return listRat;
        }
        public List<DateTime> CleanDuplicates(List<DateTime> listCar)
        {
            var Measurements = car.CarCollection();
            List<DateTime> duplicates = listCar.GroupBy(x => x)
                                       .Where(g => g.Count() > 1)
                                       .Select(x => x.Key).ToList();
            foreach (var time in duplicates)
            {
                var filter = Builders<Vehicle>.Filter.Eq("TimeStemp", time);
                Measurements.DeleteOne(filter);
            }
            return listCar;
        } 
    }
}
