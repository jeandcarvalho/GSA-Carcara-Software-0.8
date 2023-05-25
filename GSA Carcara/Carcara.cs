using Amazon.Util.Internal;
using AxWMPLib;
using GSA_Carcara.Class;
using GSA_Carcara.Classes;
using GSA_Carcara.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapGraphHopperRouteEntity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace GSA_Carcara
{
    public partial class Carcara : Form
    {
        public List<Vehicle> CarFiltred = new List<Vehicle>();
        public List<Rating> RatingFiltred = new List<Rating>();
        public Carcara()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            new Map().SetStarterMap(map);
            new StatusDB().statusDatabase(DatabaseStatus);           
            new MediaPlayerConfig().InitSettings(axWindowsMediaPlayer1, axWindowsMediaPlayer2, 
                                                 axWindowsMediaPlayer3, axWindowsMediaPlayer4, 
                                                 axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void updateGSADBMenuItem_Click(object sender, EventArgs e)
        {
            new DBmongo().UpdateMongo(DatabaseStatus);
            new Map().SetStarterMap(map);                                                                                         
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                var collections = new GetCollections();
                var Measurements = collections.CarCollection();                                                                    //catch both collections in db
                var Ratings = collections.RatingCollection();             
                string[] CarFilters = { textBox1.Text, textBox2.Text, comboBox6.Text };                                     
                string[] RatingFilters = { comboBox1.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text,                         //catch the selects filters in combobox's
                                           comboBox7.Text, comboBox8.Text, comboBox9.Text, comboBox10.Text };           

                CarFiltred = new FiltersFunctions().CarFilter(Measurements, CarFilters);                                           //apply filters in measurements collection, and get query data to a list
                RatingFiltred = new FiltersFunctions().RatingFilter(Ratings, RatingFilters);                                       //apply filters in ratings collection, and get query data to a list
                new FiltersFunctions().IntersectFilters(CarFiltred, RatingFiltred);                                                // this function finds intersection data between these two filtered lists, when finished, items.counts of both filtered  results are the same
                new ListViewHandler().setListView(listView1);                                                                      //Config listview
                new ListViewHandler().AddToListView(listView1, CarFiltred, RatingFiltred);                                         //add items to listview
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            try
            {
                new Extract().ExtractFiles(CarFiltred, RatingFiltred);                                                              //extract video files and data filtred in csv
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            new MediaPlayerHandler().SetVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3, axWindowsMediaPlayer4,  //set and play videos
                                               axWindowsMediaPlayer5, axWindowsMediaPlayer6, CarFiltred, RatingFiltred, listView1);
            new Map().SetMap(CarFiltred, map, listView1);   //defines map position to the same location in the moment clicked
        }

        private void PlayVideos_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().PlayVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void PauseVideos_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().PauseVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                                 axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void Less5Seconds_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().LessSecondsToVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                                axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void More5Seconds_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().MoreSecondsToVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                                axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().ForwardVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                               axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void BackwardButton_Click(object sender, EventArgs e)
        {
            new MediaPlayerControls().BackwardToVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                                               axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        
    }   
}
