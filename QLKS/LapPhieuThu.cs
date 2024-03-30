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
    public partial class LapPhieuThu : Form
    {
        public LapPhieuThu()
        {
            InitializeComponent();
            PhieuThu(dtgvThongKeThu);
        }

        private void LapPhieuThu_Load(object sender, EventArgs e)
        {

        }

        void LapPhieuThus()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                if (Cons.HoaDon.hoadon.ID != null)
                {
                    int maxID = 0;
                    if (db.ChiTietHoaDonThus.Any())
                    {
                        maxID = db.ChiTietHoaDonThus.Max(m => m.ID);
                    }

                    foreach (var bangThuePhong in Cons.CheckOut.ThanhToan)
                    {
                        int id = maxID + 1;
                        ChiTietHoaDonThu chiTietHoaDon = new ChiTietHoaDonThu
                        {
                            ID = id,
                            idBangThuePhong = bangThuePhong.ID,
                            idHoaDonThu = Cons.HoaDon.hoadon.ID
                        };

                        db.ChiTietHoaDonThus.Add(chiTietHoaDon);
                        maxID = id;
                    }
                }

                db.SaveChanges();
            }
        }

        void PhieuThu(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from thue in Cons.CheckOut.ThanhToan
                             from kh in db.KhachHangs
                             from p in db.Phongs
                             where thue.idKhachHang.Equals(kh.ID)
                             && thue.idPhong.Equals(p.ID)
                             select new
                             {
                                 Tên = kh.TenKH,
                                 Phòng = p.TenP,
                                 ChecIn = thue.CheckIn,
                                 CheckOut = thue.CheckOut,
                                 Giá = thue.TongTien

                             };
                dtgv.DataSource = source.ToList();
            }
            // dtgv.CellFormatting += Dtgv_CellFormattingPhong;
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            LapPhieuThus();
            Cons.CheckOut.ThanhToan = null;
            Cons.HoaDon.hoadon = null;
            QuanLyThuePhong f = new QuanLyThuePhong();
            //ThanhToan tt = new ThanhToan();
            f.Show();
            this.Close();
        }
    }
}
