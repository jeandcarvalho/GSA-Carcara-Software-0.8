using GSA_Carcara.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Classes
{
    public class FiltersFunctions
    {
       public List<Vehicle> CarFilter(IMongoCollection<Vehicle> Measurements, string[] Filters)
        {   
            List<Vehicle> list = new List<Vehicle>();
            if (Filters[0] == string.Empty) { Filters[0] = "0"; }
            if (Filters[1] == string.Empty) { Filters[1] = "220"; }
            float SpeedMin = float.Parse(Filters[0], CultureInfo.InvariantCulture.NumberFormat);
            float SpeedMax = float.Parse(Filters[1], CultureInfo.InvariantCulture.NumberFormat);
            IQueryable<Vehicle> query;
            query =
                        from e in Measurements.AsQueryable<Vehicle>()
                        where e.VehicleSpeed >= SpeedMin && e.VehicleSpeed <= SpeedMax && e.Curves.Contains(Filters[2])
                        select e;

            foreach (var data in query) { list.Add(data); }
            return list;
        }
        public List<Rating> RatingFilter(IMongoCollection<Rating> Ratings, string[] Filters)
        {
            List<Rating> list = new List<Rating>();
            IQueryable<Rating> query;
            query =
                        from e in Ratings.AsQueryable<Rating>()
                        where e.RoadConditions.Contains(Filters[0]) && e.Traffic.Contains(Filters[1]) && 
                              e.RoadNumbers.Contains(Filters[2]) && e.RoadType.Contains(Filters[3]) && 
                              e.DayPeriod.Contains(Filters[4]) && e.Weather.Contains(Filters[5]) && 
                              e.Visibility.Contains(Filters[6]) && e.Driver.Contains(Filters[7])
                        select e;

            foreach (var data in query)  {  list.Add(data);   }
            return list;
        }
        public void IntersectFilters(List<Vehicle> CarFiltred, List<Rating> RatingFiltred)
        {
            List<DateTime> Car = new List<DateTime>();
            List<DateTime> Rating = new List<DateTime>();
            foreach (var data in CarFiltred)     { Car.Add(data.TimeStemp); }
            foreach (var data in RatingFiltred)   { Rating.Add(data.TimeStemp); }
            var Intersect = Car.Intersect(Rating).ToList();
            foreach (var time in CarFiltred.ToList())   { if (!Intersect.Contains(time.TimeStemp)) { CarFiltred.Remove(time) ;}  }
            foreach (var time in RatingFiltred.ToList())   { if (!Intersect.Contains(time.TimeStemp)) { RatingFiltred.Remove(time);  }
            }
        }
    }
}
