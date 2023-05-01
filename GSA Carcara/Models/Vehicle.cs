using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Models
{
    public class Vehicle
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("VideoName")]
        public string VideoName { get; set; }   

        [BsonDateTimeOptions(Kind = DateTimeKind.Local), BsonElement("TimeStemp")]
        public DateTime TimeStemp { get; set; }

        [BsonElement("Gps_Y")]  //definir como cord no db mongo
        public float Gps_Y { get; set; }

        [BsonElement(" Gps_X")]
        public float Gps_X { get; set; }

        [BsonElement("Gps_Z")]
        public float Gps_Z { get; set; }

        [BsonElement("WheelAngle")]
        public float WheelAngle { get; set; }

        [BsonElement("VehicleSpeed")]
        public float VehicleSpeed { get; set; }

        [BsonElement("Curves")]
        public string Curves { get; set; }
    }
}
