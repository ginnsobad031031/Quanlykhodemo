using System;
using System.Windows.Forms;
using QuanlyKhodemo.Forms;

namespace QuanlyKhodemo.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Phần Mềm Quản Lý Kho - V1.0";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void quảnLýHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa form = new frmHangHoa();
            form.MdiParent = this;
            form.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKho form = new frmKho();
            form.MdiParent = this;
            form.Show();
        }

        private void danh_mụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDanhMuc form = new frmDanhMuc();
            form.MdiParent = this;
            form.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát ứng dụng?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
