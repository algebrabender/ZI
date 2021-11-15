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

        private Bifid cryptoAlgorithm;

        #endregion

        public MainForm()
        {
            fswOnOff = false;

            this.targetFolderPath = "D:\\School and Uni\\ELFAK\\ZI target folder";

            cryptoAlgorithm = new Bifid();

            InitializeComponent();
        }

        #region Methodes

        private void WriteIntoDestinationFolder(List<string> fileLines, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var item in fileLines)
                {
                    sw.WriteLine(item);
                }

                sw.Close();
            }
        }

        #endregion

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

            btnDecrypt.Enabled = true;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            List<string> encryptedFileLines = new List<string>();
            List<FileInfo> fileInfos = this.encryptDirectoryInfo.GetFiles().ToList();
            List<FileInfo> onlyTxts = fileInfos.Where(fi => fi.Extension == ".txt").ToList();
            
            foreach (var file in onlyTxts)
            {
                encryptedFileLines.Clear();
                encryptedFileLines.AddRange(this.cryptoAlgorithm.Encrypt(file.FullName));
                
                this.WriteIntoDestinationFolder(encryptedFileLines, this.destinationFolderPath + "\\" + file.Name.Replace(".txt", "Encrypted.txt"));
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            List<string> decrytedFileLines = this.cryptoAlgorithm.Decrypt(this.decryptFilePath);

            folderBrowserDialog.SelectedPath = "";
            folderBrowserDialog.ShowDialog();

            while (String.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                MessageBox.Show("Destination Folder must be chosen!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                folderBrowserDialog.ShowDialog();
            }

            string[] splited = this.decryptFilePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace("Encrypted.txt", "Decrypted.txt");

            this.WriteIntoDestinationFolder(decrytedFileLines, folderBrowserDialog.SelectedPath + "\\" + fileName);
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string newFilePath = e.FullPath;

            List<string> encryptedFileLines = new List<string>();

            encryptedFileLines.AddRange(this.cryptoAlgorithm.Encrypt(newFilePath));

            string[] splited = newFilePath.Split('\\');
            string fileName = splited[splited.Length - 1].Replace(".txt", "Encrypted.txt");

            this.WriteIntoDestinationFolder(encryptedFileLines, this.destinationFolderPath + "\\" + fileName);
        }

        #endregion
    }
}
