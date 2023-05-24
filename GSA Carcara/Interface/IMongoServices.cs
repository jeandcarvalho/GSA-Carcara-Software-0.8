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

    interface IGetCoordinates
    {
        IQueryable<float> GetCoordinates();
        List<float> ListCoordinates(IQueryable<float> gpsX);
    }
}
