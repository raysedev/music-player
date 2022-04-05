using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using WMPLib;
using System.Globalization;

namespace music_player
{
    public partial class MainForm : Form
    {
        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();

        double time = 0;

        private bool isFileOn = false;
        private bool isSongChanged = false;
        private bool isPlaying = false;

        public static string fileStartupPath = "";

        private int filesCurrent = 0;

        private string defaultScanPath = "";
        private string currentSong = "";
        private string scanPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "/";
        private string[] musicMP3 = { };
        private string[] musicWAV = { };

        List<string> musicList = new List<string>();
        List<string> wavList = new List<string>();

        public MainForm()
        {
            Timer timer1 = new Timer();
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Interval = 1; // in miliseconds
            timer1.Start();


            Timer timer2 = new Timer();
            timer2.Tick += new EventHandler(CheckMusic_Tick);
            timer2.Interval = 10000;
            //timer2.Start();
            InitializeComponent();
        }

        private void CheckMusic_Tick(object sender, EventArgs e)
        {
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.defaultScanPath != "")
            {
                scanPath = Properties.Settings.Default.defaultScanPath + "/";
            }

            if (filesCurrent < Directory.GetFiles(scanPath).Length)
            {
                filesCurrent = Directory.GetFiles(scanPath).Length;
                musicMP3 = Directory.GetFiles(scanPath, "*.mp3");
                musicWAV = Directory.GetFiles(scanPath, "*.wav");
                musicList.AddRange(musicMP3);
                musicList.AddRange(musicWAV);
                Scan();
            }
            else if (filesCurrent > Directory.GetFiles(scanPath).Length)
            {
                filesCurrent = Directory.GetFiles(scanPath).Length;
                musicMP3 = Directory.GetFiles(scanPath, "*.mp3");
                musicWAV = Directory.GetFiles(scanPath, "*.wav");
                musicList.AddRange(musicMP3);
                musicList.AddRange(musicWAV);
                Scan();
            }

            wplayer.settings.volume = volume.Value;
            Properties.Settings.Default.volumelvl = volume.Value;
            Properties.Settings.Default.Save();

            if (isPlaying == true)
            {  
                musicProgress.Maximum = Convert.ToInt32(wplayer.controls.currentItem.duration);
            } 

            if (musicBox.SelectedItem == fileStartupPath && fileStartupPath != "")
            {
                isFileOn = true;
            }
            else { isFileOn = false; }

            try
            {
                musicProgress.Value = Convert.ToInt32(wplayer.controls.currentPosition);
            }
            catch (Exception ex)
            { }
            musicLenght.Text = wplayer.controls.currentPositionString;
            
            

            if (isSongChanged == true)
            {
                wplayer.controls.currentPosition = 0;
                isSongChanged = false;
            }

            //MessageBox.Show(Convert.ToString(wplayer.controls.currentPosition) + " + " + Convert.ToString(musicProgress.Maximum));

