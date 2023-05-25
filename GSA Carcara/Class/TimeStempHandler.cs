using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class TimeStempHandler : ITimesStempHandler
    {
        IGetDateTimeCollections datetimes = new TimeStempCollections();
        IDateTimeIntersect intersect = new TimeStempIntersect();
        public void DeleteDateTimes()
        {
            var CarTimes = datetimes.CarDateTime();
            var RatingTimes = datetimes.RatingDateTime();
            CarTimes = datetimes.CleanDuplicates(CarTimes);
            if (CarTimes.Count != RatingTimes.Count)
            {
                intersect.CarTimeToDelete(CarTimes, RatingTimes);
                intersect.RatTimeToDelete(CarTimes, RatingTimes);
            }
        }
    }
}
