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
    public class TimeStempIntersect : IDateTimeIntersect
    {
        ICarCollection car = new GetCollections();
        IRatingCollection rating = new GetCollections(); 
        public void CarTimeToDelete(List<DateTime> listCar, List<DateTime> listRat)
        {
            var Measurements = car.CarCollection();
            List<DateTime> timesDiff = listCar.Except(listRat).ToList();
            foreach (var time in timesDiff)
            {
                var filter = Builders<Vehicle>.Filter.Eq("TimeStemp", time); Measurements.DeleteMany(filter);
            }
        }
        public void RatTimeToDelete(List<DateTime> listCar, List<DateTime> listRat)
        {
            var Ratings = rating.RatingCollection();
            List<DateTime> timesDiff = listRat.Except(listCar).ToList();
            foreach (var time in timesDiff)
            {
                var filter = Builders<Rating>.Filter.Eq("TimeStemp", time); Ratings.DeleteMany(filter);
            }
        }   
    }
}
