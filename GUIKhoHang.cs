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
    public partial class GUIKhoHang : Form
    {
        BUSKhoHang busKho = new BUSKhoHang();
        BUSSanPham busSP = new BUSSanPham();
        public GUIKhoHang()
        {
            InitializeComponent();
        }

        private void GUIKhoHang_Load(object sender, EventArgs e)
        {
            dgvKho.DataSource = busKho.getKhoHang();

            dgvKho.Columns[0].HeaderText = "Mã sản phẩm";
            dgvKho.Columns[1].HeaderText = "Tên sản phẩm";
            dgvKho.Columns[2].HeaderText = "Thương hiệu";
            dgvKho.Columns[3].HeaderText = "Số lượng tồn";

            cbTen.DataSource = busSP.getSanPham();
            cbTen.DisplayMember = "TenSP";
            cbTen.ValueMember = "MaSP";

            cbTen.SelectedIndexChanged += cbTen_SelectedIndexChanged;

        }

        private void GUIKhoHang_Click(object sender, EventArgs e)
        {
            dgvKho.ClearSelection();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtTH.Clear();
            txtSLTon.Clear();
        }
        /// <summary>
        /// Lấy thông tin từ form và kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        private DTOKhoHang LayThongTinTuForm()
        {
            if (cbTen.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm");
                return null;
            }

            string maSP = cbTen.SelectedValue.ToString();
            int slTon;
            if (string.IsNullOrEmpty(txtSLTon.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng tồn");
                return null;
            }
            if (!int.TryParse(txtSLTon.Text.Trim(), out slTon) || slTon <= 0)
            {
                MessageBox.Show("Số lượng tồn phải là số nguyên dương");
                return null;
            }
            return new DTOKhoHang(maSP, slTon);
        }


        private void cbTen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTen.SelectedValue == null) return;

            string selectedMaSP = cbTen.SelectedValue.ToString();
            DataTable dtSP = busSP.getSanPham();

            DataRow[] rows = dtSP.Select($"MaSP = '{selectedMaSP}'");
            if (rows.Length > 0)
            {
                txtMa.Text = rows[0]["MaSP"].ToString();
                txtTH.Text = rows[0]["TenTH"].ToString();
            }
        }

        /// <summary>
        /// CRUD kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var kho = LayThongTinTuForm();

            if (busKho.KiemTraMaTrung(txtMa.Text) == 0)
            {
                if (busKho.themNV(kho))
                {
                    MessageBox.Show("Thêm thành công");
                    dgvKho.DataSource = busKho.getKhoHang();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm đã tồn tại");
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var kho = LayThongTinTuForm();

            if (kho == null)
            {
                return;
            }
            else
            {
                if (busKho.KiemTraMaTrung(txtMa.Text) == 1)
                {
                    if (busKho.suaNV(kho))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvKho.DataSource = busKho.getKhoHang();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không tồn tại");
                }
            }

            ClearForm();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var kho = LayThongTinTuForm();

            if (kho == null)
            {
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (busKho.xoaNV(kho))
                    {
                        MessageBox.Show("Xóa thành công");
                        dgvKho.DataSource = busKho.getKhoHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }

            ClearForm();
        }

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            cbTen.SelectedValue = dgvKho.Rows[i].Cells[0].Value.ToString();
            txtMa.Text = dgvKho.Rows[i].Cells[1].Value.ToString();
            txtTH.Text = dgvKho.Rows[i].Cells[2].Value.ToString();
            txtSLTon.Text = dgvKho.Rows[i].Cells[3].Value.ToString();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            dgvKho.ClearSelection();
        }
    }
}
