namespace KKTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cboxService = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboxVoice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboxSpeed = new System.Windows.Forms.ComboBox();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserHistoryRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserExit = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnTrịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminAvailableServiceTTS = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdminRequestResponse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvHistoryQuery = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxDownloadSound = new System.Windows.Forms.CheckBox();
            this.lblConnection = new System.Windows.Forms.Label();
            this.timerCheckInternet = new System.Windows.Forms.Timer(this.components);
            this.wmpMain = new AxWMPLib.AxWindowsMediaPlayer();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(203, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập đoạn văn:";
            // 
            // txtInput
            // 
            this.txtInput.AllowDrop = true;
            this.txtInput.Location = new System.Drawing.Point(32, 51);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(436, 248);
            this.txtInput.TabIndex = 1;
            // 
            // cboxService
            // 
            this.cboxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxService.FormattingEnabled = true;
            this.cboxService.Location = new System.Drawing.Point(138, 311);
            this.cboxService.Name = "cboxService";
            this.cboxService.Size = new System.Drawing.Size(190, 27);
            this.cboxService.TabIndex = 2;
            this.cboxService.SelectedIndexChanged += new System.EventHandler(this.cboxService_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nội dung phát:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giọng nói:";
            // 
            // cboxVoice
            // 
            this.cboxVoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVoice.FormattingEnabled = true;
            this.cboxVoice.Location = new System.Drawing.Point(138, 352);
            this.cboxVoice.Name = "cboxVoice";
            this.cboxVoice.Size = new System.Drawing.Size(190, 27);
            this.cboxVoice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tốc độ:";
            // 
            // cboxSpeed
            // 
            this.cboxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSpeed.FormattingEnabled = true;
            this.cboxSpeed.Location = new System.Drawing.Point(138, 399);
            this.cboxSpeed.Name = "cboxSpeed";
            this.cboxSpeed.Size = new System.Drawing.Size(190, 27);
            this.cboxSpeed.TabIndex = 2;
            // 
            // btnSpeak
            // 
            this.btnSpeak.Location = new System.Drawing.Point(354, 311);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(114, 49);
            this.btnSpeak.TabIndex = 3;
            this.btnSpeak.Text = "Tạo giọng nói";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // btnRepeat
            // 
            this.btnRepeat.Location = new System.Drawing.Point(589, 402);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(170, 37);
            this.btnRepeat.TabIndex = 3;
            this.btnRepeat.Text = "Nghe lại";
            this.btnRepeat.UseVisualStyleBackColor = true;
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStripMain.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quảnTrịToolStripMenuItem,
            this.menuHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(6, 1, 0, 1);
            this.menuStripMain.Size = new System.Drawing.Size(870, 25);
            this.menuStripMain.TabIndex = 4;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUserHistoryRequest,
            this.menuUserExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(45, 23);
            this.fileToolStripMenuItem.Text = "Tệp";
            // 
            // menuUserHistoryRequest
            // 
            this.menuUserHistoryRequest.Name = "menuUserHistoryRequest";
            this.menuUserHistoryRequest.Size = new System.Drawing.Size(175, 24);
            this.menuUserHistoryRequest.Text = "Lịch sử truy vấn";
            // 
            // menuUserExit
            // 
            this.menuUserExit.Name = "menuUserExit";
            this.menuUserExit.Size = new System.Drawing.Size(175, 24);
            this.menuUserExit.Text = "Thoát";
            // 
            // quảnTrịToolStripMenuItem
            // 
            this.quảnTrịToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdminAvailableServiceTTS,
            this.menuAdminRequestResponse});
            this.quảnTrịToolStripMenuItem.Name = "quảnTrịToolStripMenuItem";
            this.quảnTrịToolStripMenuItem.Size = new System.Drawing.Size(70, 23);
            this.quảnTrịToolStripMenuItem.Text = "Quản trị";
            // 
            // menuAdminAvailableServiceTTS
            // 
            this.menuAdminAvailableServiceTTS.Name = "menuAdminAvailableServiceTTS";
            this.menuAdminAvailableServiceTTS.Size = new System.Drawing.Size(216, 24);
            this.menuAdminAvailableServiceTTS.Text = "Dịch vụ TTS";
            // 
            // menuAdminRequestResponse
            // 
            this.menuAdminRequestResponse.Name = "menuAdminRequestResponse";
            this.menuAdminRequestResponse.Size = new System.Drawing.Size(216, 24);
            this.menuAdminRequestResponse.Text = "Request and Response";
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpGuide,
            this.menuHelpVersion});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(70, 23);
            this.menuHelp.Text = "Giúp đỡ";
            // 
            // menuHelpGuide
            // 
            this.menuHelpGuide.Name = "menuHelpGuide";
            this.menuHelpGuide.Size = new System.Drawing.Size(198, 24);
            this.menuHelpGuide.Text = "Hướng dẫn sử dụng";
            // 
            // menuHelpVersion
            // 
            this.menuHelpVersion.Name = "menuHelpVersion";
            this.menuHelpVersion.Size = new System.Drawing.Size(198, 24);
            this.menuHelpVersion.Text = "Phiên bản";
            // 
            // dgvHistoryQuery
            // 
            this.dgvHistoryQuery.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHistoryQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoryQuery.Location = new System.Drawing.Point(491, 51);
            this.dgvHistoryQuery.Name = "dgvHistoryQuery";
            this.dgvHistoryQuery.Size = new System.Drawing.Size(367, 205);
            this.dgvHistoryQuery.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(600, 311);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "content";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn dịch vụ:";
            // 
            // checkBoxDownloadSound
            // 
            this.checkBoxDownloadSound.AutoSize = true;
            this.checkBoxDownloadSound.Checked = true;
            this.checkBoxDownloadSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDownloadSound.Location = new System.Drawing.Point(354, 375);
            this.checkBoxDownloadSound.Name = "checkBoxDownloadSound";
            this.checkBoxDownloadSound.Size = new System.Drawing.Size(83, 23);
            this.checkBoxDownloadSound.TabIndex = 6;
            this.checkBoxDownloadSound.Text = "Có tải về";
            this.checkBoxDownloadSound.UseVisualStyleBackColor = true;
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.ForeColor = System.Drawing.Color.Green;
            this.lblConnection.Location = new System.Drawing.Point(28, 436);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(145, 19);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Đang có kết nối mạng.";
            // 
            // timerCheckInternet
            // 
            this.timerCheckInternet.Interval = 60000;
            this.timerCheckInternet.Tick += new System.EventHandler(this.timerCheckInternet_Tick);
            // 
            // wmpMain
            // 
            this.wmpMain.Enabled = true;
            this.wmpMain.Location = new System.Drawing.Point(500, 350);
            this.wmpMain.Name = "wmpMain";
            this.wmpMain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpMain.OcxState")));
            this.wmpMain.Size = new System.Drawing.Size(348, 46);
            this.wmpMain.TabIndex = 7;
            this.wmpMain.Enter += new System.EventHandler(this.wmpMain_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(624, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lịch sử truy vấn";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 464);
            this.Controls.Add(this.wmpMain);
            this.Controls.Add(this.checkBoxDownloadSound);
            this.Controls.Add(this.dgvHistoryQuery);
            this.Controls.Add(this.btnRepeat);
            this.Controls.Add(this.btnSpeak);
            this.Controls.Add(this.cboxSpeed);
            this.Controls.Add(this.cboxVoice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboxService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStripMain);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trợ lý âm thanh";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.ComboBox cboxService;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboxVoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboxSpeed;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnTrịToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAdminAvailableServiceTTS;
        private System.Windows.Forms.ToolStripMenuItem menuAdminRequestResponse;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuUserHistoryRequest;
        private System.Windows.Forms.ToolStripMenuItem menuUserExit;
        private System.Windows.Forms.ToolStripMenuItem menuHelpGuide;
        private System.Windows.Forms.ToolStripMenuItem menuHelpVersion;
        private System.Windows.Forms.DataGridView dgvHistoryQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxDownloadSound;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Timer timerCheckInternet;
        private AxWMPLib.AxWindowsMediaPlayer wmpMain;
        private System.Windows.Forms.Label label7;
    }
}

