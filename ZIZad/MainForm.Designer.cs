namespace ZIZad
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOnOff = new System.Windows.Forms.Button();
            this.lblFileSystemWatcher = new System.Windows.Forms.Label();
            this.lblOnOff = new System.Windows.Forms.Label();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.txbxDestinationFolder = new System.Windows.Forms.TextBox();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.lblEncryptFiles = new System.Windows.Forms.Label();
            this.txbxEncryptFolder = new System.Windows.Forms.TextBox();
            this.btnChooseFolder = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblDecryptFile = new System.Windows.Forms.Label();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher = new System.IO.FileSystemWatcher();
            this.btnTargetFolder = new System.Windows.Forms.Button();
            this.lblTargetFolder = new System.Windows.Forms.Label();
            this.txbxTargetFolder = new System.Windows.Forms.TextBox();
            this.lblChooseAlgorithm = new System.Windows.Forms.Label();
            this.cmbxChooseAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblBlockMode = new System.Windows.Forms.Label();
            this.btnBlockModeOnOff = new System.Windows.Forms.Button();
            this.lblBlockModeOnOff = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnOff.Location = new System.Drawing.Point(15, 139);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(235, 28);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "TURN ON/OFF FILE SYSTEM WATCHER";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // lblFileSystemWatcher
            // 
            this.lblFileSystemWatcher.AutoSize = true;
            this.lblFileSystemWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileSystemWatcher.Location = new System.Drawing.Point(12, 119);
            this.lblFileSystemWatcher.Name = "lblFileSystemWatcher";
            this.lblFileSystemWatcher.Size = new System.Drawing.Size(247, 17);
            this.lblFileSystemWatcher.TabIndex = 1;
            this.lblFileSystemWatcher.Text = "FILE SYSTEM WATCHER IS TURNED";
            // 
            // lblOnOff
            // 
            this.lblOnOff.AutoSize = true;
            this.lblOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnOff.Location = new System.Drawing.Point(256, 119);
            this.lblOnOff.Name = "lblOnOff";
            this.lblOnOff.Size = new System.Drawing.Size(38, 17);
            this.lblOnOff.TabIndex = 2;
            this.lblOnOff.Text = "OFF";
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationFolder.Location = new System.Drawing.Point(12, 248);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(164, 17);
            this.lblDestinationFolder.TabIndex = 30;
            this.lblDestinationFolder.Text = "DESTINATION FOLDER:";
            // 
            // txbxDestinationFolder
            // 
            this.txbxDestinationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxDestinationFolder.Location = new System.Drawing.Point(15, 268);
            this.txbxDestinationFolder.Name = "txbxDestinationFolder";
            this.txbxDestinationFolder.ReadOnly = true;
            this.txbxDestinationFolder.Size = new System.Drawing.Size(235, 21);
            this.txbxDestinationFolder.TabIndex = 4;
            this.txbxDestinationFolder.TabStop = false;
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFolder.Location = new System.Drawing.Point(15, 295);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(235, 28);
            this.btnChangeFolder.TabIndex = 2;
            this.btnChangeFolder.Text = "CHANGE DESTINATION FOLDER";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // lblEncryptFiles
            // 
            this.lblEncryptFiles.AutoSize = true;
            this.lblEncryptFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncryptFiles.Location = new System.Drawing.Point(12, 326);
            this.lblEncryptFiles.Name = "lblEncryptFiles";
            this.lblEncryptFiles.Size = new System.Drawing.Size(118, 17);
            this.lblEncryptFiles.TabIndex = 60;
            this.lblEncryptFiles.Text = "ENCRYPT FILES:";
            // 
            // txbxEncryptFolder
            // 
            this.txbxEncryptFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxEncryptFolder.Location = new System.Drawing.Point(15, 346);
            this.txbxEncryptFolder.Name = "txbxEncryptFolder";
            this.txbxEncryptFolder.ReadOnly = true;
            this.txbxEncryptFolder.Size = new System.Drawing.Size(235, 21);
            this.txbxEncryptFolder.TabIndex = 7;
            this.txbxEncryptFolder.TabStop = false;
            // 
            // btnChooseFolder
            // 
            this.btnChooseFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFolder.Location = new System.Drawing.Point(15, 373);
            this.btnChooseFolder.Name = "btnChooseFolder";
            this.btnChooseFolder.Size = new System.Drawing.Size(235, 28);
            this.btnChooseFolder.TabIndex = 3;
            this.btnChooseFolder.Text = "CHOOSE FOLDER";
            this.btnChooseFolder.UseVisualStyleBackColor = true;
            this.btnChooseFolder.Click += new System.EventHandler(this.btnChooseFolder_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Enabled = false;
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(252, 373);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(82, 28);
            this.btnEncrypt.TabIndex = 4;
            this.btnEncrypt.Text = "ENCRYPT";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblDecryptFile
            // 
            this.lblDecryptFile.AutoSize = true;
            this.lblDecryptFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDecryptFile.Location = new System.Drawing.Point(12, 408);
            this.lblDecryptFile.Name = "lblDecryptFile";
            this.lblDecryptFile.Size = new System.Drawing.Size(109, 17);
            this.lblDecryptFile.TabIndex = 10;
            this.lblDecryptFile.Text = "DECRYPT FILE:";
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFile.Location = new System.Drawing.Point(15, 428);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(235, 28);
            this.btnChooseFile.TabIndex = 5;
            this.btnChooseFile.Text = "CHOOSE FILE";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(252, 428);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(82, 28);
            this.btnDecrypt.TabIndex = 6;
            this.btnDecrypt.Text = "DECRYPT";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(12, 459);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(282, 13);
            this.lblNote.TabIndex = 14;
            this.lblNote.Text = "Note: Decrypt option will ask to choose destination .txt file!";
            // 
            // fileSystemWatcher
            // 
            this.fileSystemWatcher.EnableRaisingEvents = true;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new System.IO.FileSystemEventHandler(this.OnCreated);
            // 
            // btnTargetFolder
            // 
            this.btnTargetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTargetFolder.Location = new System.Drawing.Point(15, 217);
            this.btnTargetFolder.Name = "btnTargetFolder";
            this.btnTargetFolder.Size = new System.Drawing.Size(235, 28);
            this.btnTargetFolder.TabIndex = 1;
            this.btnTargetFolder.Text = "CHOOSE TARGET FOLDER";
            this.btnTargetFolder.UseVisualStyleBackColor = true;
            this.btnTargetFolder.Click += new System.EventHandler(this.btnTargetFolder_Click);
            // 
            // lblTargetFolder
            // 
            this.lblTargetFolder.AutoSize = true;
            this.lblTargetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetFolder.Location = new System.Drawing.Point(12, 170);
            this.lblTargetFolder.Name = "lblTargetFolder";
            this.lblTargetFolder.Size = new System.Drawing.Size(125, 17);
            this.lblTargetFolder.TabIndex = 16;
            this.lblTargetFolder.Text = "TARGET FOLDER";
            // 
            // txbxTargetFolder
            // 
            this.txbxTargetFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbxTargetFolder.Location = new System.Drawing.Point(15, 190);
            this.txbxTargetFolder.Name = "txbxTargetFolder";
            this.txbxTargetFolder.ReadOnly = true;
            this.txbxTargetFolder.Size = new System.Drawing.Size(235, 21);
            this.txbxTargetFolder.TabIndex = 17;
            this.txbxTargetFolder.TabStop = false;
            // 
            // lblChooseAlgorithm
            // 
            this.lblChooseAlgorithm.AutoSize = true;
            this.lblChooseAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseAlgorithm.Location = new System.Drawing.Point(12, 21);
            this.lblChooseAlgorithm.Name = "lblChooseAlgorithm";
            this.lblChooseAlgorithm.Size = new System.Drawing.Size(237, 17);
            this.lblChooseAlgorithm.TabIndex = 61;
            this.lblChooseAlgorithm.Text = "CHOOSE CRYPTOALGORITHM:";
            // 
            // cmbxChooseAlgorithm
            // 
            this.cmbxChooseAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxChooseAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxChooseAlgorithm.FormattingEnabled = true;
            this.cmbxChooseAlgorithm.Location = new System.Drawing.Point(15, 41);
            this.cmbxChooseAlgorithm.Name = "cmbxChooseAlgorithm";
            this.cmbxChooseAlgorithm.Size = new System.Drawing.Size(234, 24);
            this.cmbxChooseAlgorithm.TabIndex = 62;
            this.cmbxChooseAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cmbxChooseAlgorithm_SelectedIndexChanged);
            // 
            // lblBlockMode
            // 
            this.lblBlockMode.AutoSize = true;
            this.lblBlockMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockMode.Location = new System.Drawing.Point(12, 68);
            this.lblBlockMode.Name = "lblBlockMode";
            this.lblBlockMode.Size = new System.Drawing.Size(177, 17);
            this.lblBlockMode.TabIndex = 63;
            this.lblBlockMode.Text = "BLOCK MODE IS TURNED";
            // 
            // btnBlockModeOnOff
            // 
            this.btnBlockModeOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBlockModeOnOff.Location = new System.Drawing.Point(15, 88);
            this.btnBlockModeOnOff.Name = "btnBlockModeOnOff";
            this.btnBlockModeOnOff.Size = new System.Drawing.Size(200, 28);
            this.btnBlockModeOnOff.TabIndex = 64;
            this.btnBlockModeOnOff.Text = "TURN ON/OFF BLOCK MODE";
            this.btnBlockModeOnOff.UseVisualStyleBackColor = true;
            this.btnBlockModeOnOff.Click += new System.EventHandler(this.btnBlockModeOnOff_Click);
            // 
            // lblBlockModeOnOff
            // 
            this.lblBlockModeOnOff.AutoSize = true;
            this.lblBlockModeOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlockModeOnOff.Location = new System.Drawing.Point(186, 68);
            this.lblBlockModeOnOff.Name = "lblBlockModeOnOff";
            this.lblBlockModeOnOff.Size = new System.Drawing.Size(38, 17);
            this.lblBlockModeOnOff.TabIndex = 65;
            this.lblBlockModeOnOff.Text = "OFF";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 501);
            this.Controls.Add(this.lblBlockModeOnOff);
            this.Controls.Add(this.btnBlockModeOnOff);
            this.Controls.Add(this.lblBlockMode);
            this.Controls.Add(this.cmbxChooseAlgorithm);
            this.Controls.Add(this.lblChooseAlgorithm);
            this.Controls.Add(this.txbxTargetFolder);
            this.Controls.Add(this.lblTargetFolder);
            this.Controls.Add(this.btnTargetFolder);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.lblDecryptFile);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnChooseFolder);
            this.Controls.Add(this.txbxEncryptFolder);
            this.Controls.Add(this.lblEncryptFiles);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.txbxDestinationFolder);
            this.Controls.Add(this.lblDestinationFolder);
            this.Controls.Add(this.lblOnOff);
            this.Controls.Add(this.lblFileSystemWatcher);
            this.Controls.Add(this.btnOnOff);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 540);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 540);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZI Zad";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.Label lblFileSystemWatcher;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.TextBox txbxDestinationFolder;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.Label lblEncryptFiles;
        private System.Windows.Forms.TextBox txbxEncryptFolder;
        private System.Windows.Forms.Button btnChooseFolder;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblDecryptFile;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.IO.FileSystemWatcher fileSystemWatcher;
        private System.Windows.Forms.TextBox txbxTargetFolder;
        private System.Windows.Forms.Label lblTargetFolder;
        private System.Windows.Forms.Button btnTargetFolder;
        private System.Windows.Forms.ComboBox cmbxChooseAlgorithm;
        private System.Windows.Forms.Label lblChooseAlgorithm;
        private System.Windows.Forms.Label lblBlockModeOnOff;
        private System.Windows.Forms.Button btnBlockModeOnOff;
        private System.Windows.Forms.Label lblBlockMode;
    }
}

