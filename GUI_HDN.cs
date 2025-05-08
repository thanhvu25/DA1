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
    public partial class GUI_HDN : Form
    {
        BUS_CtHDN buscthdn = new BUS_CtHDN();
        BUS_HDN bushdn = new BUS_HDN();

        BUSNhanVien busnv = new BUSNhanVien();
        BUSSanPham bussp = new BUSSanPham();
        BUSThuongHieu busth = new BUSThuongHieu();
        public GUI_HDN()
        {
            InitializeComponent();
        }

        private void GUI_HDN_Load(object sender, EventArgs e)
        {
            dgvHDN.DataSource = bushdn.getHDN();

            dgvHDN.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvHDN.Columns[1].HeaderText = "Ngày nhập";
            dgvHDN.Columns[2].HeaderText = "Tổng tiền";


            dgvCt.DataSource = buscthdn.getCtHDN();

            dgvCt.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dgvCt.Columns[1].HeaderText = "Mã sản phẩm";
            dgvCt.Columns[2].HeaderText = "Thương hiệu";
            dgvCt.Columns[3].HeaderText = "Số lượng";
            dgvCt.Columns[4].HeaderText = "Mã nhân viên";

            cbNV.DataSource = busnv.getNhanVien();
            cbNV.DisplayMember = "TenNV";
            cbNV.ValueMember = "MaNV";

            cbSP.DataSource = bussp.getSanPham();
            cbSP.DisplayMember = "TenSP";
            cbSP.ValueMember = "MaSP";

            cbTH.DataSource = busth.getThuongHieu();
            cbTH.DisplayMember = "TenTH";
            cbTH.ValueMember = "MaTH";
        }
        /// <summary>
        /// HDN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private DTO_HDN LayThongTinHDN()
        {
            string maHDN = txtMa.Text;
            DateTime ngayNhap = DateTime.Parse(dtpHDN.Value.ToShortDateString());            
            int donGia = int.Parse(txtDonGia.Text);

            return new DTO_HDN(maHDN, ngayNhap, donGia);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var hdn = LayThongTinHDN();

            if (bushdn.KiemtraMaTrung(txtMa.Text) == 1)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (bushdn.themHDN(hdn))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvHDN.DataSource = bushdn.getHDN();
                    }
                }             
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại");
                }

            }
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            var hdn = LayThongTinHDN();

            if (bushdn.suaHDN(hdn))
            {
                MessageBox.Show("Sửa thành công");
                dgvHDN.DataSource = bushdn.getHDN();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var hdn = LayThongTinHDN();

            if (bushdn.xoaHDN(hdn))
            {
                MessageBox.Show("Xóa thành công");
                dgvHDN.DataSource = bushdn.getHDN();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
        private void dgvHDN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int i = e.RowIndex;
                txtMa.Text = dgvHDN.Rows[i].Cells[0].Value.ToString();
                dtpHDN.Value = DateTime.Parse(dgvHDN.Rows[i].Cells[1].Value.ToString());
                txtDonGia.Text = dgvHDN.Rows[i].Cells[2].Value.ToString();
            }
   
        }

        private void frmHDN_Click(object sender, EventArgs e)
        {
            dgvCt.ClearSelection();
            dgvHDN.ClearSelection();
        }

        /// <summary>
        /// Chi tiết HDN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private DTO_CtHDN LayThongTinCT()
        {
            string maCt = txtMaCt.Text;
            string maSP = cbSP.SelectedValue.ToString();
            string maTH = cbTH.SelectedValue.ToString();
            int soLuong = int.Parse(txtSL.Text);
            string maNV = cbNV.SelectedValue.ToString();

            return new DTO_CtHDN(maCt, maSP, maTH, soLuong, maNV);
        }
        private void btnAddCt_Click(object sender, EventArgs e)
        {
            var cthdn = LayThongTinCT();

            if (buscthdn.KiemTraMaTrung(txtMaCt.Text) == 1)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (buscthdn.themCtHDN(cthdn))
                    {
                        MessageBox.Show("Thêm thành công");
                        dgvCt.DataSource = buscthdn.getCtHDN();
                    }
                }
                catch (Exception ex)
                { 
                    {
                        MessageBox.Show("Thêm thất bại");
                    } 
                }
            }
        }
        private void dgvCt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                int i = e.RowIndex;
                txtMaCt.Text = dgvCt.Rows[i].Cells[0].Value.ToString();
                cbSP.SelectedValue = dgvCt.Rows[i].Cells[1].Value.ToString();
                cbTH.SelectedValue = dgvCt.Rows[i].Cells[2].Value.ToString();
                txtSL.Text = dgvCt.Rows[i].Cells[3].Value.ToString();
                cbNV.SelectedValue = dgvCt.Rows[i].Cells[4].Value.ToString();
            }
        }

        private void btnEditCt_Click(object sender, EventArgs e)
        {
            var cthdn = LayThongTinCT();

            if (buscthdn.suaCtHDN(cthdn))
            {
                MessageBox.Show("Sửa thành công");
                dgvCt.DataSource = buscthdn.getCtHDN();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDelCt_Click(object sender, EventArgs e)
        {
            var cthdn = LayThongTinCT();

            if (buscthdn.xoaCtHDN(cthdn))
            {
                MessageBox.Show("Xóa thành công");
                dgvCt.DataSource = buscthdn.getCtHDN();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }
    }
}
