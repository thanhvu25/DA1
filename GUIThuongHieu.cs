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
    public partial class GUIThuongHieu : Form
    {
        BUSThuongHieu busth = new BUSThuongHieu();
        public GUIThuongHieu()
        {
            InitializeComponent();
        }

        private void GUIThuongHieu_Load(object sender, EventArgs e)
        {
            dgvTH.DataSource = busth.getThuongHieu();

            dgvTH.Columns[0].HeaderText = "Mã thương hiệu";
            dgvTH.Columns[1].HeaderText = "Tên thương hiệu";
            dgvTH.Columns[2].HeaderText = "Địa chỉ thương hiệu";
            dgvTH.Columns[3].HeaderText = "Số điện thoại thương hiệu";
        }   

        private void GUIThuongHieu_Click(object sender, EventArgs e)
        {
            dgvTH.ClearSelection();
        }
        private void panel5_Click(object sender, EventArgs e)
        {
            dgvTH.ClearSelection();
        }
        private void ClearForm()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtDiaChi.Clear();
            txtSdt.Clear();
        }
        /// <summary>
        /// Lấy thông tin từ form và kiểm tra dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private DTOThuongHieu LayThongTinTuForm()
        {
            string MaTH = txtMa.Text;
            string TenTH = txtTen.Text;
            string DiaChiTH = txtDiaChi.Text;
            string SdtTH = txtSdt.Text;
            if ( string.IsNullOrEmpty(TenTH) || string.IsNullOrEmpty(DiaChiTH) || string.IsNullOrEmpty(SdtTH))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(SdtTH, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại phải là 10 chữ số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return new DTOThuongHieu(MaTH, TenTH, DiaChiTH, SdtTH);

        }

        /// <summary>
        /// CRUD Thương hiệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var th = LayThongTinTuForm();

            if (busth.KiemTraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã thương hiệu đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (busth.themTH(th))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvTH.DataSource = busth.getThuongHieu();
                    }
                }               
                catch
                {
                    MessageBox.Show("Thêm không thành công", "Lỗi");
                }
            }

            ClearForm();
        }
        private void dgvTH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            txtMa.Text = dgvTH.Rows[i].Cells[0].Value.ToString();
            txtTen.Text = dgvTH.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dgvTH.Rows[i].Cells[2].Value.ToString();
            txtSdt.Text = dgvTH.Rows[i].Cells[3].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var th = LayThongTinTuForm();

            if (th == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (busth.suaTH(th))
                    {
                        MessageBox.Show("Sửa thành công");
                        dgvTH.DataSource = busth.getThuongHieu();
                    }
                }
                catch
                {
                    MessageBox.Show("Sửa không thành công", "Lỗi");
                }
            } 
            ClearForm();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var th = LayThongTinTuForm();

            if (th == null)
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
                        if (busth.xoaTH(th))
                        {
                            MessageBox.Show("Xóa thành công");
                            dgvTH.DataSource = busth.getThuongHieu();
                        }                       
                    }
                }
                catch
                {
                    MessageBox.Show("Xóa không thành công", "Lỗi");
                }
            }
            ClearForm();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
