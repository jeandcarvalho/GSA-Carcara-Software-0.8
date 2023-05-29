using Amazon.Util.Internal;
using AxWMPLib;
using GSA_Carcara.Class;
using GSA_Carcara.Classes;
using GSA_Carcara.Controls;
using GSA_Carcara.Interface;
using GSA_Carcara.Models;
using MediaPlayer;
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
        IMap maps = new Map();
        IStatusDatabase statusDB = new StatusDB();
        IListView listViewAux = new ListViewHandler();
        IMPInitialSettings setMP = new MediaPlayerSettings();
        IUpdateMongo updateDB = new DBmongo();
        IFilter filter = new Filter();       
        IMediaPlayerButtons MPbuttons = new MediaPlayerButtons();
        IMediaPlayerSet mp = new MediaPlayers();
        IExtract extract = new Extract();

        public Carcara()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            maps.SetStarterMap(map);
            statusDB.SetStatusDatabase(DatabaseStatus);
            setMP.InitSettings(axWindowsMediaPlayer1, axWindowsMediaPlayer2, 
                               axWindowsMediaPlayer3, axWindowsMediaPlayer4, 
                               axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }

        private void updateGSADBMenuItem_Click(object sender, EventArgs e)
        {
            updateDB.UpdateMongo(DatabaseStatus);
            maps.SetStarterMap(map);                                                                                         
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {           
                string[] CarFilters = { textBox1.Text, textBox2.Text, comboBox6.Text };                                                                                                                                                  
                string[] RatingFilters = { comboBox1.Text, comboBox2.Text, comboBox3.Text,
                                           comboBox4.Text, comboBox7.Text, comboBox8.Text,
                                           comboBox9.Text, comboBox10.Text };                
                CarFiltred = filter.CarFilter(CarFilters);                                                                                                                                                              
                RatingFiltred = filter.RatingFilter(RatingFilters);                                                                                                                                                     
                filter.IntersectFilters(CarFiltred, RatingFiltred);                                          //this function finds intersection data between these two filtered lists, when finished, items.counts of both filtered  results are the same                                                                                                                                                                     //Config listview
                listViewAux.setListView(listView1);
                listViewAux.AddToListView(listView1, CarFiltred);                                                                                                                                         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            mp.SetVideos(axWindowsMediaPlayer1, axWindowsMediaPlayer2,
                         axWindowsMediaPlayer3, axWindowsMediaPlayer4,  
                         axWindowsMediaPlayer5, axWindowsMediaPlayer6,
                         CarFiltred, listView1);//set and play videos
            maps.SetMap(CarFiltred, map, listView1);//map position to moment clicked
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            try    //extract video files and data queried 
            {
                extract.ExtractToFolder(CarFiltred, RatingFiltred);
            }             
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PlayVideos_Click(object sender, EventArgs e)
        {
            MPbuttons.PlayMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                             axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        private void PauseVideos_Click(object sender, EventArgs e)
        {
            MPbuttons.PauseMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                              axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        private void Less5Seconds_Click(object sender, EventArgs e)
        {
            MPbuttons.LessMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                             axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        private void More5Seconds_Click(object sender, EventArgs e)
        {
            MPbuttons.MoreMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                             axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        private void ForwardButton_Click(object sender, EventArgs e)
        {
            MPbuttons.ForwMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                             axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }
        private void BackwardButton_Click(object sender, EventArgs e)
        {
            MPbuttons.BackMP(axWindowsMediaPlayer1, axWindowsMediaPlayer2, axWindowsMediaPlayer3,
                             axWindowsMediaPlayer4, axWindowsMediaPlayer5, axWindowsMediaPlayer6);
        }   
    }   
}
