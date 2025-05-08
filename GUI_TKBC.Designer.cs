namespace DA1
{
    partial class GUI_TKBC
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
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSumUp = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumUp)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(114, 66);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(296, 27);
            this.dtpFrom.TabIndex = 0;
            // 
            // dgvReport
            // 
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 200);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(1139, 435);
            this.dgvReport.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(114, 110);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(296, 27);
            this.dtpTo.TabIndex = 0;
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(114, 22);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(296, 27);
            this.cbType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 33);
            this.label2.TabIndex = 14;
            this.label2.Text = "THỐNG KÊ, BÁO CÁO";
            // 
            // dgvSumUp
            // 
            this.dgvSumUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSumUp.BackgroundColor = System.Drawing.Color.Moccasin;
            this.dgvSumUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSumUp.Location = new System.Drawing.Point(0, 29);
            this.dgvSumUp.Name = "dgvSumUp";
            this.dgvSumUp.Size = new System.Drawing.Size(454, 116);
            this.dgvSumUp.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Chọn loại ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Location = new System.Drawing.Point(14, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 149);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(492, 95);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(154, 43);
            this.panel2.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Moccasin;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(-12, -9);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(177, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Xuất báo cáo";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAdd);
            this.panel4.Location = new System.Drawing.Point(492, 22);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(154, 43);
            this.panel4.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Moccasin;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(-12, -9);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(177, 62);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thống kê";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Từ ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvSumUp);
            this.groupBox1.Location = new System.Drawing.Point(697, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(454, 146);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tổng hợp";
            // 
            // GUI_TKBC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1163, 698);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvReport);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GUI_TKBC";
            this.Text = "GUI_TKBC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSumUp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSumUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}