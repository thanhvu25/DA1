using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace DA1
{
    public partial class GUIKhuyenMai : Form
    {
        BUSKhuyenMai buskm = new BUSKhuyenMai();
        BUSSanPham bussp = new BUSSanPham();
        public GUIKhuyenMai()
        {
            InitializeComponent();
        }

        private void GUIKhuyenMai_Click(object sender, EventArgs e)
        {
            dgvKM.ClearSelection();
        }
        private void panel5_Click(object sender, EventArgs e)
        {
            dgvKM.ClearSelection();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtGiamGia.Clear();
            dtpBD.Value = DateTime.Now;
            dtpKT.Value = DateTime.Now;
        }
        private void GUIKhuyenMai_Load(object sender, EventArgs e)
        {
            dgvKM.DataSource = buskm.getKhuyenMai();

            dgvKM.Columns[0].HeaderText = "Mã khuyến mãi";
            dgvKM.Columns[1].HeaderText = "Mã sản phẩm";
            dgvKM.Columns[2].HeaderText = "Ngày bắt đầu";
            dgvKM.Columns[3].HeaderText = "Ngày kết thúc";
            dgvKM.Columns[4].HeaderText = "Giảm giá";

            cbSP.DataSource = bussp.getSanPham();
            cbSP.DisplayMember = "TenSP";
            cbSP.ValueMember = "MaSP";

            dtpBD.ValueChanged += dtpBD_ValueChanged;
            dtpKT.ValueChanged += dtpKT_ValueChanged;
        }
        /// <summary>
        /// Lấy thông tin từ form và kiểm tra dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private DTOKhuyenMai LayThongTinTuForm()
        {
            string MaKM = txtMa.Text;
            string MaSP = cbSP.SelectedValue.ToString();
            DateTime NgayBD = dtpBD.Value;
            DateTime NgayKT = dtpKT.Value;

            if (string.IsNullOrEmpty(MaSP) ||
                string.IsNullOrEmpty(dtpBD.Text) || string.IsNullOrEmpty(dtpKT.Text) ||
                string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Tất cả các trường thông tin phải được nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (!int.TryParse(txtGiamGia.Text.Trim(), out int GiamGia) || GiamGia <= 0)
            {
                MessageBox.Show("Giảm giá phải là một số nguyên dương hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return new DTOKhuyenMai(MaKM, MaSP, NgayBD, NgayKT, GiamGia);
        }

        private void dtpBD_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBD.Value > dtpKT.Value)
            {
                MessageBox.Show("Ngày bắt đầu phải trước hoặc bằng ngày kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBD.Value = dtpKT.Value;
            }
        }

        private void dtpKT_ValueChanged(object sender, EventArgs e)
        {
            if (dtpKT.Value < dtpBD.Value)
            {
                MessageBox.Show("Ngày kết thúc phải bằng hoặc sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpKT.Value = dtpBD.Value.AddDays(1);
            }
        }
        /// <summary>
        /// CRUD Khuyến mãi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var km = LayThongTinTuForm();

            if (buskm.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã khuyến mãi đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (buskm.themKM(km))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvKM.DataSource = buskm.getKhuyenMai();
                    }
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại", "Lỗi");
                }
                   
            }

            ClearForm();
        }
        private void dgvKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int i = e.RowIndex;
                txtMa.Text = dgvKM.Rows[i].Cells[0].Value.ToString();
                cbSP.SelectedValue = dgvKM.Rows[i].Cells[1].Value.ToString();
                dtpBD.Value = DateTime.Parse(dgvKM.Rows[i].Cells[2].Value.ToString());
                dtpKT.Value = DateTime.Parse(dgvKM.Rows[i].Cells[3].Value.ToString());
                txtGiamGia.Text = dgvKM.Rows[i].Cells[4].Value.ToString();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var km = LayThongTinTuForm();

            if (km == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (buskm.suaKM(km))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvKM.DataSource = buskm.getKhuyenMai();
                    }
                }              
                catch
                {
                    MessageBox.Show("Sửa thất bại", "Lỗi");
                }
            }
            
            ClearForm();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var km = LayThongTinTuForm();

            if (km == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (buskm.xoaKM(km))
                    {
                        MessageBox.Show("Xóa thành công");
                        dgvKM.DataSource = buskm.getKhuyenMai();
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }           

            ClearForm();
        }        
    }
}
