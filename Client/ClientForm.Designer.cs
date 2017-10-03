namespace Client
{
    partial class ClientForm
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
            this.maskedTextBoxIPAddress = new System.Windows.Forms.MaskedTextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelUploadPath = new System.Windows.Forms.Label();
            this.groupBoxConnection = new System.Windows.Forms.GroupBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.maskedTextBoxPort = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxUpload = new System.Windows.Forms.GroupBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.groupBoxDownload = new System.Windows.Forms.GroupBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.listBoxServerFiles = new System.Windows.Forms.ListBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxConnection.SuspendLayout();
            this.groupBoxUpload.SuspendLayout();
            this.groupBoxDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBoxIPAddress
            // 
            this.maskedTextBoxIPAddress.Location = new System.Drawing.Point(70, 19);
            this.maskedTextBoxIPAddress.Name = "maskedTextBoxIPAddress";
            this.maskedTextBoxIPAddress.Size = new System.Drawing.Size(78, 20);
            this.maskedTextBoxIPAddress.TabIndex = 0;
            this.maskedTextBoxIPAddress.Text = "127.0.0.1";
            this.maskedTextBoxIPAddress.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBoxIPAddress_Validating);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(238, 17);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // labelUploadPath
            // 
            this.labelUploadPath.AutoSize = true;
            this.labelUploadPath.Location = new System.Drawing.Point(6, 47);
            this.labelUploadPath.Name = "labelUploadPath";
            this.labelUploadPath.Size = new System.Drawing.Size(85, 13);
            this.labelUploadPath.TabIndex = 2;
            this.labelUploadPath.Text = "No File Selected";
            // 
            // groupBoxConnection
            // 
            this.groupBoxConnection.Controls.Add(this.labelPort);
            this.groupBoxConnection.Controls.Add(this.labelIPAddress);
            this.groupBoxConnection.Controls.Add(this.maskedTextBoxPort);
            this.groupBoxConnection.Controls.Add(this.maskedTextBoxIPAddress);
            this.groupBoxConnection.Controls.Add(this.buttonConnect);
            this.groupBoxConnection.Location = new System.Drawing.Point(12, 12);
            this.groupBoxConnection.Name = "groupBoxConnection";
            this.groupBoxConnection.Size = new System.Drawing.Size(318, 51);
            this.groupBoxConnection.TabIndex = 3;
            this.groupBoxConnection.TabStop = false;
            this.groupBoxConnection.Text = "Server Info";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(154, 22);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 5;
            this.labelPort.Text = "Port";
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(6, 22);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(58, 13);
            this.labelIPAddress.TabIndex = 3;
            this.labelIPAddress.Text = "IP Address";
            // 
            // maskedTextBoxPort
            // 
            this.maskedTextBoxPort.Enabled = false;
            this.maskedTextBoxPort.Location = new System.Drawing.Point(182, 19);
            this.maskedTextBoxPort.Name = "maskedTextBoxPort";
            this.maskedTextBoxPort.Size = new System.Drawing.Size(50, 20);
            this.maskedTextBoxPort.TabIndex = 2;
            this.maskedTextBoxPort.Text = "7005";
            // 
            // groupBoxUpload
            // 
            this.groupBoxUpload.Controls.Add(this.buttonUpload);
            this.groupBoxUpload.Controls.Add(this.buttonBrowse);
            this.groupBoxUpload.Controls.Add(this.labelUploadPath);
            this.groupBoxUpload.Location = new System.Drawing.Point(12, 69);
            this.groupBoxUpload.Name = "groupBoxUpload";
            this.groupBoxUpload.Size = new System.Drawing.Size(318, 65);
            this.groupBoxUpload.TabIndex = 4;
            this.groupBoxUpload.TabStop = false;
            this.groupBoxUpload.Text = "File Upload";
            // 
            // buttonUpload
            // 
            this.buttonUpload.Enabled = false;
            this.buttonUpload.Location = new System.Drawing.Point(237, 19);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 23);
            this.buttonUpload.TabIndex = 4;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Enabled = false;
            this.buttonBrowse.Location = new System.Drawing.Point(9, 19);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 3;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // groupBoxDownload
            // 
            this.groupBoxDownload.Controls.Add(this.buttonRefresh);
            this.groupBoxDownload.Controls.Add(this.buttonDownload);
            this.groupBoxDownload.Controls.Add(this.listBoxServerFiles);
            this.groupBoxDownload.Location = new System.Drawing.Point(13, 140);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(317, 259);
            this.groupBoxDownload.TabIndex = 5;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "File Download";
            // 
            // buttonDownload
            // 
            this.buttonDownload.Enabled = false;
            this.buttonDownload.Location = new System.Drawing.Point(236, 19);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // listBoxServerFiles
            // 
            this.listBoxServerFiles.Enabled = false;
            this.listBoxServerFiles.FormattingEnabled = true;
            this.listBoxServerFiles.Items.AddRange(new object[] {
            "Not Connected to Server"});
            this.listBoxServerFiles.Location = new System.Drawing.Point(8, 19);
            this.listBoxServerFiles.Name = "listBoxServerFiles";
            this.listBoxServerFiles.Size = new System.Drawing.Size(222, 225);
            this.listBoxServerFiles.TabIndex = 0;
            this.listBoxServerFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxServerFiles_SelectedIndexChanged);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(236, 48);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 412);
            this.Controls.Add(this.groupBoxDownload);
            this.Controls.Add(this.groupBoxUpload);
            this.Controls.Add(this.groupBoxConnection);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.groupBoxConnection.ResumeLayout(false);
            this.groupBoxConnection.PerformLayout();
            this.groupBoxUpload.ResumeLayout(false);
            this.groupBoxUpload.PerformLayout();
            this.groupBoxDownload.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBoxIPAddress;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelUploadPath;
        private System.Windows.Forms.GroupBox groupBoxConnection;
        private System.Windows.Forms.GroupBox groupBoxUpload;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPort;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.GroupBox groupBoxDownload;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListBox listBoxServerFiles;
        private System.Windows.Forms.Button buttonRefresh;
    }
}

