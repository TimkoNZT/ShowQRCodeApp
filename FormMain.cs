using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ShowQRcodeApp
{
    
    public partial class frmMain : Form
    {

        private Bitmap m_lastBitmap;
        private int m_Timeout;
        private FileSystemWatcher m_watcher;
        private string m_currentPath;
        private string m_Mode;

        public frmMain()
        {
            InitializeComponent();
        }

        public string Mode
        {
            set
            {
                var Modes = new string[] {"img", "html", "qr" };
                if (!String.IsNullOrEmpty(value)
                    & Modes.Contains(value)
                    )
                {
                    m_Mode = value;
                }
                else
                {
                    throw new Exception("Wrong mode received. Mode should be one of: img, html");
                }
            }
            get
            {
                return m_currentPath;
            }
        }

        public string FilePath
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    m_currentPath = Path.GetFullPath(value);
                    if (m_watcher != null)
                    {
                        StopListening();
                    }
                    ShowFile(m_currentPath);
                    ListenToPath();
                }
                else
                {
                    throw new Exception("Empty file path received.");
                }
            }
            get
            {
                return m_currentPath;
            }
        }

        public int Timeout
        {
            set
            {
                if (value > 3600)
                {
                    throw new Exception("Timeout must be less than an hour");
                }

                if (value != 0)
                {
                    m_Timeout = value;
                    timerOut.Interval = m_Timeout * 1000;
                    timerOut.Enabled= true;
                }
            }
            get
            {
                return m_Timeout;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowImage(Image img)
        {
            if (img == null)
            {
                pbImage.Image = null;
            }
            else
            {
                m_lastBitmap = new Bitmap(img);
                pbImage.Image = m_lastBitmap;
            }
        }

        public void ShowHtml(string path)
        {
            if (path == null)
            {
                wbHtml.Navigate("");
            }
            else
            { 
                wbHtml.Navigate(path);
                wbHtml.Refresh();
            }
        }

        public void ShowFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                SetElementsVisiblity(false);

                switch (m_Mode)
                {
                    case "img":
                        ShowImage((Bitmap)null);
                        break;
                    case "html":
                        ShowHtml((String)null);
                        break;
                    default:
                        break;
                }
            } 
            else 
            {
                SetElementsVisiblity(true);

                switch (m_Mode)
                {
                    case "img":
                        Image imgDisk = Image.FromFile(filePath);
                        ShowImage(imgDisk);
                        imgDisk.Dispose();
                        break;
                    case "html":
                        ShowHtml(filePath);
                        break;
                    default:
                        break;
                }
            }
        }

        private void StopListening()
        {
            if (m_watcher != null)
            {
                m_watcher.EnableRaisingEvents = false;
                m_watcher.Dispose();
                m_watcher = null;
            }
        }

        private void ListenToPath()
        {
            if (m_watcher == null)
            {
                var m_Folder = Path.GetDirectoryName(m_currentPath);
                var m_FileName = Path.GetFileName(m_currentPath);
                m_watcher = new FileSystemWatcher(m_Folder, m_FileName);
                m_watcher.Changed += OnChanged;
                m_watcher.Created += OnChanged;
                m_watcher.Deleted += OnChanged;
                m_watcher.EnableRaisingEvents = true;
            }
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            ShowFile(e.FullPath);
        }
        private void SetElementsVisiblity(bool VisState)
        {
            if (InvokeRequired)
                this.Invoke(new Action(() => lblNotFound.Visible = !VisState)); else lblNotFound.Visible = !VisState;
                
            switch (m_Mode)
            {
                case "img":
                    if (InvokeRequired) this.Invoke(new Action(() => pbImage.Visible = VisState)); else pbImage.Visible = VisState;
                    break;
                case "html":
                    if (InvokeRequired) this.Invoke(new Action(() => wbHtml.Visible = VisState)); else wbHtml.Visible = VisState;
                    break;
                case "qr":
                    break;
                default:
                    break;
            }
        }

        private void TimerOut_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbImage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblNotFound_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void WbHtml_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            wbHtml.Document.Click += pbImage_Click;
        }
    }
}
