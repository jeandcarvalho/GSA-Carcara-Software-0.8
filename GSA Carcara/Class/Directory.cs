using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara
{
    public class Directory_Handler
    {
        public Directory_Handler()
        {
        }
        public string Directory_Finder()                                   // allows the user to find a folder
        {
            string Folder = null;
            var openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {Folder = openFileDialog1.SelectedPath;}
            return Folder;
        }
    }      
}
