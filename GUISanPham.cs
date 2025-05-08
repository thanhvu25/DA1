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
    public partial class GUISanPham : Form
    {
        BUSSanPham BUSSanPham = new BUSSanPham();
        BUSThuongHieu BUSThuongHieu = new BUSThuongHieu();
        public GUISanPham()
        {
            InitializeComponent();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtGiaBan.Clear();
            cbTH.SelectedIndex = 0;
        }
        private void GUISanPham_Load(object sender, EventArgs e)
        {
            dgvSP.DataSource = BUSSanPham.getSanPham();

            dgvSP.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSP.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSP.Columns[2].HeaderText = "Thương hiệu";
            dgvSP.Columns[3].HeaderText = "Giá bán";
            dgvSP.Columns[4].HeaderText = "Số lượng tồn";

            cbTH.DataSource = BUSThuongHieu.getThuongHieu(); //lấy dữ liệu từ bảng TH
            cbTH.DisplayMember = "TenTH";
            cbTH.ValueMember = "MaTH";
        }
        private void GUISanPham_Click(object sender, EventArgs e)
        {
            dgvSP.ClearSelection();
        }
        /// <summary>
        /// Lấy thông tin từ form và kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        private DTOSanPham LayThongTinTuForm()
        {
            string MaSP = txtMa.Text;
            string TenSP = txtTen.Text;
            string MaTH = cbTH.SelectedValue.ToString();
           
            if (string.IsNullOrEmpty(TenSP) || string.IsNullOrEmpty(MaTH) || string.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Tất cả các trường thông tin phải được nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!int.TryParse(txtGiaBan.Text.Trim(), out int GiaBan) || GiaBan <= 0) //validate data cho LuongCB
            {
                MessageBox.Show("Giá bán phải là một số nguyên dương hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return new DTOSanPham(MaSP, TenSP, MaTH, GiaBan);
        }
        /// <summary>
        /// CRUD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var sp = LayThongTinTuForm();

            if (BUSSanPham.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (BUSSanPham.themSP(sp))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvSP.DataSource = BUSSanPham.getSanPham();
                    }
                }              
                catch
                {
                    MessageBox.Show("Thêm thất bại", "Lỗi");
                }
            }
            ClearForm();
        }
        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {             
                int i = e.RowIndex;

                string tenTH = dgvSP.Rows[i].Cells[2].Value.ToString();
                DataTable dtTH = (DataTable)cbTH.DataSource;
                DataRow[] rows = dtTH.Select($"TenTH = '{tenTH.Replace("'", "''")}'");
                if (rows.Length > 0)
                {
                    cbTH.SelectedValue = rows[0]["MaTH"].ToString();
                }
                else
                {
                    cbTH.SelectedIndex = -1;
                }

                txtMa.Text = dgvSP.Rows[i].Cells[0].Value.ToString();
                txtTen.Text = dgvSP.Rows[i].Cells[1].Value.ToString();
                //cbTH.SelectedValue = dgvSP.Rows[i].Cells[2].Value.ToString();
                txtGiaBan.Text = dgvSP.Rows[i].Cells[3].Value.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var sp = LayThongTinTuForm();

            if ( sp == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (BUSSanPham.suaSP(sp))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvSP.DataSource = BUSSanPham.getSanPham();
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
           var sp = LayThongTinTuForm();

            if (sp == null)
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
                        if (BUSSanPham.xoaSP(sp))
                        {
                            MessageBox.Show("Xóa thành công");
                            dgvSP.DataSource = BUSSanPham.getSanPham();
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

        private void panel5_Click(object sender, EventArgs e)
        {
            dgvSP.ClearSelection();
        }
    }
}
