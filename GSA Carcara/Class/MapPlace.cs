using GMap.NET;
using GMap.NET.WindowsForms;
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
    public class MapPlace : IPlaceMap
    {
        public void PlaceMap(GMapControl map, System.Windows.Forms.ListView listView, List<Vehicle> Measurements)
        {
            if (listView.SelectedItems.Count > 0)
            {   // double-clicked moment 
                ListViewItem item = listView.SelectedItems[0];
                var moment = new DateTimeTools().ItemToDateTime(item.Text.ToString());
                foreach (var coordinate in Measurements)
                {
                    if (coordinate.TimeStemp == moment)
                    {
                        var x = coordinate.Gps_X; var y = coordinate.Gps_Y;
                        var point = new PointLatLng(y, x);
                        map.Position=point;map.Zoom=15;}
                }
            }
        }
    }
}
