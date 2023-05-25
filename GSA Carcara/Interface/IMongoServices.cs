using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Interface
{
    interface IUpdateMongo
    {
        void UpdateMongo(Label DatabaseStatus);
    }
    interface ICarCollection
    {
        IMongoCollection<Vehicle> CarCollection();
    }

    interface IRatingCollection
    {
        IMongoCollection<Rating> RatingCollection();
    }

    interface IGetCoordinates
    {
        IQueryable<float> GetCoordinatesX();       
        IQueryable<float> GetCoordinatesY();
        List<float> ListCoordinatesX(IQueryable<float> gpsX);
        List<float> ListCoordinatesY(IQueryable<float> gpsX);
    }

    interface IGetDateTimeCollections
    {
        List<DateTime> CarDateTime();
        List<DateTime> RatingDateTime();
        List<DateTime> CleanDuplicates(List<DateTime> listCar);    
    }

    interface IDateTimeIntersect
    {
        void CarTimeToDelete(List<DateTime> listCar, List<DateTime> listRat);
        void RatTimeToDelete(List<DateTime> listCar, List<DateTime> listRat);
    }

    interface ITimesStempHandler
    {
        void DeleteDateTimes();
    }

    interface IFilter
    {
        List<Vehicle> CarFilter(string[] Filters);
        List<Rating> RatingFilter(string[] Filters);
        void IntersectFilters(List<Vehicle> CarFiltred, List<Rating> RatingFiltred);
    }
}
