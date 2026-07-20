using System;
using System.Windows.Forms;
using QuanlyKhodemo.BLL;
using QuanlyKhodemo.Models;

namespace QuanlyKhodemo.Forms
{
    public partial class frmHangHoa : Form
    {
        private int selectedRow = -1;

        public frmHangHoa()
        {
            InitializeComponent();
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadDanhMuc();
            LoadHangHoa();
        }

        private void LoadDanhMuc()
        {
            try
            {
                var danhMucs = DanhMucBLL.GetAllDanhMuc();
                cmbDanhMuc.DataSource = danhMucs;
                cmbDanhMuc.DisplayMember = "TenDanhMuc";
                cmbDanhMuc.ValueMember = "MaDanhMuc";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadHangHoa()
        {
            try
            {
                var hangHoas = HangHoaBLL.GetAllHangHoa();
                dgvHangHoa.DataSource = hangHoas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    HangHoa hh = new HangHoa();
                    hh.MaHangHoa = txtMaHangHoa.Text;
                    hh.TenHangHoa = txtTenHangHoa.Text;
                    hh.MaDanhMuc = cmbDanhMuc.SelectedValue.ToString();
                    hh.KichThuoc = txtKichThuoc.Text;
                    hh.Mau = txtMau.Text;
                    hh.KhoiLuong = decimal.Parse(txtKhoiLuong.Text);
                    hh.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                    hh.GiaBan = decimal.Parse(txtGiaBan.Text);
                    hh.MoTa = txtMoTa.Text;

                    if (HangHoaBLL.AddHangHoa(hh))
                    {
                        MessageBox.Show("Thêm hàng hóa thành công!");
                        ClearForm();
                        LoadHangHoa();
                    }
                    else
                    {
                        MessageBox.Show("Thêm hàng hóa thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHangHoa.Text))
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần sửa!");
                    return;
                }

                if (ValidateInput())
                {
                    HangHoa hh = new HangHoa();
                    hh.MaHangHoa = txtMaHangHoa.Text;
                    hh.TenHangHoa = txtTenHangHoa.Text;
                    hh.MaDanhMuc = cmbDanhMuc.SelectedValue.ToString();
                    hh.KichThuoc = txtKichThuoc.Text;
                    hh.Mau = txtMau.Text;
                    hh.KhoiLuong = decimal.Parse(txtKhoiLuong.Text);
                    hh.GiaNhap = decimal.Parse(txtGiaNhap.Text);
                    hh.GiaBan = decimal.Parse(txtGiaBan.Text);
                    hh.MoTa = txtMoTa.Text;

                    if (HangHoaBLL.UpdateHangHoa(hh))
                    {
                        MessageBox.Show("Cập nhật hàng hóa thành công!");
                        ClearForm();
                        LoadHangHoa();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaHangHoa.Text))
                {
                    MessageBox.Show("Vui lòng chọn hàng hóa cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa hàng hóa này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (HangHoaBLL.DeleteHangHoa(txtMaHangHoa.Text))
                    {
                        MessageBox.Show("Xóa hàng hóa thành công!");
                        ClearForm();
                        LoadHangHoa();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = e.RowIndex;
                txtMaHangHoa.Text = dgvHangHoa.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenHangHoa.Text = dgvHangHoa.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbDanhMuc.SelectedValue = dgvHangHoa.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtKichThuoc.Text = dgvHangHoa.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMau.Text = dgvHangHoa.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtKhoiLuong.Text = dgvHangHoa.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGiaNhap.Text = dgvHangHoa.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtGiaBan.Text = dgvHangHoa.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtMoTa.Text = dgvHangHoa.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaHangHoa.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hàng hóa!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenHangHoa.Text))
            {
                MessageBox.Show("Vui lòng nhập tên hàng hóa!");
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaNhap.Text) || string.IsNullOrEmpty(txtGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập giá nhập và giá bán!");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtMaHangHoa.Clear();
            txtTenHangHoa.Clear();
            txtKichThuoc.Clear();
            txtMau.Clear();
            txtKhoiLuong.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtMoTa.Clear();
            selectedRow = -1;
        }
    }
}
