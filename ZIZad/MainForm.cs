using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZIZad
{
    public partial class MainForm : Form
    {
        private bool fswOnOff;
        private string targetFolder;
        private DirectoryInfo targetDirectoryInfo; //CHECK IF NEEDED
        private string destinationFolder;
        private DirectoryInfo destinationDirectoryInfo; //CHECK IF NEEDED

        public MainForm()
        {
            fswOnOff = false;
            InitializeComponent();
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (fswOnOff)
            {
                lblOnOff.Text = "OFF";
                fswOnOff = false;

                btnChangeFolder.Enabled = true;

                //TODO: REST OF CODE
            }
            else
            {
                lblOnOff.Text = "ON";
                fswOnOff = true;

                btnChangeFolder.Enabled = false;

                //TODO: RESTO OF CODE
            }
        }
    }
}
