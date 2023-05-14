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
            var collections = new GetCollections();
            map.MapProvider = GMapProviders.GoogleMap;
            var Measurements = collections.CarCollection();
            List<PointLatLng> markersList = new List<PointLatLng>();
            GMapOverlay markers = new GMapOverlay("Markers");
            List<float> gpsX = new List<float>();
            List<float> gpsY = new List<float>();
            var queryX = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_X;
            var queryY = from e in Measurements.AsQueryable<Vehicle>() select e.Gps_Y;
            if(queryX.Any())
            {
                foreach (var coordinate in queryX)    {  gpsX.Add(coordinate);  }
                foreach (var coordinate in queryY)    {  gpsY.Add(coordinate);  }
                for (int i = 0; i < gpsX.Count; i++)
                {
                    PointLatLng point = new PointLatLng(gpsY[i], gpsX[i]);
                    markersList.Add(point);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                    markers.Markers.Add(marker);
                    i++; i++; i++;
                }
                map.Overlays.Add(markers);
                map.Position = markersList[0];
                map.MinZoom = 4; map.MaxZoom = 18;map.Zoom = 4;
            }
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
