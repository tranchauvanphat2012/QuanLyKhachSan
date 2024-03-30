using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }
        void LoadThongTinKhachHang(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from nv in db.NhanViens
                             from cd in db.ChucDanhs
                             where  nv.IDBoPhan.Equals(cd.ID)
                             select new
                             {
                                 ID = nv.ID,
                                 Họ_Tên = nv.TenNV,
                                 Giới_Tính = nv.GioiTinh.HasValue ? (nv.GioiTinh.Value ? "Nam" : "Nữ") : string.Empty, 
                                 Ngày_Sinh = nv.NgaySinh,
                                 Quoc_Tich = cd.TenCD
                             };
                dtgv.DataSource = source.ToList();
            }
        }
        private void thốngKêBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeBaoCao f = new ThongKeBaoCao();
            f.Show();
            this.Hide();
        }

        private void quảnLýThuêPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyThuePhong f = new QuanLyThuePhong();
            f.Show();
            this.Hide();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            LoadThongTinKhachHang(dtgvNhanSu);
        }

        private void đăngXuấToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.content.LoginNhanVien = null;
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
}
