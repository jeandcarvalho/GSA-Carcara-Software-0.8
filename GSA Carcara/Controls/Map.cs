using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GSA_Carcara.Class;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class Map : IMap
    {
        IGetCoordinates mapSet = new MapCoordinates();
        IShowMarkers mapMarkers = new MapHandler();
        public void SetStarterMap( GMapControl map)
        {
            map.MapProvider = GMapProviders.GoogleMap;               
            var gpsX = mapSet.GetCoordinatesX();
            var gpsY = mapSet.GetCoordinatesY();
            var gpsXList = mapSet.ListCoordinatesX(gpsX);                    
            var gpsYList = mapSet.ListCoordinatesY(gpsY); 
            mapMarkers.ShowMarkers(map, gpsXList, gpsYList);          
        }
        public void SetMap(List<Vehicle> Measurements, GMapControl map, System.Windows.Forms.ListView listView)
        {
            IPlaceMap place = new MapHandler();
            place.PlaceMap(map, listView, Measurements);
        }
    }
}
