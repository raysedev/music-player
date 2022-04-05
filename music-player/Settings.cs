using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace music_player
{
    public partial class Settings : Form
    {
        public Settings()
        {
            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(Settings_Tick);
            timer1.Interval = 1; // in miliseconds
            timer1.Start();

            InitializeComponent();
        }

        private void Settings_Tick(object sender, EventArgs e)
        {
            defPath.Text = Properties.Settings.Default.defaultScanPath;
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    /*scanPath = dialog.SelectedPath;
                    musicMP3 = Directory.GetFiles(scanPath, "*.mp3");
                    musicWAV = Directory.GetFiles(scanPath, "*.wav*");

                    Scan();*/

                    Properties.Settings.Default.defaultScanPath = dialog.SelectedPath;
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
