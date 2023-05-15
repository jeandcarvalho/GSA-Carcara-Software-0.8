using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSA_Carcara.Interface
{
    interface IShowMarkers
    {
        void ShowMarkers(GMapControl map, List<float> gpsXList, List<float> gpsYList);
    }
}
