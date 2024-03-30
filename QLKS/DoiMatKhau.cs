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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
            //BindingTenDangNhap();
        }
        void DoiMatKhauUser()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string id = txbTenDangNhap.Text;
                User u = db.UserS.Find(id);

                string tendangnhap = id;
                string passcu = txbMatKhauCu.Text;
                string passmoi = txbMatKhauMoi.Text;
                if (string.IsNullOrEmpty(passcu) && string.IsNullOrEmpty(passmoi) && string.IsNullOrEmpty(tendangnhap))
                {
                    MessageBox.Show("Các Trường Không Được Để TRống");
                    return;
                }
                else if (string.IsNullOrEmpty(passcu) && string.IsNullOrEmpty(passmoi))
                {
                    MessageBox.Show("Mật khẩu Mới Và Mật Khẩu Cũ Không Được Để Trống");
                    return;
                }
                else if (string.IsNullOrEmpty(passcu) && string.IsNullOrEmpty(tendangnhap))
                {
                    MessageBox.Show("Mật khẩu Cũ Và Tên Đăng Nhập Không Được Để Trống");
                    return;
                }
                else if (string.IsNullOrEmpty(passmoi) && string.IsNullOrEmpty(tendangnhap))
                {
                    MessageBox.Show("Mật khẩu Mới Và Tên Đăng Nhập Không Được Để Trống"); 
                    return;
                }
                else if (string.IsNullOrEmpty(tendangnhap))
                {
                    MessageBox.Show("Tên Đăng Nhập Không Được Để Trống");
                    return;
                }
                else if (string.IsNullOrEmpty(passmoi))
                {
                    MessageBox.Show("Mật khẩu Mới Không Được Để Trống");
                    return;
                }
                else if (string.IsNullOrEmpty(passcu))
                {
                    MessageBox.Show("Mật khẩu Cũ Không Được Để Trống");
                    return;
                }
                else if (u == null || u.ID != tendangnhap)
                {
                    MessageBox.Show("Tên Đăng Nhập Sai");
                    return;
                }
                else if (db.UserS.Any(m => m.Pass == passmoi))
                {
                    MessageBox.Show("Mật khẩu Mới Phải Khác Mật khẩu Cũ");
                    return;
                }
                else if (u == null || u.Pass != passcu)
                {
                    MessageBox.Show("Mật khẩu Cũ Sai");
                    return;
                }
                else
                {
                    u.Pass = passmoi;
                    db.SaveChanges();
                    MessageBox.Show("Đổi Mật Khẩu Thành Công!!!");
                    this.Close();
                }
            }
        }

        void BindingTenDangNhap()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                User user = db.UserS.Find(txbTenDangNhap.Text);
                Binding bdID = new Binding("Text", user, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
                txbTenDangNhap.DataBindings.Clear();
                txbTenDangNhap.DataBindings.Add(bdID);
            }              
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            DoiMatKhauUser();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
