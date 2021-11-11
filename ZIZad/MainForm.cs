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
        #region Attributes

        private bool fswOnOff;
        private string targetFolderPath;
        private string destinationFolderPath;
        private DirectoryInfo destinationDirectoryInfo;
        private string encryptFolderPath;
        private DirectoryInfo encryptDirectoryInfo;
        private string decryptFilePath;
        private FileInfo decryptFileInfo;

        private Bifid cryptoAlgorithm;

        #endregion

        public MainForm()
        {
            fswOnOff = false;

            this.targetFolderPath = "C:\\Users\\jelen\\Desktop\\ZI target folder";

            cryptoAlgorithm = new Bifid();

            InitializeComponent();
        }

        #region EventHandlers

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            if (!fswOnOff)
            {
                if (String.IsNullOrEmpty(txbxDestinationFolder.Text))
                {
                    MessageBox.Show("Destination Folder must be chosen first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblOnOff.Text = "ON";
                fswOnOff = true;

                btnChangeFolder.Enabled = false;
                btnChooseFolder.Enabled = false;
                btnEncrypt.Enabled = false;
                btnChooseFile.Enabled = false;
                btnDecrypt.Enabled = false;

                fileSystemWatcher = new FileSystemWatcher();
                fileSystemWatcher.Path = this.targetFolderPath;
                fileSystemWatcher.Filter = "*.txt";
                fileSystemWatcher.Created += OnCreated;
                fileSystemWatcher.EnableRaisingEvents = true;
            }
            else
            {
                lblOnOff.Text = "OFF";
                fswOnOff = false;

                btnChangeFolder.Enabled = true;
                btnChooseFolder.Enabled = true;
                btnChooseFile.Enabled = true;

                fileSystemWatcher.EnableRaisingEvents = false;
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = "";
            folderBrowserDialog.ShowDialog();

            if (String.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                return;

            if (folderBrowserDialog.SelectedPath == this.targetFolderPath)
            {
                MessageBox.Show("Destination Folder must be different from Target Folder!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.destinationFolderPath = folderBrowserDialog.SelectedPath;
            txbxDestinationFolder.Text = this.destinationFolderPath;
            this.destinationDirectoryInfo = new DirectoryInfo(this.destinationFolderPath);
        }

        private void btnChooseFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = "";
            folderBrowserDialog.ShowDialog();

            if (String.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                return;

            if (folderBrowserDialog.SelectedPath == this.destinationFolderPath)
            {
                MessageBox.Show("Chosen Folder must be different from Destination Folder!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.encryptFolderPath = folderBrowserDialog.SelectedPath;
            txbxEncryptFolder.Text = this.encryptFolderPath;
            this.encryptDirectoryInfo = new DirectoryInfo(this.encryptFolderPath);

            btnEncrypt.Enabled = true;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = this.destinationFolderPath;
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.ShowDialog();

            if (String.IsNullOrEmpty(openFileDialog.FileName))
                return;

            this.decryptFilePath = openFileDialog.FileName;
            this.decryptFileInfo = new FileInfo(this.decryptFilePath);

            btnDecrypt.Enabled = true;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            foreach (var file in this.encryptDirectoryInfo.GetFiles()) //TODO: ADD TXT FILTER
                this.cryptoAlgorithm.Encrypt(file);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            this.cryptoAlgorithm.Decrypt(this.decryptFileInfo);

            folderBrowserDialog.SelectedPath = "";
            folderBrowserDialog.ShowDialog();

            while (String.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                MessageBox.Show("Destination Folder must be chosen!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                folderBrowserDialog.ShowDialog();
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            string newFilePath = e.FullPath;
            FileInfo newFileFileInfo = new FileInfo(newFilePath);

            //TODO: ENCRYPTING PART
        }

        #endregion
    }
}
