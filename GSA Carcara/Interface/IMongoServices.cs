using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface ICarCollection
    {
        IMongoCollection<Vehicle> CarCollection();
    }

    interface IRatingCollection
    {
        IMongoCollection<Rating> RatingCollection();
    }

    interface IGetCoordinatesX
    {
        IQueryable<float> GetCoordinatesX();
    }
    interface QueryGpsXToList : IGetCoordinatesX
    { 
       List<float> ListCoordinatesX(IQueryable<float> gpsX);
    }

    interface IGetCoordinatesY
    {
        IQueryable<float> GetCoordinatesY();
    }
    interface QueryGpsYToList : IGetCoordinatesX
    {
        List<float> ListCoordinatesY(IQueryable<float> gpsY);
    }
}
