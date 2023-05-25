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
    public class CsvVerify : ICsvVerification
    {
        ICarCollection car = new GetCollections();
        public bool CsvVerification(string fileName)
        {
            var Measurements = car.CarCollection();
            var query =
                       from e in Measurements.AsQueryable<Vehicle>()
                       where e.VideoName == fileName.Substring(0, 28)
                       select e.VideoName;
            if (!query.Any())
            {
                return true;
            }
            return false;
        }
    }
}
