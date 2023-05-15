using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GSA_Carcara.Class;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Classes
{
    public class MapHandler
    {
        
        public void SetStarterMap( GMapControl map)
        {
            map.MapProvider = GMapProviders.GoogleMap; 
            var mapSet = new MapCoordinates();
            var gpsX = mapSet.GetCoordinatesX();
            var gpsY = mapSet.GetCoordinatesY();
            var gpsXList = mapSet.ListCoordinatesX(gpsX);
            var gpsYList = mapSet.ListCoordinatesX(gpsY);
            var mapMarkers = new MapMarkers();
            mapMarkers.ShowMarkers(map, gpsXList, gpsYList);
        }

        public void SetMap(List<Vehicle> Measurements, GMapControl map, System.Windows.Forms.ListView listView)
        {
            if (listView.SelectedItems.Count > 0)
            {
                PointLatLng point;
                ListViewItem item = listView.SelectedItems[0];
                DateTime moment = new DateTimeTools().ItemToDateTime(item.Text.ToString());

                foreach (var coordinate in Measurements)
                {
                    if (coordinate.TimeStemp == moment)
                    {
                        float x = coordinate.Gps_X; float y = coordinate.Gps_Y;
                        point = new PointLatLng(y, x);
                        map.Position = point;
                        map.Zoom = 15;
                    }
                }
            }
        }
    }
}