            if (wplayer.controls.currentPosition >= 1 && Convert.ToInt32(wplayer.controls.currentPosition) == musicProgress.Maximum)
            {

                if (replay.Checked == true)
                {
                    wplayer.controls.stop();
                    isPlaying = false;
                    playBtn.Text = "Play";
                    wplayer.controls.play();
                }
                else if (musicBox.SelectedIndex < musicBox.Items.Count - 1)
                {
                    wplayer.controls.stop();
                    musicBox.SelectedIndex = musicBox.SelectedIndex + 1;
                    isPlaying = false;
                    playBtn.PerformClick();
                }
                else
                {
                    wplayer.controls.stop();
                    isPlaying = false;
                    playBtn.Text = "Play";
                }
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void Scan()
        {
            if (musicMP3.Length == 0)
            {
                if (isFileOn == true)
                {
                    StartupFile();
                }
                else if (isFileOn == false)
                {
                    musicBox.Items.Clear();
                    musicBox.Items.Add("No music is found in the current folder");
                }
            }
            else
            {
                musicBox.Items.Clear();

                for (int i = 0; i <= musicMP3.Length - 1; i++)
                {
                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                    string fileName = Path.GetFileName(musicMP3[i]);
                    musicBox.Items.Add(cultInfo.ToTitleCase(Path.GetFileNameWithoutExtension(fileName)));
                }


                for (int i = 0; i <= musicWAV.Length - 1; i++)
                {
                    TextInfo cultInfo = new CultureInfo("en-US", false).TextInfo;
                    string fileName = Path.GetFileName(musicWAV[i]);
                    musicBox.Items.Add(cultInfo.ToTitleCase(Path.GetFileNameWithoutExtension(fileName)));
                }

                StartupFile();
            }
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            PlayPause();
        }

        private void MusicBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                wplayer.URL = musicMP3[musicBox.SelectedIndex];
            }
            catch (IndexOutOfRangeException)
            {
                wplayer.URL = musicWAV[musicBox.Items.Count - Convert.ToInt32(musicMP3.Count()) - 1];

            }

            isPlaying = true;
            playBtn.Text = "Pause";
        }

        private void MusicBox_Click(object sender, EventArgs e)
        {
            
            try
            {
                wplayer.URL = musicMP3[musicBox.SelectedIndex];
            }
            catch (IndexOutOfRangeException)
            {
                wplayer.URL = musicWAV[musicBox.Items.Count - Convert.ToInt32(musicMP3.Count()) - 1];

            }



            isPlaying = true;
            playBtn.Text = "Pause";
        }

        private void MusicBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musicBox.SelectedIndex != 0)
            {
                currentSong = musicBox.SelectedItem.ToString();
                isSongChanged = true;
            }
            
            
        }

        private void PlayPause()
        {
            
            if (isPlaying == false)
            {
                try
                {
                    if (isFileOn == true)
                    {
                        musicBox.SelectedItem = (Path.GetFileNameWithoutExtension(fileStartupPath));
                    }
                    else
                    {
                        try
                        {
                            wplayer.URL = musicMP3[musicBox.SelectedIndex];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            wplayer.URL = musicWAV[musicBox.Items.Count - Convert.ToInt32(musicMP3.Count()) - 1];

                        }
                    }
                    isPlaying = true;
                    playBtn.Text = "Pause";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No song is selected");
                }



                    wplayer.controls.currentPosition = time;
                    wplayer.controls.play();
            }
            else
            {
                isPlaying = false;
                playBtn.Text = "Play";
                time = wplayer.controls.currentPosition;
                wplayer.controls.pause();
            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            wplayer.controls.currentPosition = musicProgress.Value;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            volume.Value = Properties.Settings.Default.volumelvl;

            if (fileStartupPath != "")
            {
                musicBox.Items.Add(Path.GetFileNameWithoutExtension(fileStartupPath));
                musicBox.SelectedItem = (Path.GetFileNameWithoutExtension(fileStartupPath));
                wplayer.URL = fileStartupPath;
                isPlaying = true;
                playBtn.Text = "Pause";
                wplayer.controls.currentPosition = time;
                wplayer.controls.play();
            }
            else
            {
                musicMP3 = Directory.GetFiles(scanPath, "*.mp3");
                musicWAV = Directory.GetFiles(scanPath, "*.wav");
                musicList.AddRange(musicMP3);
                musicList.AddRange(musicWAV);
                filesCurrent = Directory.GetFiles(scanPath).Length;   
                Scan();
            }
        }

        private void StartupFile()
        {
            if (fileStartupPath != "")
            {
                musicBox.Items.Add(Path.GetFileNameWithoutExtension(fileStartupPath));
                musicBox.SelectedItem = (Path.GetFileNameWithoutExtension(fileStartupPath));

                isFileOn = true;
            }
        }

        private void MainForm_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                playBtn.PerformClick();
            }
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    } 
}
