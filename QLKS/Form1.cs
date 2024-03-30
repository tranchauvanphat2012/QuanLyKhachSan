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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Form f = nextForm(txbUserID.Text, txbPass.Text);

            if(f == null)
            {
                return;
            }
            f.FormClosed += f_FormClosed;

            f.StartPosition = FormStartPosition.CenterScreen;//set vị trí form chính giữa màn hình

            f.Show();
            this.Hide();

            XoaTrangbox();//xóa trắng textbox
            
        }

        void f_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        void XoaTrangbox()
        {
            txbUserID.Clear();
            txbPass.Clear();
        }
        Form nextForm(string id, string pass)
        {
            Form f = new Form();

            int roll = (int)Cons.Roll.TiepTan;
            using(KHACHSANEntities db = new KHACHSANEntities())
            {
                var t = db.UserS.Where(p => p.idNhanVien.Equals(id) && p.Pass.Equals(pass));
                User u = t.Count() == 1? t.Single() : null;
                if (u != null)
                {
                    NhanVien nv = db.NhanViens.Where(p => u.idNhanVien.Equals(p.ID)).Single();
                    roll = (int)nv.ChucDanh.RollCD;

                    Cons.content.LoginNhanVien = nv;
                }
                else
                {
                    MessageBox.Show("Tên Đăng nhập hoặc mật khẩu không đúng");
                    return null;
                }
            }

            switch (roll)
            {
                case (int)Cons.Roll.TiepTan:
                    f = new QuanLyThuePhong();
                    break;
                case (int)Cons.Roll.KeToan:
                    f = new ThongKeBaoCao();
                    break;
                case (int)Cons.Roll.QuanLy:
                    f = new QuanLy();
                    break;
            }
            return f;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
