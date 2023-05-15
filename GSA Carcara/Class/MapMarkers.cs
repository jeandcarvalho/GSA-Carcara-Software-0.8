using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Class
{
    public class MapMarkers : IShowMarkers
    {
        List<PointLatLng> markersList = new List<PointLatLng>();
        GMapOverlay markers = new GMapOverlay("Markers");

        public void ShowMarkers(GMapControl map, List<float> gpsXList, List<float> gpsYList)
        {
            for (int i = 0; i < gpsXList.Count; i++)
            {
                PointLatLng point = new PointLatLng(gpsYList[i], gpsXList[i]);
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_small);
                markersList.Add(point);
                markers.Markers.Add(marker);
                i +=3; // items show interval
            }
            map.Overlays.Add(markers);
            map.Position = markersList[0];
            map.MinZoom = 4; map.MaxZoom = 18; map.Zoom = 4;
        }
    }
}
