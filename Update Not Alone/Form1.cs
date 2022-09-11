using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Update_Not_Alone
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public void DirectoryDelete(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            try
            {
                if (Directory.Exists(path))
                    directory.Delete(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Предупреждение");
            }
        }

        private Task DownloadAppTask(string link, string version)
        {
            using (WebClient webClient = new WebClient())
            {
                return webClient.DownloadFileTaskAsync(link, $"Not Alone.zip");
            }
        }

        private async void buttonYes_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

            buttonNo.Visible = false;
            buttonYes.Visible = false;
            button_Close.Enabled = false;
            label1.Text = "Идет обновление";

            Process[] proc = Process.GetProcessesByName("Not Alone");
            if (proc.Length > 0) proc[0].Kill();

            if (File.Exists("Backup")) DirectoryDelete("Backup");
            Directory.CreateDirectory("Backup");
            string getContent = GetContent("https://raw.githubusercontent.com/Mr-Dan/Not-Alone/main/Version");
            string[] content = getContent.Split('\n');

            List<string> Files = new List<string>();
            string version = null;
            for (int i = 0; i < content.Length; i++)
            {  
                if(content[i].IndexOf("Files[") >-1)
                    Files = GetValues(content[i], "Files").Split(',').ToList();
                if (content[i].IndexOf("Version[") > -1)
                    version = GetValues(content[i], "Version");
            }
           
            for (int i = 0; i < Files.Count; i++)
            {
                if (File.Exists(Files[i])) File.Move(Files[i], $"Backup\\{Files[i]}");
            }
               
            try
            {
                await DownloadAppTask($"https://github.com/Mr-Dan/Not-Alone/releases/download/{version}/Not.Alone.zip",version);
            }
            catch
            {
                MoveFiles("Backup", Directory.GetCurrentDirectory(), Files);
                if (File.Exists("Backup")) DirectoryDelete("Backup");
                if (File.Exists("Not Alone.zip")) File.Delete("Not Alone.zip");
                MessageBox.Show("Ошибка подключения, повторите попытку позже", "Ошибка Not Alone");
                Application.Exit();
            }
            try
            {
                ZipFile.ExtractToDirectory($"Not Alone.zip", Directory.GetCurrentDirectory());
                MoveFiles($"Not Alone", Directory.GetCurrentDirectory(), Files);           
                Process.Start("Not Alone.exe");
                File.Delete($"Not Alone.zip");
                DirectoryDelete($"Not Alone");
                DirectoryDelete("Backup");
            }
            catch
            {

            }
            Application.Exit();
        }

        private void MoveFiles(string sourse, string dest, List<string> Files)
        {
            for (int i = 0; i < Files.Count; i++)
            {
                if (File.Exists($"{sourse}\\{Files[i]}"))
                    File.Move($"{sourse}\\{Files[i]}", $"{dest}\\{Files[i]}");
            }
        }
        private void buttonNo_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button_Resize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private string GetValues(string text, string type)
        {
            int start = text.IndexOf($"{type}[");
            int end = text.IndexOf($"]", start + 1);
            if (start == -1) return null;
            return text.Substring(start + type.Length + 1, end - start - type.Length - 1);
        }

        public string GetContent(string url)
        {
            string result = String.Empty;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            try
            {
                Stream stream = client.OpenRead(url);
                StreamReader reader = new StreamReader(stream);
                result = reader.ReadToEnd();
            }
            catch (Exception ex)
            {
            }
            return result;
        }
    }
}
