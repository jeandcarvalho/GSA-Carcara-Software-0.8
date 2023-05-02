using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara
{
    public class MongoServices
    {
        public IMongoCollection<Vehicle> CarCollection()
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Aquisitions"); // conect to database
            var Measurements = database.GetCollection<Vehicle>("Measurements");
            return Measurements;
        }

        public IMongoCollection<Rating> RatingCollection()
        {
            IMongoClient client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Aquisitions"); // conect to database
            var Ratings = database.GetCollection<Rating>("Ratings");
            return Ratings;
        }
    }  
}
