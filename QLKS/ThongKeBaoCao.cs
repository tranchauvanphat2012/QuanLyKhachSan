using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class ThongKeBaoCao : Form
    {
        public ThongKeBaoCao()
        {
            InitializeComponent();
            AnQuanLy();
            AnDangXuat();
           
        }
        private void vềCửaSổChínhToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        void clear()
        {
            txtTongTien.Text = "" ;
            dtgvThongKeThu.Columns.Clear();
        }
        #region Thu
        void TimHoaDonThu(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                DateTime? ngayBatDau = dtpkNgayBatDauBieuDo.Value;
                DateTime? ngayKetThuc = dtpkNgayKetThucBieuDo.Value;

                var source = from thue in db.BangThuePhongs
                             join ct in db.ChiTietHoaDonThus on thue.ID equals ct.idBangThuePhong
                             join thu in db.HoaDonThus on ct.idHoaDonThu equals thu.ID
                             join kh in db.KhachHangs on thue.idKhachHang equals kh.ID
                             join p in db.Phongs on thue.idPhong equals p.ID
                             where thu.NgayLap >= ngayBatDau && thu.NgayLap <= ngayKetThuc
                             select new
                             {
                                 Khách = kh.TenKH,
                                 Phòng = p.TenP,
                                 CheckIn = thue.CheckIn,
                                 CheckOut = thue.CheckOut,
                                 Ngày_Thu = thu.NgayLap,
                                 Lý_Do = thu.LyDo,
                                 Tiển_Phòng = thue.TongTien,
                                 Tổng_Hóa_Đơn = thu.TongTien
                             };
                dtgv.DataSource = source.ToList();

            }
            dtgv.CellFormatting += Dtgv_CellFormattingPhong;
            Tong();
        }

        private void Dtgv_CellFormattingPhong(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((dtgvThongKeThu.Columns[e.ColumnIndex].Name == "Tiển_Phòng" || dtgvThongKeThu.Columns[e.ColumnIndex].Name == "Tổng_Hóa_Đơn") && e.Value != null && e.Value != null)
            {
                if (e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,###.###");
                    e.FormattingApplied = true;
                }
            }
        }

        void luu()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                DateTime? ngayBatDau = dtpkNgayBatDauBieuDo.Value;
                DateTime? ngayKetThuc = dtpkNgayKetThucBieuDo.Value;

                var luu = (from cthd in db.ChiTietHoaDonThus
                           where cthd.HoaDonThu.NgayLap >= ngayBatDau && cthd.HoaDonThu.NgayLap <= ngayKetThuc
                           select cthd).ToList();

                if (luu.Any())
                {
                    Cons.DoanhThu.hoadon = luu;
                }
            }
            TimHoaDonThu(dtgvThongKeThu);
        }

        void Tong()
        {
            decimal? tongTien = 0;

            if (Cons.DoanhThu.hoadon != null && Cons.DoanhThu.hoadon.Count > 0)
            {
                List<int?> idHoaDonThuList = Cons.DoanhThu.hoadon.Select(cthd => cthd.idHoaDonThu).ToList();

                using (KHACHSANEntities db = new KHACHSANEntities())
                {
                    tongTien = db.HoaDonThus
                        .Where(hd => idHoaDonThuList.Contains(hd.ID))
                        .Select(hd => hd.TongTien)
                        .DefaultIfEmpty(0)
                        .Sum();
                }
            }

            double tongTienDouble = Convert.ToDouble(tongTien);
            double tongTienTronDouble = Math.Round(tongTienDouble, 0);
            decimal tongTienTron = Convert.ToDecimal(tongTienTronDouble);
            txtTongTien.Text = tongTienTron.ToString("#,###");
        }


        #endregion
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.content.LoginNhanVien = null;
            this.Close();
        }

        private void ThongKeBaoCao_Load(object sender, EventArgs e)
        {
            tmiTenNhanVien.Text = Cons.content.LoginNhanVien.TenNV;//hiển thị tên NV
        }

        void AnQuanLy()
        {

            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int coll = Cons.content.LoginNhanVien.IDChucDanh;
                if (coll == 2)
                {
                    quảnLýToolStripMenuItem.Visible = true;
                }
                else
                {
                    quảnLýToolStripMenuItem.Visible = false;
                }
            }

        }

        void AnDangXuat()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int coll = Cons.content.LoginNhanVien.IDChucDanh;
                if (coll == 3)
                {
                    đăngXuấtToolStripMenuItem.Visible = true;
                }
                else
                {
                    đăngXuấtToolStripMenuItem.Visible = false;
                }
            }
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            f.Show();
            this.Close();
        }

        private void btnThongKeThu_Click(object sender, EventArgs e)
        {
            luu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
