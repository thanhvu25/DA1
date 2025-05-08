using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace DA1
{
    public partial class GUILogin : Form
    {
        public GUILogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "ad" && txtPass.Text == "ad")
            {
                Main mainForm = new Main();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK);
            }
        }

    }
}
