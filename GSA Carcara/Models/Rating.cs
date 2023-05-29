using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Models
{
    public class Rating
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local), BsonElement("TimeStemp")]
        public DateTime TimeStemp { get; set; }

        [BsonElement("RoadConditions")]
        public string RoadConditions { get; set; }

        [BsonElement("RoadNumbers")]  //definir como cord no db mongo
        public string RoadNumbers { get; set; }

        [BsonElement("RoadType")]
        public string RoadType { get; set; }

        [BsonElement("Visibility")]
        public string Visibility { get; set; }

        [BsonElement("Traffic")]
        public string Traffic { get; set; }

        [BsonElement("DayPeriod")]
        public string DayPeriod { get; set; }

        [BsonElement("Weather")]
        public string Weather { get; set; }

        [BsonElement("Driver")]
        public string Driver { get; set; }

        [BsonElement("logName")]
        public string LogName { get; set; }
    }
}
