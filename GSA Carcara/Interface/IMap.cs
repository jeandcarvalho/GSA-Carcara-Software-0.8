using GMap.NET;
using GMap.NET.WindowsForms;
using GSA_Carcara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Interface
{
    interface IShowMarkers
    {
        void ShowMarkers(GMapControl map, List<float> gpsXList, List<float> gpsYList);
    }
    interface IPlaceMap
    {
        void PlaceMap(GMapControl map, ListView list, List<Vehicle> Measurements);
    }
    interface IMap
    {
        void SetStarterMap(GMapControl map);
        void SetMap(List<Vehicle> Measurements, GMapControl map, ListView listView);
    }
}
