using GSA_Carcara.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSA_Carcara.Class
{
    internal class GetDirectory : IDirectorySelect
    {
        public string SelectDirectory()
        {
            string Folder = null;
            var openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) { Folder = openFileDialog1.SelectedPath; }
            return Folder;
        }
    }
}
