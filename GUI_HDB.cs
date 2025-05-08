using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Data.SqlClient;

namespace DA1
{
    public partial class GUI_HDB : Form
    {
        BUS_HDB busHDB = new BUS_HDB();
        BUS_CtHDB busCtHDB = new BUS_CtHDB();

        BUSNhanVien busnv = new BUSNhanVien();
        BUSSanPham bussp = new BUSSanPham();
        BUSKhachHang buskh = new BUSKhachHang();
        public GUI_HDB()
        {
            InitializeComponent();
        }
        private void GUI_HDB_Load(object sender, EventArgs e)
        {
            dgvHDB.DataSource = busHDB.getHDB();

            dgvHDB.Columns[0].HeaderText = "Mã hóa đơn bán";
            dgvHDB.Columns[1].HeaderText = "Ngày bán";
            dgvHDB.Columns[2].HeaderText = "Tổng tiền";

            dgvCt.DataSource = busCtHDB.getCtHDB();
            dgvCt.Columns[0].HeaderText = "Mã hóa đơn bán";
            dgvCt.Columns[1].HeaderText = "Mã sản phẩm";
            dgvCt.Columns[2].HeaderText = "Mã nhân viên";
            dgvCt.Columns[3].HeaderText = "Mã khách hàng";
            dgvCt.Columns[4].HeaderText = "Số lượng";

            cbNV.DataSource = busnv.getNhanVien();
            cbNV.DisplayMember = "TenNV";
            cbNV.ValueMember = "MaNV";

            cbSP.DataSource = bussp.getSanPham();
            cbSP.DisplayMember = "TenSP";
            cbSP.ValueMember = "MaSP";

            cbKH.DataSource = buskh.getKhachHang();
            cbKH.DisplayMember = "TenKH";
            cbKH.ValueMember = "MaKH";
        }
        private void GUI_HDB_Click(object sender, EventArgs e)
        {
            dgvHDB.ClearSelection();
            dgvCt.ClearSelection();
        }
        /// <summary>
        /// CRUD HDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMa.Text;
            DateTime NgayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            int DonGia = int.Parse(txtDonGia.Text);

            DTO_HDB hdb = new DTO_HDB(MaHDB, NgayBan, DonGia);

            if (busHDB.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (busHDB.themHDB(hdb))
                {
                    MessageBox.Show("Thêm hóa đơn bán thành công");
                    dgvHDB.DataSource = busHDB.getHDB();
                }
                else
                {
                    MessageBox.Show("Thêm hóa đơn bán thất bại");
                }
            }
        }
        private void dgvHDB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMa.Text = dgvHDB.Rows[i].Cells[0].Value.ToString();
            dtpNgayBan.Value = DateTime.Parse(dgvHDB.Rows[i].Cells[1].Value.ToString());
            txtDonGia.Text = dgvHDB.Rows[i].Cells[2].Value.ToString();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMa.Text;
            DateTime NgayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            int DonGia = int.Parse(txtDonGia.Text);

            DTO_HDB hdb = new DTO_HDB(MaHDB, NgayBan, DonGia);

            if (busHDB.suaHDB(hdb))
            {
                MessageBox.Show("Sửa hóa đơn bán thành công");
                dgvHDB.DataSource = busHDB.getHDB();
            }
            else
            {
                MessageBox.Show("Sửa hóa đơn bán thất bại");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMa.Text;
            DateTime NgayBan = DateTime.Parse(dtpNgayBan.Value.ToShortDateString());
            int DonGia = int.Parse(txtDonGia.Text);

            DTO_HDB hdb = new DTO_HDB(MaHDB, NgayBan, DonGia);

            if (busHDB.xoaHDB(hdb))
            {
                MessageBox.Show("Xóa hóa đơn bán thành công");
                dgvHDB.DataSource = busHDB.getHDB();
            }
            else
            {
                MessageBox.Show("Xóa hóa đơn bán thất bại");
            }
        }
        /// <summary>
        /// CRUD CT HDB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCt_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMaCt.Text;
            string MaSP = cbSP.SelectedValue.ToString();
            string MaNV = cbNV.SelectedValue.ToString();
            string MaKH = cbKH.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSL.Text);

            DTO_CtHDB cthdb = new DTO_CtHDB(MaHDB, MaSP, MaKH, SoLuong, MaNV);

            if (busCtHDB.KiemTraMaTrung(txtMaCt.Text) == 1)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (busCtHDB.themCtHDB(cthdb))
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn bán thành công");
                    dgvCt.DataSource = busCtHDB.getCtHDB();
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn bán thất bại");
                }
            }
        }
        private void dgvCt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMaCt.Text = dgvCt.Rows[i].Cells[0].Value.ToString();
            cbSP.SelectedValue = dgvCt.Rows[i].Cells[1].Value.ToString();
            cbNV.SelectedValue = dgvCt.Rows[i].Cells[2].Value.ToString();
            cbKH.SelectedValue = dgvCt.Rows[i].Cells[3].Value.ToString();
            txtSL.Text = dgvCt.Rows[i].Cells[4].Value.ToString();
        }

        private void btnEditCt_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMaCt.Text;
            string MaSP = cbSP.SelectedValue.ToString();
            string MaNV = cbNV.SelectedValue.ToString();
            string MaKH = cbKH.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSL.Text);

            DTO_CtHDB cthdb = new DTO_CtHDB(MaHDB, MaSP, MaKH, SoLuong, MaNV);

            if (busCtHDB.suaCtHDB(cthdb))
            {
                MessageBox.Show("Sửa chi tiết hóa đơn bán thành công");
                dgvCt.DataSource = busCtHDB.getCtHDB();
            }
            else
            {
                MessageBox.Show("Sửa chi tiết hóa đơn bán thất bại");
            }
        }

        private void btnDelCt_Click(object sender, EventArgs e)
        {
            string MaHDB = txtMaCt.Text;
            string MaSP = cbSP.SelectedValue.ToString();
            string MaNV = cbNV.SelectedValue.ToString();
            string MaKH = cbKH.SelectedValue.ToString();
            int SoLuong = int.Parse(txtSL.Text);

            DTO_CtHDB cthdb = new DTO_CtHDB(MaHDB, MaSP, MaKH, SoLuong, MaNV);

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (busCtHDB.xoaCtHDB(cthdb))
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn bán thành công");
                    dgvCt.DataSource = busCtHDB.getCtHDB();
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn bán thất bại");
                }
            }
        }


    }
}
