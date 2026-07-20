using System;
using System.Windows.Forms;
using QuanlyKhodemo.BLL;
using QuanlyKhodemo.Models;

namespace QuanlyKhodemo.Forms
{
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadKho();
        }

        private void LoadKho()
        {
            try
            {
                var khos = KhoBLL.GetAllKho();
                dgvKho.DataSource = khos;
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
                    Kho k = new Kho();
                    k.MaKho = txtMaKho.Text;
                    k.TenKho = txtTenKho.Text;
                    k.DiaChi = txtDiaChi.Text;
                    k.SDT = txtSDT.Text;
                    k.MoTa = txtMoTa.Text;

                    if (KhoBLL.AddKho(k))
                    {
                        MessageBox.Show("Thêm kho thành công!");
                        ClearForm();
                        LoadKho();
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
                if (string.IsNullOrEmpty(txtMaKho.Text))
                {
                    MessageBox.Show("Vui lòng chọn kho cần sửa!");
                    return;
                }

                if (ValidateInput())
                {
                    Kho k = new Kho();
                    k.MaKho = txtMaKho.Text;
                    k.TenKho = txtTenKho.Text;
                    k.DiaChi = txtDiaChi.Text;
                    k.SDT = txtSDT.Text;
                    k.MoTa = txtMoTa.Text;

                    if (KhoBLL.UpdateKho(k))
                    {
                        MessageBox.Show("Cập nhật kho thành công!");
                        ClearForm();
                        LoadKho();
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
                if (string.IsNullOrEmpty(txtMaKho.Text))
                {
                    MessageBox.Show("Vui lòng chọn kho cần xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa kho này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (KhoBLL.DeleteKho(txtMaKho.Text))
                    {
                        MessageBox.Show("Xóa kho thành công!");
                        ClearForm();
                        LoadKho();
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

        private void dgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMaKho.Text = dgvKho.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKho.Text = dgvKho.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = dgvKho.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSDT.Text = dgvKho.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtMoTa.Text = dgvKho.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMaKho.Text))
            {
                MessageBox.Show("Vui lòng nhập mã kho!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTenKho.Text))
            {
                MessageBox.Show("Vui lòng nhập tên kho!");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            txtMaKho.Clear();
            txtTenKho.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtMoTa.Clear();
        }
    }
}
