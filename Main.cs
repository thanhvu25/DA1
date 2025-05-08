using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            pnSubMenu.Visible = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private Form activeForm = null;

        private void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            DisableControls();  // Disable các control khác

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnContainer.Controls.Add(childForm);
            pnContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
                EnableControls();
            }
        }
        private void btnHD_Click(object sender, EventArgs e)
        {
            pnSubMenu.Visible = !pnSubMenu.Visible;
        }
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUIBanHang());
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUISanPham());
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUIKhachHang());
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUIKhuyenMai());
        }

        private void btnTH_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUIThuongHieu());
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUINhanVien());
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUIKhoHang());
        }
        private void btnTKBC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI_TKBC());
        }
        private void btnHDN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI_HDN());
            pnSubMenu.Visible = !pnSubMenu.Visible;
        }

        private void btnHDB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new GUI_HDB());
            pnSubMenu.Visible = !pnSubMenu.Visible;
        }
        private void DisableControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != btnCloseForm && ctrl != pnCloseForm && ctrl != pnContainer)
                {
                    ctrl.Enabled = false;
                }
            }
            btnCloseForm.Enabled = true;
        }
        private void EnableControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = true;
            }
        }    
    }
}
