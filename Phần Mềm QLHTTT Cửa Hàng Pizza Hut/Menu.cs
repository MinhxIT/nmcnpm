using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Phần_Mềm_QLHTTT_Cửa_Hàng_Pizza_Hut
{
    public partial class FormMenu : Form
    {
        
        string maNVNao; // khai báo 1 mã nhân viên, để truyền mã nhân viên vào form thanh toán, khi đó nhân viên nào login thì nhân viên đó lập hóa đơn luôn
        public FormMenu(string MaNhanVien)
        {
            this.maNVNao = MaNhanVien; // đây chính là txtUsername từ form trước truyền vào. ví dụ: NV00000002
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Nhanvien formNV = new Nhanvien();
            formNV.MdiParent = this;
            formNV.Show();

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Khachhang formKH = new Khachhang();
            formKH.MdiParent = this;
            formKH.Show();
        }

        private void nhàCungCấpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NhaCungCap formNCC = new NhaCungCap();
            formNCC.MdiParent = this;
            formNCC.Show();
        }

        private void mónĂnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Monan formMA = new Monan();
            formMA.MdiParent = this;
            formMA.Show();

        }

        private void nguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NguyenLieu formNL = new NguyenLieu();
            formNL.MdiParent = this;
            formNL.Show();
        }

        private void hóaĐơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDDH formDH = new HDDH();
            formDH.MdiParent = this;
            formDH.Show();
           
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HDNH formNH = new HDNH();
            formNH.MdiParent = this;
            formNH.Show();
        }

        private void hóaĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HDBH formBH = new HDBH();
            formBH.MdiParent = this;
            formBH.Show();
        }

        private void cấpTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Captaikhoan formCTK = new Captaikhoan();
            formCTK.MdiParent = this;
            formCTK.Show();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK formDMK = new DoiMK();
            formDMK.MdiParent = this;
            formDMK.Show();
        }

    }
}
