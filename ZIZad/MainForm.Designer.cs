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
            this.llblFileSystemWatcher = new System.Windows.Forms.Label();
            this.lblOnOff = new System.Windows.Forms.Label();
            this.lblDestinationFolder = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOnOff
            // 
            this.btnOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnOff.Location = new System.Drawing.Point(15, 42);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(235, 28);
            this.btnOnOff.TabIndex = 0;
            this.btnOnOff.Text = "TURN ON/OFF FILE SYSTEM WATCHER";
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // llblFileSystemWatcher
            // 
            this.llblFileSystemWatcher.AutoSize = true;
            this.llblFileSystemWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblFileSystemWatcher.Location = new System.Drawing.Point(12, 22);
            this.llblFileSystemWatcher.Name = "llblFileSystemWatcher";
            this.llblFileSystemWatcher.Size = new System.Drawing.Size(247, 17);
            this.llblFileSystemWatcher.TabIndex = 1;
            this.llblFileSystemWatcher.Text = "FILE SYSTEM WATCHER IS TURNED";
            // 
            // lblOnOff
            // 
            this.lblOnOff.AutoSize = true;
            this.lblOnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnOff.Location = new System.Drawing.Point(255, 22);
            this.lblOnOff.Name = "lblOnOff";
            this.lblOnOff.Size = new System.Drawing.Size(38, 17);
            this.lblOnOff.TabIndex = 2;
            this.lblOnOff.Text = "OFF";
            // 
            // lblDestinationFolder
            // 
            this.lblDestinationFolder.AutoSize = true;
            this.lblDestinationFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestinationFolder.Location = new System.Drawing.Point(12, 97);
            this.lblDestinationFolder.Name = "lblDestinationFolder";
            this.lblDestinationFolder.Size = new System.Drawing.Size(164, 17);
            this.lblDestinationFolder.TabIndex = 3;
            this.lblDestinationFolder.Text = "DESTINATION FOLDER:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(235, 21);
            this.textBox1.TabIndex = 4;
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeFolder.Location = new System.Drawing.Point(15, 144);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(235, 28);
            this.btnChangeFolder.TabIndex = 5;
            this.btnChangeFolder.Text = "CHANGE DESTINATION FOLDER";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChangeFolder);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblDestinationFolder);
            this.Controls.Add(this.lblOnOff);
            this.Controls.Add(this.llblFileSystemWatcher);
            this.Controls.Add(this.btnOnOff);
            this.Name = "MainForm";
            this.Text = "ZI Zad 1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOnOff;
        private System.Windows.Forms.Label llblFileSystemWatcher;
        private System.Windows.Forms.Label lblOnOff;
        private System.Windows.Forms.Label lblDestinationFolder;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnChangeFolder;
    }
}

