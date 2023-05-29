using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GSA_Carcara.Classes;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSA_Carcara.Class
{
    public class MapHandler : IPlaceMap, IShowMarkers
    {
        public void PlaceMap(GMapControl map, System.Windows.Forms.ListView listView, List<Vehicle> Measurements)
        {
            if (listView.SelectedItems.Count > 0)
            {   // double-clicked moment 
                ListViewItem item = listView.SelectedItems[0];
                var moment = Convert.ToDateTime(item.Text.ToString());
                foreach (var coordinate in Measurements)
                {
                    if (coordinate.TimeStemp == moment)
                    {
                        var x = coordinate.Gps_X; var y = coordinate.Gps_Y;
                        var point = new PointLatLng(y, x);
                        map.Position=point;map.Zoom=15;
                    }
                }
            }
        }
        public void ShowMarkers(GMapControl map, List<float> gpsXList, List<float> gpsYList)
        {
            List<PointLatLng> markersList = new List<PointLatLng>();
            GMapOverlay markers = new GMapOverlay("Markers");
            if (gpsXList.Count != 0)
            {
                for (int i = 0; i < gpsXList.Count; i++)
                {
                    PointLatLng point = new PointLatLng(gpsYList[i], gpsXList[i]);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                    markersList.Add(point);
                    markers.Markers.Add(marker);
                    i += 3; // items show interval
                }
                map.Overlays.Add(markers);
                map.Position = markersList[0];
                map.MinZoom = 4; map.MaxZoom = 18; map.Zoom = 4;
            }
        }
    }
}
