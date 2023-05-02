using GSA_Carcara.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Classes
{
    public class SyncCollections
    {
        public List<DateTime> CarDateTime(IMongoCollection<Vehicle> Measurements)
        {
            List<DateTime> listCar = new List<DateTime>();

            var query =
            from e in Measurements.AsQueryable<Vehicle>()
            where e.TimeStemp !=null
            select e.TimeStemp;            

            foreach (var time in query)
            {
               listCar.Add(time);
            }

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

        public List<DateTime> RatingDateTime(IMongoCollection<Rating> Ratings)
        {
            List<DateTime> listRat = new List<DateTime>();
            var query =
                        from e in Ratings.AsQueryable<Rating>()
                        where e.TimeStemp != null
                        select e.TimeStemp;

            foreach (var time in query)
            {
                listRat.Add(time);
            }
            return listRat;
        }

        public void CarTimeToDelete(List<DateTime> listCar, List<DateTime> listRat, IMongoCollection<Vehicle> Measurements)
        {

            List<DateTime> timesDiff = listCar.Except(listRat).ToList(); 
            foreach (var time in timesDiff)
            {
                var filter = Builders<Vehicle>.Filter.Eq("TimeStemp", time);
                Measurements.DeleteMany(filter);
            }
        }

        public void RatTimeToDelete(List<DateTime> listCar, List<DateTime> listRat, IMongoCollection<Rating> Ratings)
        {
            List<DateTime> timesDiff = listRat.Except(listCar).ToList();
            foreach (var time in timesDiff)
            {
                var filter = Builders<Rating>.Filter.Eq("TimeStemp", time);
                Ratings.DeleteMany(filter);
            }
        }

        public void DateTimeCheck(IMongoCollection<Vehicle> Measurements, IMongoCollection<Rating> Ratings)
        {
            var filter = Builders<Vehicle>.Filter.Empty;
            var filter2 = Builders<Rating>.Filter.Empty;

            var cursor = Measurements.Find(filter);
            var cursor2 = Ratings.Find(filter2);

            if (cursor.CountDocuments() != cursor2.CountDocuments())
            {
                var CarTimes = new SyncCollections().CarDateTime(Measurements);
                var RatTimes = new SyncCollections().RatingDateTime(Ratings);
                new SyncCollections().CarTimeToDelete(CarTimes, RatTimes, Measurements);
                new SyncCollections().RatTimeToDelete(CarTimes, RatTimes, Ratings);
            }
        }
    }
}
