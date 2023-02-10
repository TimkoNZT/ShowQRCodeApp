namespace ShowQRcodeApp
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.timerOut = new System.Windows.Forms.Timer(this.components);
            this.lblNotFound = new System.Windows.Forms.Label();
            this.wbHtml = new System.Windows.Forms.WebBrowser();
            this.pbImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // timerOut
            // 
            this.timerOut.Interval = 1000;
            this.timerOut.Tick += new System.EventHandler(this.TimerOut_Tick);
            // 
            // lblNotFound
            // 
            this.lblNotFound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotFound.BackColor = System.Drawing.Color.Transparent;
            this.lblNotFound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNotFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNotFound.ForeColor = System.Drawing.Color.White;
            this.lblNotFound.Location = new System.Drawing.Point(55, 138);
            this.lblNotFound.Name = "lblNotFound";
            this.lblNotFound.Size = new System.Drawing.Size(245, 73);
            this.lblNotFound.TabIndex = 1;
            this.lblNotFound.Text = "File not found. Check command line options!";
            this.lblNotFound.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotFound.Visible = false;
            this.lblNotFound.Click += new System.EventHandler(this.LblNotFound_Click);
            // 
            // wbHtml
            // 
            this.wbHtml.AllowNavigation = false;
            this.wbHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbHtml.IsWebBrowserContextMenuEnabled = false;
            this.wbHtml.Location = new System.Drawing.Point(12, 12);
            this.wbHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHtml.Name = "wbHtml";
            this.wbHtml.ScrollBarsEnabled = false;
            this.wbHtml.Size = new System.Drawing.Size(326, 326);
            this.wbHtml.TabIndex = 2;
            this.wbHtml.Visible = false;
            this.wbHtml.WebBrowserShortcutsEnabled = false;
            this.wbHtml.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WbHtml_DocumentCompleted);
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.BackColor = System.Drawing.Color.ForestGreen;
            this.pbImage.Location = new System.Drawing.Point(12, 12);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(326, 326);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            this.pbImage.Visible = false;
            this.pbImage.Click += new System.EventHandler(this.pbImage_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.ClientSize = new System.Drawing.Size(350, 350);
            this.Controls.Add(this.wbHtml);
            this.Controls.Add(this.lblNotFound);
            this.Controls.Add(this.pbImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerOut;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblNotFound;
        private System.Windows.Forms.WebBrowser wbHtml;
    }
}