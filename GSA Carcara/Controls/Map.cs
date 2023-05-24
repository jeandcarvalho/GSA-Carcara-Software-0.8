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
    public class Map
    {
       
        public void SetStarterMap( GMapControl map)
        {
            map.MapProvider = GMapProviders.GoogleMap;

            IGetCoordinates mapSetX = new MapCoordinatesX();
            var gpsX = mapSetX.GetCoordinates();
            var gpsXList = mapSetX.ListCoordinates(gpsX);

            IGetCoordinates mapSetY = new MapCoordinatesY();
            var gpsY = mapSetY.GetCoordinates();           
            var gpsYList = mapSetY.ListCoordinates(gpsY);

            IShowMarkers mapMarkers = new MapMarkers();
            mapMarkers.ShowMarkers(map, gpsXList, gpsYList);          
        }

        public void SetMap(List<Vehicle> Measurements, GMapControl map, System.Windows.Forms.ListView listView)
        {
            IPlaceMap place = new MapPlace();
            place.PlaceMap(map, listView, Measurements);
        }
    }
}
