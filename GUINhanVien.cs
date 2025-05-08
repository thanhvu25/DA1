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
    public partial class GUINhanVien : Form
    {
        BUSNhanVien busnv = new BUSNhanVien();
        public GUINhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Click(object sender, EventArgs e)
        {
            dgvNhanVien.ClearSelection();
        }
        private void panel5_Click(object sender, EventArgs e)
        {
            dgvNhanVien.ClearSelection();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
            txtLuongCB.Clear();
            cbGioiTinh.SelectedIndex = 0;
            cbVaiTro.SelectedIndex = 0;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = busnv.getNhanVien();

            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[6].HeaderText = "Lương cơ bản";

            // Thêm giá trị cho ComboBox 
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedIndex = 0;

            cbVaiTro.Items.Add("Nhân viên bán hàng");
            cbVaiTro.Items.Add("Nhân viên kho");
            cbVaiTro.SelectedIndex = 0;
        }


        /// <summary>
        /// Lấy thông tin từ form và kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        private DTONhanVien LayThongTinTuForm()
        {
            string MaNV = txtMa.Text;
            string TenNV = txtHoTen.Text;
            string GioiTinh = cbGioiTinh.SelectedItem.ToString();
            string DiaChi = txtDiaChi.Text;
            string Sdt = txtSdt.Text;
            string VaiTro = cbVaiTro.SelectedItem.ToString(); ;

            if (string.IsNullOrEmpty(TenNV) ||
                string.IsNullOrEmpty(GioiTinh) || string.IsNullOrEmpty(DiaChi) ||
                string.IsNullOrEmpty(Sdt) || string.IsNullOrEmpty(VaiTro))
            {
                MessageBox.Show("Tất cả các trường thông tin phải được nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(Sdt, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải là 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if (!int.TryParse(txtLuongCB.Text.Trim(), out int LuongCB) || LuongCB <= 0) //validate data cho LuongCB
            {
                MessageBox.Show("Lương cơ bản phải là một số nguyên dương hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new DTONhanVien(MaNV, TenNV, GioiTinh, DiaChi, Sdt, VaiTro, LuongCB);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int i = e.RowIndex;
                txtMa.Text = dgvNhanVien.Rows[i].Cells[0].Value.ToString();
                txtHoTen.Text = dgvNhanVien.Rows[i].Cells[1].Value.ToString();
                cbGioiTinh.SelectedItem = dgvNhanVien.Rows[i].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.Rows[i].Cells[3].Value.ToString();
                txtSdt.Text = dgvNhanVien.Rows[i].Cells[4].Value.ToString();
                cbVaiTro.SelectedItem = dgvNhanVien.Rows[i].Cells[5].Value.ToString();
                txtLuongCB.Text = dgvNhanVien.Rows[i].Cells[6].Value.ToString();
            }
        }

        /// <summary>
        /// CRUD Nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var nv = LayThongTinTuForm();

            if (busnv.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (busnv.themNV(nv))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvNhanVien.DataSource = busnv.getNhanVien();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Thêm thất bại: {ex.Message}", "Lỗi");
                }

            }
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var nv = LayThongTinTuForm();
            if (nv == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (busnv.suaNV(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvNhanVien.DataSource = busnv.getNhanVien();
                    }
                }
                catch (Exception ex)
                { 
                    MessageBox.Show($"Sửa thất bại: {ex.Message}", "Lỗi"); 
                }

            }    
            
            ClearForm();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var nv = LayThongTinTuForm();
            if (nv == null)
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
                        if (busnv.xoaNV(nv))
                        {
                            MessageBox.Show("Xóa thành công");
                            dgvNhanVien.DataSource = busnv.getNhanVien();
                        }
                        
                    }
                }
                catch (Exception ex)
                { 
                    MessageBox.Show($"Xóa thất bại: {ex.Message}", "Lỗi"); 
                }
                    
            }
                
            ClearForm();
        }  
    }
}
