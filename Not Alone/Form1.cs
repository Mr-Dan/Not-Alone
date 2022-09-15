using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using Not_Alone_Server.Class;
using WMPLib;

namespace Not_Alone
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream serverStream = null;
        bool connectServer = false;
        string dataFromServer = null;
        bool fileExist = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (panelSettings.Visible == true)
            {
                panelSettings.Visible = false;
            }
            else
            {
                panelSettings.Visible = true;
            }
            panelSettings.BringToFront();
            ActiveControl = null;
        }

        private void WMP_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {

            switch (e.newState)
            {
                case 0:    // Undefined
                    break;

                case 1:    // Stopped
                    buttonPlayPause.BackgroundImage = Properties.Resources.play;
                    timerMovie.Enabled = false;
                    break;

                case 2:    // Paused

                    break;

                case 3:    // Playing

                    break;

                case 4:    // ScanForward
                            //MessageBox.Show("ScanForward");

                    break;

                case 5:    // ScanReverse
                   // MessageBox.Show("ScanReverse");

                    break;

                case 6:    // Buffering
                    //MessageBox.Show("Buffering");

                    break;

                case 7:    // Waiting
                    //MessageBox.Show("Waiting");

                    break;

                case 8:    // MediaEnded
                    //MessageBox.Show("MediaEnded");
                    WMP.Ctlcontrols.currentPosition = 0;
                    trackBarMovie.Value =0;
                    labelTime.Text = $"{0}/{TimetoString(WMP.currentMedia.duration)}";
                    break;

                case 9:    // Transitioning
                           //MessageBox.Show("Transitioning");

                    break;

                case 10:   // Ready
                    labelInfo.Visible = true;
                    //MessageBox.Show("Ready");

                    break;

                case 11:   // Reconnecting
                   // MessageBox.Show("Reconnecting");

                    break;

                case 12:   // Last
                           //MessageBox.Show("Last");

                    break;

                default:
                    break;

            }

        }

        private void Connect()
        {
            try
            {
                if (connectServer == false)
                {
                    client = new TcpClient();
                    Msg();
                    client.Connect(IPAddress.Parse(textBoxIp.Text.Trim()), int.Parse(textBoxPort.Text.Trim()));
                    serverStream = client.GetStream();
                    SendMessege("/connect " + textBoxName.Text.Trim());
                    Thread ctThread = new Thread(GetMessage);
                    ctThread.Start();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }
        private async void Msg()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(Msg));
            }
            else
            {

                if (dataFromServer != null)
                    if (dataFromServer.Length > 0)
                    {
                        // обработка команд
                        string[] clientCommand = dataFromServer.Split();
                        if (clientCommand[0].Equals("/connect"))
                        {
                            Properties.Settings.Default.Ip = textBoxIp.Text.Trim();
                            Properties.Settings.Default.Port = textBoxPort.Text.Trim();
                            Properties.Settings.Default.Name = textBoxName.Text.Trim();
                            Properties.Settings.Default.Save();
                            connectServer = true;
                            textBoxLink.Enabled = true;
                            buttonConnect.Text = "Поделиться ссылкой";
                        }
                        else if (clientCommand[0].Equals("/disconnect"))
                        {
                            if (client != null) client.Close();
                            if (serverStream != null) serverStream.Close();
                            buttonConnect.Text = "Подключиться";
                        }
                        else if (clientCommand[0].Equals("/link"))
                        {
                            textBoxLink.Text = clientCommand[1];
                            if (await OkFileServer(textBoxLink.Text))
                            {
                                fileExist = true;
                                WMP.URL = textBoxLink.Text;
                            }
                            else
                            {
                                fileExist = false;
                                MessageBox.Show("Сайт недоступен");
                            } 
                        }
                        else if (clientCommand[0].Equals("/play"))
                        {
                            if (fileExist)
                            {
                                WMP.Ctlcontrols.currentPosition = Convert.ToDouble(clientCommand[1]);
                                PlayPouseWMP("/play", false);
                            }
                        }
                        else if (clientCommand[0].Equals("/pause"))
                        {
                            if (fileExist)
                            {
                                WMP.Ctlcontrols.currentPosition = Convert.ToDouble(clientCommand[1]);
                                PlayPouseWMP("/pause", false);
                            }
                        }

                    }
            }
        }
        private void GetMessage()
        {
            try
            {
                while (true)
                {
                    serverStream = client.GetStream();
                    string message = "";
                    byte[] bytesFrom = new byte[4];
                    serverStream.Read(bytesFrom, 0, 4);
                    string size = Encoding.UTF8.GetString(bytesFrom);
                    int sizeResidue = 0;
                    if (int.TryParse(size, out int size_message))
                    {

                        sizeResidue = size_message;
                        while (Encoding.UTF8.GetByteCount(message) != size_message)
                        {
                            string messageRead = "";
                            bytesFrom = new byte[sizeResidue];
                            serverStream.Read(bytesFrom, 0, sizeResidue);
                            messageRead += Encoding.UTF8.GetString(bytesFrom);
                            sizeResidue -= messageRead.Length;
                            message += messageRead;
                        }
                        dataFromServer = message;

                        Msg();
                    }
                    if (connectServer == false) break;
                }
            }
            catch (Exception ex)
            {
                client.Close();
                serverStream.Close();

            }
        }
        private void SendMessege(string message)
        {

            int Messagesize = Encoding.UTF8.GetByteCount(message);

            string size_str = "0";
            if (Messagesize.ToString().Length == 1) size_str = "000" + Messagesize;
            if (Messagesize.ToString().Length == 2) size_str = "00" + Messagesize;
            if (Messagesize.ToString().Length == 3) size_str = "0" + Messagesize;
            if (Messagesize.ToString().Length == 4) size_str = Messagesize.ToString();

            byte[] outStream = new byte[4];
            outStream = Encoding.UTF8.GetBytes(size_str);
            serverStream.Write(outStream, 0, outStream.Length);

            outStream = new byte[Messagesize];
            outStream = Encoding.UTF8.GetBytes(message);
            serverStream.Write(outStream, 0, outStream.Length);

        }

        private async void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (connectServer == false)
            {
                if (textBoxName.Text.Trim().Length > 0) Connect();
                else MessageBox.Show("Напишите свое имя");
            }
            else
            {
                if (textBoxLink.Text.Trim().Length > 0)
                {
                    if (await OkFileServer(textBoxLink.Text))
                    {
                        SendMessege("/link " + textBoxLink.Text.Trim());
                        WMP.URL = textBoxLink.Text;
                        fileExist = true;
                    }
                    else MessageBox.Show("Сайт недоступен");

                }
                else MessageBox.Show("Ссылка пустая");

            }
        }

        GlobalKeyboardHook space = new GlobalKeyboardHook();
        GlobalKeyboardHook esc = new GlobalKeyboardHook();
        GlobalKeyboardHook rewind = new GlobalKeyboardHook();
        GlobalKeyboardHook fastForward = new GlobalKeyboardHook();

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckVersion();

            if (File.Exists("Update Not Alone.exe") == false)
            {
                MessageBox.Show("Не найден файл Updater.exe. Попробуйте переустановить приложение", "Ошибка");
                Application.Exit();
            }
            trackBarSound.Value = WMP.settings.volume;

            space.HookedKeys.Add(Keys.Space);
            space.KeyDown += new KeyEventHandler(Gkh_KeyDownPouse);

            esc.HookedKeys.Add(Keys.Escape);
            esc.KeyDown += new KeyEventHandler(Gkh_KeyDownEsc);

            rewind.HookedKeys.Add(Keys.Left);
            rewind.KeyDown += new KeyEventHandler(Gkh_KeyDownRewind);

            fastForward.HookedKeys.Add(Keys.Right);
            fastForward.KeyDown += new KeyEventHandler(Gkh_KeyDownFastForward);

            textBoxIp.Text = Properties.Settings.Default.Ip;
            textBoxPort.Text = Properties.Settings.Default.Port;
            textBoxName.Text = Properties.Settings.Default.Name;

        }

        void Gkh_KeyDownEsc(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (WindowState == FormWindowState.Maximized) WindowState = FormWindowState.Normal;
        }
        void Gkh_KeyDownPouse(object sender, KeyEventArgs e)
        {
            if (activate && connectServer) PlayPouseWMP(GetStateWMP(), true);
        }
        void Gkh_KeyDownRewind(object sender, KeyEventArgs e)
        {
            if (activate && connectServer) SetCurrentPosition(WMP.Ctlcontrols.currentPosition - 5);
        }
        void Gkh_KeyDownFastForward(object sender, KeyEventArgs e)
        {
            if (activate && connectServer) SetCurrentPosition(WMP.Ctlcontrols.currentPosition + 5);
        }

        void SetCurrentPosition(double position)
        {
            WMP.Ctlcontrols.currentPosition = position;
            PlayPouseWMP("/play", true);
            trackBarMovie.Value = Convert.ToInt32(WMP.Ctlcontrols.currentPosition);
            labelTime.Text = $"{TimetoString(WMP.Ctlcontrols.currentPosition)}/{TimetoString(WMP.currentMedia.duration)}";
            ActiveControl = null;
        }
        private void ButtonPlayPause_Click(object sender, EventArgs e)
        {
            if (connectServer && fileExist)
                PlayPouseWMP(GetStateWMP(), true);
            ActiveControl = null;
        }

        private void PlayPouseWMP(string command, bool me)
        {
            if (command != null && fileExist)
                if (command.Equals("/play"))
                {
                    if (labelInfo.Visible == true) labelInfo.Visible = false;
                    if (me) SendMessege("/play " + WMP.Ctlcontrols.currentPosition);
                    buttonPlayPause.BackgroundImage = Properties.Resources.pouse;
                    WMP.Ctlcontrols.play();
                    timerMovie.Enabled = true;
                    trackBarMovie.Maximum = Convert.ToInt32(WMP.currentMedia.duration);
                    labelTime.Text = $"{TimetoString(WMP.Ctlcontrols.currentPosition)}/{TimetoString(WMP.currentMedia.duration)}";
                }
                else if (command.Equals("/pause"))
                {
                    if (me) SendMessege("/pause " + WMP.Ctlcontrols.currentPosition);
                    buttonPlayPause.BackgroundImage = Properties.Resources.play;
                    WMP.Ctlcontrols.pause();
                    timerMovie.Enabled = false;
                }
            ActiveControl = null;
        }

        private void TimerMovie_Tick(object sender, EventArgs e)
        {
            if (fileExist)
            {
                trackBarMovie.Maximum = Convert.ToInt32(WMP.currentMedia.duration);
                trackBarMovie.Value = Convert.ToInt32(WMP.Ctlcontrols.currentPosition);
                labelTime.Text = $"{TimetoString(WMP.Ctlcontrols.currentPosition)}/{TimetoString(WMP.currentMedia.duration)}";
            }
        }

        private string TimetoString(double time)
        {
            int s = Convert.ToInt32(Math.Truncate(time));
            int m = s / 60;
            int h = m / 60;
            s -= (m * 60 + h * 3600);
            return $"{h}:{m}:{s}";
        }

        private void TrackBarSound_ValueChanged(object sender, EventArgs e)
        {
            WMP.settings.volume = trackBarSound.Value;
        }

        private void TrackBarMovie_MouseDown(object sender, MouseEventArgs e)
        {
            if (connectServer && fileExist)
            {
                int max = trackBarMovie.Maximum;
                int width = trackBarMovie.Width - 10;
                int click = e.Location.X;
                if (trackBarMovie.Width / 2 > e.Location.X)
                {
                    click -= 5;
                }
                else if (trackBarMovie.Width / 2 < e.Location.X)
                {
                    click += 5;
                }
                SetCurrentPosition((click * max) / width);
            }
        }

        private void TrackBarSound_MouseDown(object sender, MouseEventArgs e)
        {
            int max = trackBarSound.Maximum;
            int width = trackBarSound.Width;
            int click = e.Location.X;
            trackBarSound.Value = (click * max) / width;
            ActiveControl = null;
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            if (connectServer == true)
            {
                connectServer = false;
                SendMessege("/disconnect");
            }
            Application.Exit();
        }

        private void ButtonMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            ActiveControl = null;
        }

        #region перемещяем форму по зажатой мышки

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MoveForm(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            MoveForm(e);
        }

        #endregion

        private void WMP_ClickEvent(object sender, _WMPOCXEvents_ClickEvent e)
        {
            PlayPouseWMP(GetStateWMP(), true);
        }

        private void ButtonScreen_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                buttonScreen.BackgroundImage = Properties.Resources.minScreen;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                buttonScreen.BackgroundImage = Properties.Resources.fullScreen;
            }
            ActiveControl = null;
        }

        private string GetStateWMP()
        {
            if (WMP.playState == WMPPlayState.wmppsPaused || WMP.playState == WMPPlayState.wmppsReady || WMP.playState == WMPPlayState.wmppsStopped || WMP.playState == WMPPlayState.wmppsMediaEnded)
            {
                return "/play";
            }
            else if (WMP.playState == WMPPlayState.wmppsPlaying)
            {
                return "/pause";
            }
            return null;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connectServer == true)
            {
                connectServer = false;
                SendMessege("/disconnect");
            }
            Application.Exit();
        }

        private void CheckVersion()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string result;
            WebClient webClient = new WebClient();
            try
            {
                Stream stream = webClient.OpenRead("https://raw.githubusercontent.com/Mr-Dan/Not-Alone/main/Version");
                StreamReader streamReader = new StreamReader(stream);
                result = streamReader.ReadToEnd();
                string[] content = result.Split('\n');
                string version = null;
                for (int i = 0; i < content.Length; i++)
                {
                    if (content[i].IndexOf("Version[") > -1)
                        version = GetValues(content[i], "Version");
                }
                if (Application.ProductVersion != version)
                {
                    if (File.Exists("Update Not Alone.exe"))
                    {
                        Process p = Process.Start("Update Not Alone.exe");
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        MessageBox.Show("Не найден файл Update Not Alone.exe. Попробуйте переустановить приложение", "Ошибка");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "Операция была отменена пользователем")
                {
                    MessageBox.Show("Ошибка подключения, повторите попытку позже", "Ошибка");
                }
            }
        }
        private string GetValues(string text, string type)
        {
            int start = text.IndexOf($"{type}[");
            int end = text.IndexOf($"]", start + 1);
            if (start == -1) return null;
            return text.Substring(start + type.Length + 1, end - start - type.Length - 1);
        }

        private void TextBoxLink_TextChanged(object sender, EventArgs e)
        {
            if (textBoxLink.Text.Length > 0 && connectServer == true)
                if (Regex.IsMatch(textBoxLink.Text.Trim(), @"(http:\/\/\S*)((.mp4)|(.mp3)|(.wav)|(.3gp)|(.avi)|(.mov)|(.flv)|(.wmv)|(.mpg))$") == false)
                {
                    textBoxLink.Text = "";
                    MessageBox.Show("Неправильная ссылка");
                }
        }

        bool activate = true;
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            activate = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            activate = true;
        }
        private async Task< bool> OkFileServer(string link)
        {
            try
            {
                buttonConnect.Enabled = false;
                buttonConnect.Text = "Подключение к файлу...";
                WebRequest request = WebRequest.Create(link);
                HttpWebResponse response =  (HttpWebResponse)await request.GetResponseAsync();
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                {
                    buttonConnect.Enabled = true;
                    buttonConnect.Text = "Поделиться";
                    return false;
                }
                response.Close();
                buttonConnect.Enabled = true;
                buttonConnect.Text = "Поделиться";
                return true;
            }
            catch
            {
                buttonConnect.Enabled = true;
                buttonConnect.Text = "Поделиться";
                return false;
            }
        }
    }

}
  