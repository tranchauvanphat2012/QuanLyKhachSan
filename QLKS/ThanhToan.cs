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
    public partial class ThanhToan : Form
    {
        public ThanhToan()
        {
            InitializeComponent();
            LoadThanhToan();
            TmiTen.Text = Cons.content.LoginNhanVien.TenNV;

        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {

        }

        void LoadThanhToan()
        {
            StringBuilder sb = new StringBuilder();
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                foreach (var item in Cons.CheckOut.ThanhToan)
                {
                    DateTime? checkOut = item.CheckOut;

                    // Kiểm tra giá trị không null trước khi gán cho DateTimePicker
                    if (checkOut != null)
                    {
                        dtpkNgay.Value = checkOut.Value;
                    }
                }
                decimal? tongTien = 0;
                decimal? Tien = 0;
                if (Cons.CheckOut.ThanhToan.Count > 0)
                {
                    string idKhachHang = Cons.CheckOut.ThanhToan[0].idKhachHang;
                    txbKhachHang.Text = idKhachHang;
                }
                foreach (BangThuePhong phong in Cons.CheckOut.ThanhToan)
                {
                    string idphong = phong.idPhong;

                    // Lấy TenP từ bảng Phong
                    Phong phongInfo = db.Phongs.FirstOrDefault(p => p.ID == idphong);
                    if (phongInfo != null)
                    {
                        sb.Append(phongInfo.TenP);
                        sb.Append(" ");
                    }

                    
                    tongTien += phong.TongTien;

                    // Tính tổng của TongTien của SuDungDichVu dựa trên khóa ngoại idBangThuePhong
                    decimal? tongTienSuDungDichVu = db.SuDungDichVus
                        .Where(s => s.idBangThuePhong == phong.ID)
                        .Sum(s => s.TongTien);
                    if (tongTienSuDungDichVu != null)
                    {
                        Tien =tongTien + tongTienSuDungDichVu;
                    }
                    else
                    {
                        Tien = tongTien;
                    }
                }
                double tongTienDouble = Convert.ToDouble(Tien);
                double tongTienTronDouble = Math.Round(tongTienDouble, 0);
                decimal tongTienTron = Convert.ToDecimal(tongTienTronDouble);
                txbTienThuePhong.Text = tongTienTron.ToString("#,###");
                txbTenPhong.Text = sb.ToString();

            }
        }

        void ThanhToans()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {

                int id = 1;
                if (db.HoaDonThus.Any())
                {
                    id = db.HoaDonThus.Max(m => m.ID) + 1;
                }
                //string id = (Int32.Parse(db.Phongs.Select(m => m.ID).Max()) + 1).ToString();
                string danhsach = txbTenPhong.Text;
                string kh = txbKhachHang.Text;
                Decimal? tongtien = Decimal.Parse(txbTienThuePhong.Text);
                DateTime? ngay = dtpkNgay.Value;
                string nhanvien = Cons.content.LoginNhanVien.ID;
                string ghichu = txbGhiChu.Text;

                HoaDonThu t = new HoaDonThu()
                {
                    ID = id,
                    idKhachHang = kh,
                    DanhSachPhong = danhsach,
                    TongTien = tongtien,
                    NgayLap = ngay,
                    idNhanVien = nhanvien,
                    LyDo = ghichu
                };
                
                db.HoaDonThus.Add(t);
                db.SaveChanges();
                MessageBox.Show("Thanh Toán Thành Công");
                if (db.HoaDonThus.Any(m => m.ID == id))
                {
                    HoaDonThu hoadon = db.HoaDonThus.Where(m => m.ID == id).Single();
                    Cons.HoaDon.hoadon = hoadon;
                }
            }
        }

        void DaThanhToan()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                foreach (var bangThuePhong in Cons.CheckOut.ThanhToan)
                {
                    var capnhat = db.BangThuePhongs.FirstOrDefault(b => b.ID == bangThuePhong.ID);
                    if (capnhat != null)
                    {
                        capnhat.idTrangThaiThuePhong = 2;
                    }
                }
                db.SaveChanges();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            ThanhToans();
            DaThanhToan();
            LapPhieuThu f = new LapPhieuThu();
            f.Show();
            this.Close();
        }
    }
}
