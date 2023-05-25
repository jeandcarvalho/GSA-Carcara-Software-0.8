﻿using GSA_Carcara.Class;
using GSA_Carcara.Interface;
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
        ICarCollection car = new GetCollections();
        IRatingCollection rating = new GetCollections();
        IGetDateTimeCollections datetimes = new TimeStempCollections();
        IDateTimeIntersect intersect = new TimeStempIntersect();
        public void DateTimeCheck()
        {
            var Measurements = car.CarCollection();
            var Ratings = rating.RatingCollection();
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
