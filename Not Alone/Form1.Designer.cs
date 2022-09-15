
namespace Not_Alone
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelSettings = new System.Windows.Forms.Panel();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIp = new System.Windows.Forms.TextBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBarMovie = new System.Windows.Forms.TrackBar();
            this.labelTime = new System.Windows.Forms.Label();
            this.buttonScreen = new System.Windows.Forms.Button();
            this.panelSound = new System.Windows.Forms.Panel();
            this.trackBarSound = new System.Windows.Forms.TrackBar();
            this.buttonSound = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelWMP = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.WMP = new AxWMPLib.AxWindowsMediaPlayer();
            this.timerMovie = new System.Windows.Forms.Timer(this.components);
            this.panelSettings.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMovie)).BeginInit();
            this.panelSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).BeginInit();
            this.panelTitle.SuspendLayout();
            this.panelWMP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSettings
            // 
            this.panelSettings.Controls.Add(this.buttonConnect);
            this.panelSettings.Controls.Add(this.label4);
            this.panelSettings.Controls.Add(this.textBoxLink);
            this.panelSettings.Controls.Add(this.label3);
            this.panelSettings.Controls.Add(this.label2);
            this.panelSettings.Controls.Add(this.label1);
            this.panelSettings.Controls.Add(this.textBoxName);
            this.panelSettings.Controls.Add(this.textBoxPort);
            this.panelSettings.Controls.Add(this.textBoxIp);
            this.panelSettings.Location = new System.Drawing.Point(297, 182);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(200, 200);
            this.panelSettings.TabIndex = 5;
            this.panelSettings.Visible = false;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(3, 168);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(194, 23);
            this.buttonConnect.TabIndex = 8;
            this.buttonConnect.Text = "Подключиться";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.ButtonConnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ссылка";
            // 
            // textBoxLink
            // 
            this.textBoxLink.Enabled = false;
            this.textBoxLink.Location = new System.Drawing.Point(3, 129);
            this.textBoxLink.Multiline = true;
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(177, 21);
            this.textBoxLink.TabIndex = 6;
            this.textBoxLink.TextChanged += new System.EventHandler(this.TextBoxLink_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ip";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(40, 80);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(140, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(40, 50);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(140, 20);
            this.textBoxPort.TabIndex = 1;
            // 
            // textBoxIp
            // 
            this.textBoxIp.Location = new System.Drawing.Point(40, 20);
            this.textBoxIp.Name = "textBoxIp";
            this.textBoxIp.Size = new System.Drawing.Size(140, 20);
            this.textBoxIp.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Silver;
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMenu.Location = new System.Drawing.Point(0, 560);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(800, 40);
            this.panelMenu.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.trackBarMovie);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.buttonScreen);
            this.panel1.Controls.Add(this.panelSound);
            this.panel1.Controls.Add(this.buttonSettings);
            this.panel1.Controls.Add(this.buttonPlayPause);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 40);
            this.panel1.TabIndex = 26;
            // 
            // trackBarMovie
            // 
            this.trackBarMovie.BackColor = System.Drawing.SystemColors.GrayText;
            this.trackBarMovie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarMovie.LargeChange = 0;
            this.trackBarMovie.Location = new System.Drawing.Point(40, 0);
            this.trackBarMovie.Name = "trackBarMovie";
            this.trackBarMovie.Size = new System.Drawing.Size(408, 40);
            this.trackBarMovie.SmallChange = 0;
            this.trackBarMovie.TabIndex = 27;
            this.trackBarMovie.TabStop = false;
            this.trackBarMovie.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarMovie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackBarMovie_MouseDown);
            // 
            // labelTime
            // 
            this.labelTime.BackColor = System.Drawing.SystemColors.GrayText;
            this.labelTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.ForeColor = System.Drawing.SystemColors.Control;
            this.labelTime.Location = new System.Drawing.Point(448, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(122, 40);
            this.labelTime.TabIndex = 26;
            this.labelTime.Text = "00:00:00/00:00:00";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonScreen
            // 
            this.buttonScreen.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonScreen.BackgroundImage")));
            this.buttonScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonScreen.FlatAppearance.BorderSize = 0;
            this.buttonScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonScreen.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonScreen.Location = new System.Drawing.Point(570, 0);
            this.buttonScreen.Name = "buttonScreen";
            this.buttonScreen.Size = new System.Drawing.Size(40, 40);
            this.buttonScreen.TabIndex = 27;
            this.buttonScreen.TabStop = false;
            this.buttonScreen.UseVisualStyleBackColor = false;
            this.buttonScreen.Click += new System.EventHandler(this.ButtonScreen_Click);
            // 
            // panelSound
            // 
            this.panelSound.Controls.Add(this.trackBarSound);
            this.panelSound.Controls.Add(this.buttonSound);
            this.panelSound.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSound.Location = new System.Drawing.Point(610, 0);
            this.panelSound.Name = "panelSound";
            this.panelSound.Size = new System.Drawing.Size(150, 40);
            this.panelSound.TabIndex = 25;
            // 
            // trackBarSound
            // 
            this.trackBarSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBarSound.LargeChange = 0;
            this.trackBarSound.Location = new System.Drawing.Point(40, 0);
            this.trackBarSound.Maximum = 100;
            this.trackBarSound.Name = "trackBarSound";
            this.trackBarSound.Size = new System.Drawing.Size(110, 40);
            this.trackBarSound.SmallChange = 0;
            this.trackBarSound.TabIndex = 27;
            this.trackBarSound.TabStop = false;
            this.trackBarSound.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarSound.ValueChanged += new System.EventHandler(this.TrackBarSound_ValueChanged);
            this.trackBarSound.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrackBarSound_MouseDown);
            // 
            // buttonSound
            // 
            this.buttonSound.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonSound.BackgroundImage = global::Not_Alone.Properties.Resources.sound;
            this.buttonSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSound.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonSound.FlatAppearance.BorderSize = 0;
            this.buttonSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSound.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSound.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSound.Location = new System.Drawing.Point(0, 0);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(40, 40);
            this.buttonSound.TabIndex = 26;
            this.buttonSound.TabStop = false;
            this.buttonSound.UseVisualStyleBackColor = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonSettings.BackgroundImage = global::Not_Alone.Properties.Resources.settings;
            this.buttonSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSettings.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSettings.Location = new System.Drawing.Point(760, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(40, 40);
            this.buttonSettings.TabIndex = 26;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.Button1_Click);
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonPlayPause.BackgroundImage = global::Not_Alone.Properties.Resources.play;
            this.buttonPlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPlayPause.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlayPause.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonPlayPause.Location = new System.Drawing.Point(0, 0);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(40, 40);
            this.buttonPlayPause.TabIndex = 22;
            this.buttonPlayPause.TabStop = false;
            this.buttonPlayPause.UseVisualStyleBackColor = false;
            this.buttonPlayPause.Click += new System.EventHandler(this.ButtonPlayPause_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.GrayText;
            this.panelTitle.Controls.Add(this.buttonMin);
            this.panelTitle.Controls.Add(this.buttonClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(800, 25);
            this.panelTitle.TabIndex = 6;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            // 
            // buttonMin
            // 
            this.buttonMin.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonMin.BackgroundImage = global::Not_Alone.Properties.Resources.mini;
            this.buttonMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMin.FlatAppearance.BorderSize = 0;
            this.buttonMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonMin.Location = new System.Drawing.Point(750, 0);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(25, 25);
            this.buttonMin.TabIndex = 21;
            this.buttonMin.TabStop = false;
            this.buttonMin.UseVisualStyleBackColor = false;
            this.buttonMin.Click += new System.EventHandler(this.ButtonMin_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.SystemColors.GrayText;
            this.buttonClose.BackgroundImage = global::Not_Alone.Properties.Resources.close;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClose.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonClose.Location = new System.Drawing.Point(775, 0);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(25, 25);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.TabStop = false;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // panelWMP
            // 
            this.panelWMP.Controls.Add(this.panelSettings);
            this.panelWMP.Controls.Add(this.labelInfo);
            this.panelWMP.Controls.Add(this.WMP);
            this.panelWMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWMP.Location = new System.Drawing.Point(0, 25);
            this.panelWMP.Name = "panelWMP";
            this.panelWMP.Size = new System.Drawing.Size(800, 535);
            this.panelWMP.TabIndex = 7;
            // 
            // labelInfo
            // 
            this.labelInfo.BackColor = System.Drawing.SystemColors.GrayText;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInfo.ForeColor = System.Drawing.SystemColors.Control;
            this.labelInfo.Location = new System.Drawing.Point(-3, 514);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(50, 21);
            this.labelInfo.TabIndex = 28;
            this.labelInfo.Text = "Готово";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelInfo.Visible = false;
            // 
            // WMP
            // 
            this.WMP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WMP.Enabled = true;
            this.WMP.Location = new System.Drawing.Point(0, 0);
            this.WMP.Name = "WMP";
            this.WMP.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMP.OcxState")));
            this.WMP.Size = new System.Drawing.Size(800, 535);
            this.WMP.TabIndex = 29;
            this.WMP.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.WMP_PlayStateChange);
            this.WMP.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.WMP_ClickEvent);
            // 
            // timerMovie
            // 
            this.timerMovie.Interval = 1000;
            this.timerMovie.Tick += new System.EventHandler(this.TimerMovie_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.panelWMP);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Not Alone";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMovie)).EndInit();
            this.panelSound.ResumeLayout(false);
            this.panelSound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSound)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelWMP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WMP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIp;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelWMP;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSound;
        private System.Windows.Forms.TrackBar trackBarSound;
        private System.Windows.Forms.Button buttonSound;
        private System.Windows.Forms.Timer timerMovie;
        private System.Windows.Forms.TrackBar trackBarMovie;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Button buttonScreen;
        private System.Windows.Forms.Label labelInfo;
        private AxWMPLib.AxWindowsMediaPlayer WMP;
    }
}

