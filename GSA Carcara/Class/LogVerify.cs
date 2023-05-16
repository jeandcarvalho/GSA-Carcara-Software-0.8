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
    public class LogVerify : ILogVerification
    {
        public bool LogVerification(string fileName)
        {
            var Ratings = new GetCollections().RatingCollection();
            var query =
                                from e in Ratings.AsQueryable<Rating>()
                                where e.LogName == fileName
                                select e.LogName;
            if(!query.Any())
            {
                return true;
            }
            return false;
        }
    }
}
