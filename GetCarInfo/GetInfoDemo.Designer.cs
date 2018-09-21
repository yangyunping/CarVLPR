namespace GetCarInfo
{
    partial class GetInfoDemo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDeIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDePortNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnAlarmChanEnd = new System.Windows.Forms.Button();
            this.btnAlarmChanB = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCarInfo = new System.Windows.Forms.TextBox();
            this.btnPic = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCarNO = new System.Windows.Forms.TextBox();
            this.btnListenEnd = new System.Windows.Forms.Button();
            this.btnListenBegin = new System.Windows.Forms.Button();
            this.picView = new System.Windows.Forms.PictureBox();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.btnCancelView = new System.Windows.Forms.Button();
            this.btnCancelPic = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDeIP
            // 
            this.txtDeIP.Location = new System.Drawing.Point(79, 38);
            this.txtDeIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDeIP.Name = "txtDeIP";
            this.txtDeIP.Size = new System.Drawing.Size(122, 26);
            this.txtDeIP.TabIndex = 0;
            this.txtDeIP.Text = "192.168.1.188";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备 IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "设备端口";
            // 
            // txtDePortNum
            // 
            this.txtDePortNum.Location = new System.Drawing.Point(80, 92);
            this.txtDePortNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDePortNum.Name = "txtDePortNum";
            this.txtDePortNum.Size = new System.Drawing.Size(121, 26);
            this.txtDePortNum.TabIndex = 2;
            this.txtDePortNum.Text = "8000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(230, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "用户名";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(288, 38);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(132, 26);
            this.txtUser.TabIndex = 4;
            this.txtUser.Text = "admin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 95);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "密   码";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(288, 92);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(132, 26);
            this.txtPwd.TabIndex = 6;
            this.txtPwd.Text = "emewe888888";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIP);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDeIP);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.txtDePortNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(455, 41);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "本机  IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(527, 38);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(133, 26);
            this.txtIP.TabIndex = 10;
            this.txtIP.Text = "192.168.1.121";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(524, 92);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(136, 26);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "7200";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(455, 95);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "本机端口";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(816, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 38);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "注  销";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(688, 86);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 38);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "登  录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancelPic);
            this.groupBox2.Controls.Add(this.btnCancelView);
            this.groupBox2.Controls.Add(this.btnAlarmChanEnd);
            this.groupBox2.Controls.Add(this.btnAlarmChanB);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCarInfo);
            this.groupBox2.Controls.Add(this.btnPic);
            this.groupBox2.Controls.Add(this.btnView);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCarNO);
            this.groupBox2.Controls.Add(this.btnListenEnd);
            this.groupBox2.Controls.Add(this.btnListenBegin);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(942, 116);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "操作栏";
            // 
            // btnAlarmChanEnd
            // 
            this.btnAlarmChanEnd.Enabled = false;
            this.btnAlarmChanEnd.Location = new System.Drawing.Point(164, 25);
            this.btnAlarmChanEnd.Name = "btnAlarmChanEnd";
            this.btnAlarmChanEnd.Size = new System.Drawing.Size(74, 33);
            this.btnAlarmChanEnd.TabIndex = 19;
            this.btnAlarmChanEnd.Text = "停止布防";
            this.btnAlarmChanEnd.UseVisualStyleBackColor = true;
            this.btnAlarmChanEnd.Click += new System.EventHandler(this.btnAlarmChanEnd_Click);
            // 
            // btnAlarmChanB
            // 
            this.btnAlarmChanB.Location = new System.Drawing.Point(59, 25);
            this.btnAlarmChanB.Name = "btnAlarmChanB";
            this.btnAlarmChanB.Size = new System.Drawing.Size(82, 33);
            this.btnAlarmChanB.TabIndex = 18;
            this.btnAlarmChanB.Text = "启动布防";
            this.btnAlarmChanB.UseVisualStyleBackColor = true;
            this.btnAlarmChanB.Click += new System.EventHandler(this.btnAlarmChanB_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "反馈信息";
            // 
            // txtCarInfo
            // 
            this.txtCarInfo.Location = new System.Drawing.Point(128, 74);
            this.txtCarInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCarInfo.Name = "txtCarInfo";
            this.txtCarInfo.Size = new System.Drawing.Size(337, 26);
            this.txtCarInfo.TabIndex = 16;
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(716, 25);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(74, 33);
            this.btnPic.TabIndex = 15;
            this.btnPic.Text = "截图";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.btnPic_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(516, 25);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(74, 33);
            this.btnView.TabIndex = 14;
            this.btnView.Text = "预览";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "车牌号码";
            // 
            // txtCarNO
            // 
            this.txtCarNO.Location = new System.Drawing.Point(585, 74);
            this.txtCarNO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCarNO.Name = "txtCarNO";
            this.txtCarNO.Size = new System.Drawing.Size(138, 26);
            this.txtCarNO.TabIndex = 12;
            // 
            // btnListenEnd
            // 
            this.btnListenEnd.Enabled = false;
            this.btnListenEnd.Location = new System.Drawing.Point(391, 25);
            this.btnListenEnd.Name = "btnListenEnd";
            this.btnListenEnd.Size = new System.Drawing.Size(74, 33);
            this.btnListenEnd.TabIndex = 11;
            this.btnListenEnd.Text = "停止监听";
            this.btnListenEnd.UseVisualStyleBackColor = true;
            this.btnListenEnd.Click += new System.EventHandler(this.btnListenEnd_Click);
            // 
            // btnListenBegin
            // 
            this.btnListenBegin.Location = new System.Drawing.Point(286, 25);
            this.btnListenBegin.Name = "btnListenBegin";
            this.btnListenBegin.Size = new System.Drawing.Size(82, 33);
            this.btnListenBegin.TabIndex = 9;
            this.btnListenBegin.Text = "启动监听";
            this.btnListenBegin.UseVisualStyleBackColor = true;
            this.btnListenBegin.Click += new System.EventHandler(this.btnListenBegin_Click);
            // 
            // picView
            // 
            this.picView.BackColor = System.Drawing.Color.White;
            this.picView.Dock = System.Windows.Forms.DockStyle.Left;
            this.picView.Location = new System.Drawing.Point(0, 257);
            this.picView.Name = "picView";
            this.picView.Size = new System.Drawing.Size(465, 384);
            this.picView.TabIndex = 10;
            this.picView.TabStop = false;
            // 
            // picImg
            // 
            this.picImg.BackColor = System.Drawing.Color.White;
            this.picImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picImg.Location = new System.Drawing.Point(465, 257);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(477, 384);
            this.picImg.TabIndex = 11;
            this.picImg.TabStop = false;
            // 
            // btnCancelView
            // 
            this.btnCancelView.Enabled = false;
            this.btnCancelView.Location = new System.Drawing.Point(596, 25);
            this.btnCancelView.Name = "btnCancelView";
            this.btnCancelView.Size = new System.Drawing.Size(80, 33);
            this.btnCancelView.TabIndex = 20;
            this.btnCancelView.Text = "取消预览";
            this.btnCancelView.UseVisualStyleBackColor = true;
            this.btnCancelView.Click += new System.EventHandler(this.btnCancelView_Click);
            // 
            // btnCancelPic
            // 
            this.btnCancelPic.Enabled = false;
            this.btnCancelPic.Location = new System.Drawing.Point(796, 25);
            this.btnCancelPic.Name = "btnCancelPic";
            this.btnCancelPic.Size = new System.Drawing.Size(74, 33);
            this.btnCancelPic.TabIndex = 21;
            this.btnCancelPic.Text = "取消截图";
            this.btnCancelPic.UseVisualStyleBackColor = true;
            this.btnCancelPic.Click += new System.EventHandler(this.btnCancelPic_Click);
            // 
            // GetInfoDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 641);
            this.Controls.Add(this.picImg);
            this.Controls.Add(this.picView);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "GetInfoDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息获取";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GetInfoDemo_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDePortNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox picView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCarNO;
        private System.Windows.Forms.Button btnListenEnd;
        private System.Windows.Forms.Button btnListenBegin;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.PictureBox picImg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCarInfo;
        private System.Windows.Forms.Button btnAlarmChanEnd;
        private System.Windows.Forms.Button btnAlarmChanB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancelView;
        private System.Windows.Forms.Button btnCancelPic;
    }
}

