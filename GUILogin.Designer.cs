namespace DA1
{
    partial class GUILogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUILogin));
            this.label1 = new System.Windows.Forms.Label();
            this.llbForget = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên tài khoản";
            // 
            // llbForget
            // 
            this.llbForget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbForget.AutoSize = true;
            this.llbForget.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbForget.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.llbForget.Location = new System.Drawing.Point(291, 95);
            this.llbForget.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llbForget.Name = "llbForget";
            this.llbForget.Size = new System.Drawing.Size(100, 16);
            this.llbForget.TabIndex = 3;
            this.llbForget.TabStop = true;
            this.llbForget.Text = "Quên mật khẩu?";
            this.llbForget.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mật khẩu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPass);
            this.panel1.Controls.Add(this.llbForget);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.txtUser);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(268, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 190);
            this.panel1.TabIndex = 4;
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.Location = new System.Drawing.Point(122, 57);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(269, 28);
            this.txtPass.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Location = new System.Drawing.Point(11, 131);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 43);
            this.panel2.TabIndex = 5;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(-12, -9);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(177, 62);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnLog);
            this.panel6.Location = new System.Drawing.Point(237, 131);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(154, 43);
            this.panel6.TabIndex = 2;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Moccasin;
            this.btnLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLog.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Location = new System.Drawing.Point(-12, -9);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(177, 62);
            this.btnLog.TabIndex = 0;
            this.btnLog.Text = "Đăng nhập";
            this.btnLog.UseVisualStyleBackColor = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.Location = new System.Drawing.Point(122, 5);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(269, 28);
            this.txtUser.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(384, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "ĐĂNG NHẬP";
            // 
            // GUILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(727, 267);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUILogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel llbForget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}