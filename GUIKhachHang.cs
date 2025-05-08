using BUS;
using DTO;
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
    public partial class GUIKhachHang : Form
    {
        BUSKhachHang busKH = new BUSKhachHang();
        public GUIKhachHang()
        {
            InitializeComponent();
        }
        private void GUIKhachHang_Load(object sender, EventArgs e)
        {
            dgvKH.DataSource = busKH.getKhachHang();

            dgvKH.Columns[0].HeaderText = "Mã khách hàng";
            dgvKH.Columns[1].HeaderText = "Họ tên";
            dgvKH.Columns[2].HeaderText = "Giới tính";
            dgvKH.Columns[3].HeaderText = "Địa chỉ";
            dgvKH.Columns[4].HeaderText = "Số điện thoại";
            dgvKH.Columns[5].HeaderText = "Hạng khách hàng";

            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedIndex = 0;

            cbLevel.Items.Add("Thường");
            cbLevel.Items.Add("Thân thiết");
            cbLevel.Items.Add("VIP");
            cbLevel.SelectedIndex = 0;
        }
        private void GUIKhachHang_Click(object sender, EventArgs e)
        {
            dgvKH.ClearSelection();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
            cbGioiTinh.SelectedIndex = 0;
            cbLevel.SelectedIndex = 0;
        }
        private DTOKhachHang LayThongTinTuForm()
        {
            string maKH = txtMa.Text;
            string hoTen = txtHoTen.Text;
            string gioiTinh = cbGioiTinh.SelectedItem.ToString().Trim();
            string diaChi = txtDiaChi.Text;
            string sdt = txtSdt.Text;
            string hangKH = cbLevel.SelectedItem.ToString();
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(hangKH))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return null;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải là 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new DTOKhachHang(maKH, hoTen, gioiTinh, diaChi, sdt, hangKH);
        }
        /// <summary>
        /// CRUD 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var kh = LayThongTinTuForm();

            if (busKH.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (busKH.themKH(kh))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvKH.DataSource = busKH.getKhachHang();
                    }
                }
                catch 
                {
                    MessageBox.Show("Thêm thất bại", "Lỗi");
                }

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var kh = LayThongTinTuForm();

            if (kh == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (busKH.suaKH(kh))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvKH.DataSource = busKH.getKhachHang();
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
            var kh = LayThongTinTuForm();

            if (kh == null)
            {
                return;
            }
            else
            {
                try
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (busKH.xoaKH(kh))
                        {
                            MessageBox.Show("Xóa thành công");
                            dgvKH.DataSource = busKH.getKhachHang();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại", "Lỗi");
                }
            }

            ClearForm();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {

                int i = e.RowIndex;
                txtMa.Text = dgvKH.Rows[i].Cells[0].Value.ToString();
                txtHoTen.Text = dgvKH.Rows[i].Cells[1].Value.ToString();
                cbGioiTinh.SelectedItem = dgvKH.Rows[i].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvKH.Rows[i].Cells[3].Value.ToString();
                txtSdt.Text = dgvKH.Rows[i].Cells[4].Value.ToString();
                cbLevel.SelectedItem = dgvKH.Rows[i].Cells[5].Value.ToString();

               
            }
            else return;
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            dgvKH.ClearSelection();
        }
    }
}
