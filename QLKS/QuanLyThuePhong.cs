using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class QuanLyThuePhong : Form
    {
        public QuanLyThuePhong()
        {
            InitializeComponent();
        }

        private void QuanLyThuePhong_Load(object sender, EventArgs e)
        {
            tmiTenNhanVien.Text = Cons.content.LoginNhanVien.TenNV;//hiển thị tên NV
            Loaddtgv();
            LoadCbb();
            AnQuanLy();
            AnDangXuat();
          

            dgtvphong.Columns["ID"].Visible = false;// ẩn cột ID của Quản Lý Phòng
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cons.content.LoginNhanVien = null;
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

        void Loaddtgv()
        {
            LoadPhong(dgtvphong);
            LoadLoaiPhong(dtgvLoaiPhong);
            LoadCoSoVatTu(dtgvCoSoVatChat);
            LoadTrangThaiThuePhong(dtgvPhongThuePhong);
            LoadThongTinKhachHang(dtgvKhach);
            //LoadPhong(dtgvXemPhong);
        }

        void LoadCbb()
        {
            LoadLoaiPhong(cbbLoaiPhong);
            LoadTinhTrangPhong(cbbTrangThai);
            LoadTenPhong(cbbTenPhong);
            LoadTenDichVu(cbbDichVu);
        }

        #region Phong
        void BindingPhong(DataGridView dtgv)
        {
            Binding bdID = new Binding("Text", dtgv.DataSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txbIDPhong.DataBindings.Clear();
            txbIDPhong.DataBindings.Add(bdID);

            Binding bdTen = new Binding("Text", dtgv.DataSource, "Tên", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTenPhong.DataBindings.Clear();
            txbTenPhong.DataBindings.Add(bdTen);

            Binding bdGia = new Binding("Text", dtgv.DataSource, "Giá", true, DataSourceUpdateMode.OnPropertyChanged);
            txbGiaPhong.DataBindings.Clear();
            txbGiaPhong.DataBindings.Add(bdGia);

            Binding bdSoGiuong = new Binding("Text", dtgv.DataSource, "Số_Giường", true, DataSourceUpdateMode.OnPropertyChanged);
            txbSoGiuong.DataBindings.Clear();
            txbSoGiuong.DataBindings.Add(bdSoGiuong);
        }

        void LoadPhong(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from p in db.Phongs
                             from l in db.LoaiPhongs
                             from t in db.TinhTrangPhongs
                             where p.idLoaiPhong.Equals(l.ID)
                             && p.idTinhTrangPhong.Equals(t.ID)
                             select new
                             {
                                 ID = p.ID,
                                 Tên = p.TenP,
                                 Loại = l.TenLP,
                                 Tình_Trạng = t.TenTTP,
                                 Giá = l.Gia,
                                 Số_Giường = l.SoGiuong
                             };
                dtgv.DataSource = source.ToList();
            }
            dtgv.CellFormatting += Dtgv_CellFormattingPhong;
            BindingPhong(dgtvphong);
        }

        void LoadLoaiPhong(ComboBox cb)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                cb.DataSource = db.LoaiPhongs.ToList();
                cb.DisplayMember = "TenLP";
            }
        }

        void LoadTinhTrangPhong(ComboBox cb)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                cb.DataSource = db.TinhTrangPhongs.ToList();
                cb.DisplayMember = "TenTTP";
            }
        }

        void ThemPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string id = "1";
                if (db.Phongs.Any())
                {
                    id = (Int32.Parse(db.Phongs.Select(m => m.ID).Max()) + 1).ToString();
                }
                //string id = (Int32.Parse(db.Phongs.Select(m => m.ID).Max()) + 1).ToString();
                string ten = txbTenPhong.Text;
                
                if (string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Tên Không Được Để Trống");
                    return;
                }
                if (db.Phongs.Select(m => m.TenP).Contains(ten))
                {
                    MessageBox.Show("Tên Phòng đã tồn tại");
                    return;
                }
                int loai = (cbbLoaiPhong.SelectedValue as LoaiPhong).ID;
                int trangthai = (cbbTrangThai.SelectedValue as TinhTrangPhong).ID;

                Phong p = new Phong()
                {
                    ID = id,
                    TenP = ten,
                    idLoaiPhong = loai,
                    idTinhTrangPhong = trangthai
                };

                db.Phongs.Add(p);
                db.SaveChanges();
                MessageBox.Show("Thêm phòng thành công");
                Loaddtgv();
                LoadCbb();
            }
        }

        void XoaPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string id = txbIDPhong.Text;
                if(db.BangThuePhongs.Any(p => p.idPhong == id))
                {
                    MessageBox.Show("Phòng Có Người Ở Không Được Xóa");
                    return;
                }
                else
                {
                    db.Phongs.Remove(db.Phongs.Find(id));
                    db.SaveChanges();
                    MessageBox.Show("Xóa phòng thành công");
                    Loaddtgv();
                    LoadCbb();
                }
            }
        }

        void SuaPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string id = txbIDPhong.Text;
                if (db.BangThuePhongs.Any(p => p.idPhong == id))
                {
                    MessageBox.Show("Phòng Có Người Ở Không Được Sửa");
                    return;
                }
                else
                {
                    Phong phong = db.Phongs.Find(id);

                    int loai = (cbbLoaiPhong.SelectedValue as LoaiPhong).ID;
                    int trangthai = (cbbTrangThai.SelectedValue as TinhTrangPhong).ID;

                    phong.idLoaiPhong = loai;
                    phong.idTinhTrangPhong = trangthai;

                    db.SaveChanges();
                    MessageBox.Show("Sửa phòng thành công");
                    Loaddtgv();
                    LoadCbb();
                }
            }
        }

        void TimKiem(DataGridView dtgv)
        {
            string tuKhoa = txbTimPhong.Text.Trim(); // Lấy từ khóa tìm kiếm từ TextBox và loại bỏ khoảng trắng thừa

            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from p in db.Phongs
                             from l in db.LoaiPhongs
                             from t in db.TinhTrangPhongs
                             where p.idLoaiPhong.Equals(l.ID)
                                && p.idTinhTrangPhong.Equals(t.ID)
                                && (string.IsNullOrEmpty(tuKhoa) || p.TenP.Contains(tuKhoa)) // Áp dụng điều kiện tìm kiếm
                             select new
                             {
                                 ID = p.ID,
                                 Tên = p.TenP,
                                 Loại = l.TenLP,
                                 Tình_Trạng = t.TenTTP,
                                 Giá = l.Gia,
                                 Số_Giường = l.SoGiuong
                             };
                dtgv.DataSource = source.ToList();
            }

        }

        private void Dtgv_CellFormattingPhong(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgtvphong.Columns[e.ColumnIndex].Name == "Giá" && e.Value != null)
            {
                if (e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,###.###");
                    e.FormattingApplied = true;
                }
            }
        }

        private void dgtvphong_SelectionChanged(object sender, EventArgs e)
        {
            //load datagridview len cbbloaiphong
            if (cbbLoaiPhong.DataSource == null || dgtvphong.SelectedCells.Count == 0)
                return;
            string loai = dgtvphong.SelectedCells[0].OwningRow.Cells["Loại"].Value.ToString();
            int index = 0;
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                index = db.LoaiPhongs.Select(p => p.TenLP).ToList().IndexOf(loai);
            }
            cbbLoaiPhong.SelectedIndex = index;

            //load datagridview len cbbtrangthai
            if (cbbTrangThai.DataSource == null || dgtvphong.SelectedCells.Count == 0)
                return;
            string trangthai = dgtvphong.SelectedCells[0].OwningRow.Cells["Tình_Trạng"].Value.ToString();
            int index2 = 0;
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                index2 = db.TinhTrangPhongs.Select(p => p.TenTTP).ToList().IndexOf(trangthai);
            }
            cbbTrangThai.SelectedIndex = index2;

        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            ThemPhong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XoaPhong();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SuaPhong();
        }

        private void btnXemTatCaPhong_Click(object sender, EventArgs e)
        {
            LoadPhong(dgtvphong);
        }
        #endregion

        #region LoaiPhong
        void LoadLoaiPhong(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from l in db.LoaiPhongs
                             select new
                             {
                                 ID = l.ID,
                                 Tên = l.TenLP,
                                 Giá = l.Gia,
                                 Tiền_Phụ_Thu = l.TienPhuThu,
                                 Số_Giường = l.SoGiuong,
                                 Số_người_tối_đa = l.SoNguoiToiDaTrenGiuong
                             };
                dtgv.DataSource = source.ToList();
            }
            dtgv.CellFormatting += Dtgv_CellFormatting;

            BindingLoaiPhong(dtgvLoaiPhong);
        }

        void BindingLoaiPhong(DataGridView dtgv)
        {
            Binding bdID = new Binding("Text", dtgv.DataSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txbIDLoaiPhong.DataBindings.Clear();
            txbIDLoaiPhong.DataBindings.Add(bdID);

            Binding bdTenLoai = new Binding("Text", dtgv.DataSource, "Tên", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTenLoaiPhong.DataBindings.Clear();
            txbTenLoaiPhong.DataBindings.Add(bdTenLoai);

            Binding bdGiaLoai = new Binding("Text", dtgv.DataSource, "Giá", true, DataSourceUpdateMode.OnPropertyChanged);
            txbGiaLoaiPhong.DataBindings.Clear();
            txbGiaLoaiPhong.DataBindings.Add(bdGiaLoai);

            Binding bdTienPhuThu = new Binding("Text", dtgv.DataSource, "Tiền_Phụ_Thu", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTienPhuThu.DataBindings.Clear();
            txbTienPhuThu.DataBindings.Add(bdTienPhuThu);

            Binding bdSoGiuong = new Binding("Text", dtgv.DataSource, "Số_Giường", true, DataSourceUpdateMode.OnPropertyChanged);
            txbSoGiuongLoaiPhong.DataBindings.Clear();
            txbSoGiuongLoaiPhong.DataBindings.Add(bdSoGiuong);

            Binding bdSoNguoiToiDa = new Binding("Text", dtgv.DataSource, "Số_người_tối_đa", true, DataSourceUpdateMode.OnPropertyChanged);
            txbSoNguoiToiDa.DataBindings.Clear();
            txbSoNguoiToiDa.DataBindings.Add(bdSoNguoiToiDa);

        }

        void ThemLoaiPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int id = Int32.Parse(txbIDLoaiPhong.Text);
                string ten = txbTenLoaiPhong.Text;
                decimal gia = decimal.Parse(txbGiaLoaiPhong.Text);
                decimal tienphuthu = decimal.Parse(txbTienPhuThu.Text);
                int sogiuong = Int32.Parse(txbSoGiuongLoaiPhong.Text);
                int songuoitoida = Int32.Parse(txbSoNguoiToiDa.Text);

                if (db.LoaiPhongs.Select(m => m.TenLP).Contains(ten))
                {
                    MessageBox.Show("Tên Loại Phòng đã tồn tại");
                    return;
                }
                else if (db.LoaiPhongs.Select(m => m.ID).Contains(id))
                {
                    MessageBox.Show("ID đã tồn tại");
                    return;
                }
                else
                {
                    LoaiPhong p = new LoaiPhong()
                    {
                        ID = id,
                        TenLP = ten,
                        Gia = gia,
                        TienPhuThu = tienphuthu,
                        SoGiuong = sogiuong,
                        SoNguoiToiDaTrenGiuong = songuoitoida

                    };

                    db.LoaiPhongs.Add(p);
                    db.SaveChanges();
                    MessageBox.Show("Thêm Loại Phòng thành công");
                    Loaddtgv();
                    LoadCbb();
                }
            }
        }

        void XoaLoaiPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {

                int id = Int32.Parse(txbIDLoaiPhong.Text);
                string idLP = id.ToString();
                int idloaiPhongs;
                bool isValid = int.TryParse(idLP, out idloaiPhongs);
                if (isValid)
                {
                    bool isUsed = db.Phongs.Any(p => p.idLoaiPhong == idloaiPhongs);
                    if (isUsed)
                    {
                        MessageBox.Show("Không được xóa Loại Phòng vì có Phòng đang sử dụng nó.");
                    }
                    else
                    {
                        // Thực hiện xóa LoaiPhongs
                        var loaiPhongs = db.LoaiPhongs.FirstOrDefault(lp => lp.ID == idloaiPhongs);
                        if (loaiPhongs != null)
                        {
                            db.LoaiPhongs.Remove(loaiPhongs);
                            db.SaveChanges();
                            MessageBox.Show("Xóa loại phòng thành công");
                            LoadLoaiPhong(dtgvLoaiPhong);
                            LoadPhong(dgtvphong);
                            LoadLoaiPhong(cbbLoaiPhong);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy LoaiPhongs cần xóa.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("ID LoaiPhongs không hợp lệ.");
                }
                Loaddtgv();
                LoadCbb();
            }
        }

        void SuaLoaiPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int id = Int32.Parse(txbIDLoaiPhong.Text);
                LoaiPhong loai = db.LoaiPhongs.Find(id);

                string ten = txbTenLoaiPhong.Text;
                decimal gia = decimal.Parse(txbGiaLoaiPhong.Text);
                decimal tienphuthu = decimal.Parse(txbTienPhuThu.Text);
                int sogiuong = Int32.Parse(txbSoGiuongLoaiPhong.Text);
                int songuoitoida = Int32.Parse(txbSoNguoiToiDa.Text);

                loai.TenLP = ten;
                loai.Gia = gia;
                loai.TienPhuThu = tienphuthu;
                loai.SoGiuong = sogiuong;
                loai.SoNguoiToiDaTrenGiuong = songuoitoida;


                db.SaveChanges();
                MessageBox.Show("Sửa Loại phòng thành công");
                Loaddtgv();
                LoadCbb();
            }
        }

        private void Dtgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvLoaiPhong.Columns[e.ColumnIndex].Name == "Giá" && e.Value != null)
            {
                if (e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,###.###");
                    e.FormattingApplied = true;
                }
            }
            if (dtgvLoaiPhong.Columns[e.ColumnIndex].Name == "Tiền_Phụ_Thu" && e.Value != null)
            {
                if (e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,###.###");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnThemLoaiPhong_Click(object sender, EventArgs e)
        {
            ThemLoaiPhong();
        }

        private void btnXoaLoaiPhong_Click(object sender, EventArgs e)
        {
            XoaLoaiPhong();
        }

        private void btnSuaLoaiPhong_Click(object sender, EventArgs e)
        {
            SuaLoaiPhong();
        }

        #endregion

        #region ChuaDung
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void tmiTenNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region CoSoVatTu
        void LoadCoSoVatTu(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from vt in db.CoSoVatChats
                             select new
                             {
                                 ID = vt.ID,
                                 Tên = vt.TenCSVC,
                                 Hạn_Sử_Dụng = vt.HanSuDung,
                                 Giá_Bồi_Thường = vt.GiaBoiThuong
                             };
                dtgv.DataSource = source.ToList();
            }
            BindingCoSoVatChat(dtgvCoSoVatChat);
        }

        void BindingCoSoVatChat(DataGridView dtgv)
        {
            Binding bdID = new Binding("Text", dtgv.DataSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txbIDCoSoVatTu.DataBindings.Clear();
            txbIDCoSoVatTu.DataBindings.Add(bdID);

            Binding bdTen = new Binding("Text", dtgv.DataSource, "Tên", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTenCoSoVatTu.DataBindings.Clear();
            txbTenCoSoVatTu.DataBindings.Add(bdTen);

            Binding bdHanSuDung = new Binding("Text", dtgv.DataSource, "Hạn_Sử_Dụng", true, DataSourceUpdateMode.OnPropertyChanged);
            txbHanSuDung.DataBindings.Clear();
            txbHanSuDung.DataBindings.Add(bdHanSuDung);

            Binding bdGiaBoiThuong = new Binding("Text", dtgv.DataSource, "Giá_Bồi_Thường", true, DataSourceUpdateMode.OnPropertyChanged);
            txbGiaBoiThuong.DataBindings.Clear();
            txbGiaBoiThuong.DataBindings.Add(bdGiaBoiThuong);

        }

        #endregion

        #region TrangThaiThuePhong
        void LoadTrangThaiThuePhong(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from thue in db.BangThuePhongs
                             from p in db.Phongs
                             from t in db.TrangThaiThuePhongs
                             from kh in db.KhachHangs
                            // from l in db.LoaiPhongs
                             where thue.idPhong.Equals(p.ID)
                             && thue.idTrangThaiThuePhong.Equals(t.ID)
                             && thue.idKhachHang.Equals(kh.ID)
                             
                             select new
                             {
                                 ID = thue.ID,
                                 Tên_Phòng = p.TenP,
                                 Trạng_Thái = t.TenTTTP,
                                 Khách_Hàng = kh.ID,
                                 Ngày_Đặt = thue.NgayDat,
                                 CheckIn = thue.CheckIn,
                                 CheckOut = thue.CheckOut,
                                 Số_Người_Lớn = thue.SoLuongNguoiLon,
                                 Số_Trẻ_Em = thue.SoLuongTreEm,
                                 Giá =  thue.TongTien
                             };
                dtgv.DataSource = source.ToList();
            }
            dtgv.CellFormatting += Dtgv_CellFormattingThuePhong;
            BindingBangThuePhong(dtgvPhongThuePhong);
        }
        private void Dtgv_CellFormattingThuePhong(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgvPhongThuePhong.Columns[e.ColumnIndex].Name == "Giá" && e.Value != null)
            {
                if (e.Value is decimal)
                {
                    e.Value = ((decimal)e.Value).ToString("#,###.###");
                    e.FormattingApplied = true;
                }
            }
        }
        void BindingBangThuePhong(DataGridView dtgv)
        {
            Binding bdID = new Binding("Text", dtgv.DataSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged);
            txbIDThuePhong.DataBindings.Clear();
            txbIDThuePhong.DataBindings.Add(bdID);

            Binding bdKH = new Binding("Text", dtgv.DataSource, "Khách_Hàng", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTenKhachHangThue.DataBindings.Clear();
            txbTenKhachHangThue.DataBindings.Add(bdKH);

            Binding bdNguoiLon = new Binding("Text", dtgv.DataSource, "Số_Người_Lớn", true, DataSourceUpdateMode.OnPropertyChanged);
            txbNguoiLon.DataBindings.Clear();
            txbNguoiLon.DataBindings.Add(bdNguoiLon);

            Binding bdTreEm= new Binding("Text", dtgv.DataSource, "Số_Trẻ_Em", true, DataSourceUpdateMode.OnPropertyChanged);
            txbTreEm.DataBindings.Clear();
            txbTreEm.DataBindings.Add(bdTreEm);

            Binding bdCheckIn = new Binding("Value", dtgv.DataSource, "CheckIn", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpkNgayBatDauBieuDo.DataBindings.Clear();
            dtpkNgayBatDauBieuDo.DataBindings.Add(bdCheckIn);

            Binding bdCheckOut = new Binding("Value", dtgv.DataSource, "CheckOut", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpkNgayKetThucBieuDo.DataBindings.Clear();
            dtpkNgayKetThucBieuDo.DataBindings.Add(bdCheckOut);

            Binding bdDay = new Binding("Value", dtgv.DataSource, "Ngày_Đặt", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpkNgayDat.DataBindings.Clear();
            dtpkNgayDat.DataBindings.Add(bdDay);
        }
        void LoadTenPhong(ComboBox cb)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                cb.DataSource = db.Phongs.ToList();
                cb.DisplayMember = "TenP";
            }
        }

        void DatPhong()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int id = 1;
                if (db.BangThuePhongs.Any())
                {
                    id = db.BangThuePhongs.Max(m => m.ID) + 1;
                }

                string kh = txbTenKhachHangThue.Text;
                string p = (cbbTenPhong.SelectedValue as Phong).ID;
                DateTime ngayBatDau = dtpkNgayBatDauBieuDo.Value;
                DateTime ngayKetThuc = dtpkNgayKetThucBieuDo.Value;
                DateTime ngayDat = dtpkNgayDat.Value;
                Decimal? tongtien = 0; 
               
                Phong phong = db.Phongs.SingleOrDefault(m => m.ID == p);
                LoaiPhong loai = db.LoaiPhongs.SingleOrDefault(l => l.ID == phong.idLoaiPhong);
              
                TimeSpan duration = ngayKetThuc - ngayBatDau;
                tongtien = loai.Gia * (decimal)duration.TotalDays;

                if (db.Phongs.Any(t => t.ID == p && t.idTinhTrangPhong == 2))
                {
                    MessageBox.Show("Phòng Đang Bảo Trì");
                    return;
                }

                if (!db.KhachHangs.Any(k => k.ID == kh))
                {
                    MessageBox.Show("Không Có Khách Hàng Này");
                    return;
                }

                if (DateTime.Compare(ngayBatDau, ngayKetThuc) >= 0)
                {
                   MessageBox.Show("CheckOut Phải khác CheckIn ");
                   return;
                }

                int nl;
                if (!Int32.TryParse(txbNguoiLon.Text, out nl))
                {
                    MessageBox.Show("Số lượng người lớn không hợp lệ");
                    return;
                }

                int te;
                if (!Int32.TryParse(txbTreEm.Text, out te))
                {
                    MessageBox.Show("Số lượng trẻ em không hợp lệ");
                    return;
                }

                if (db.BangThuePhongs.Any(m => m.idPhong == p && (m.CheckOut > ngayBatDau && m.CheckIn < ngayKetThuc)))
                {
                    MessageBox.Show("Phòng đã có người đặt hoặc đang được sử dụng trong khoảng thời gian này");
                    return;
                }

                BangThuePhong tp = new BangThuePhong()
                {
                  
                    ID = id,
                    idPhong = p,
                    idTrangThaiThuePhong = 1,
                    idKhachHang = kh,
                    NgayDat = ngayDat,
                    CheckIn = ngayBatDau,
                    CheckOut = ngayKetThuc,
                    SoLuongNguoiLon = nl,
                    SoLuongTreEm = te,
                    TongTien = tongtien
                    
                };
                db.BangThuePhongs.Add(tp);
                db.SaveChanges();
                MessageBox.Show("Đặt phòng thành công");
                Loaddtgv();
            }
        }
        void TimPhongThue(DataGridView dtgv)
        {
            string tuKhoa = txbThongTinKhachThue.Text.Trim();
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from thue in db.BangThuePhongs
                             from p in db.Phongs
                             from t in db.TrangThaiThuePhongs
                             from kh in db.KhachHangs
                                 // from l in db.LoaiPhongs
                             where thue.idPhong.Equals(p.ID)
                             && thue.idTrangThaiThuePhong.Equals(t.ID)
                             && thue.idKhachHang.Equals(kh.ID)
                              && (string.IsNullOrEmpty(tuKhoa) || kh.ID.Contains(tuKhoa))

                             select new
                             {
                                 ID = thue.ID,
                                 Tên_Phòng = p.TenP,
                                 Trạng_Thái = t.TenTTTP,
                                 Khách_Hàng = kh.ID,
                                 Ngày_Đặt = thue.NgayDat,
                                 CheckIn = thue.CheckIn,
                                 CheckOut = thue.CheckOut,
                                 Số_Người_Lớn = thue.SoLuongNguoiLon,
                                 Số_Trẻ_Em = thue.SoLuongTreEm,
                                 Giá = thue.TongTien
                             };
                dtgv.DataSource = source.ToList();
            }
            dtgv.CellFormatting += Dtgv_CellFormattingThuePhong;
            BindingBangThuePhong(dtgvPhongThuePhong);
        }

        void Checkout()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string kh = txbTenKhachHangThue.Text;
                DateTime ngayKetThuc = dtpkNgayKetThucBieuDo.Value;

                var phongthue = db.BangThuePhongs.Where(m => m.idKhachHang == kh && m.CheckOut == ngayKetThuc).ToList();

                if (phongthue.Any())
                {
                    if (phongthue.All(m => m.idTrangThaiThuePhong == 2))
                    {
                        MessageBox.Show("Các Phòng Này Đã Được Thanh Toán");
                        return;
                    }
                    else
                    {
                        Cons.CheckOut.ThanhToan = phongthue;
                        ThanhToan f = new ThanhToan();
                        f.Show();
                        this.Hide();
                        return;
                    }
                }

                MessageBox.Show("Không có Khách Này Và Không Thuê Phòng");
                //int tp = Int32.Parse(txbIDThuePhong.Text);
                /*string kh = txbTenKhachHangThue.Text;
                DateTime ngayKetThuc = dtpkNgayKetThucBieuDo.Value;


                if (db.BangThuePhongs.Any(m => m.idTrangThaiThuePhong == 2))
                {
                    MessageBox.Show("Các Phòng Này Đã Được Thanh Toán");
                    return;
                }
                else if(!db.BangThuePhongs.Any(m => m.idKhachHang == kh && m.CheckOut == ngayKetThuc))
                {

                    MessageBox.Show("Không có Khách Này Và Không Thuê Phòng");
                    return;
                }
                else
                {
                    List<BangThuePhong> phongthue = db.BangThuePhongs.Where(m => m.idKhachHang == kh && m.CheckOut == ngayKetThuc).ToList();
                    Cons.CheckOut.ThanhToan = phongthue;
                    ThanhToan f = new ThanhToan();
                    f.Show();
                    this.Hide();
                }*/
                //if (db.BangThuePhongs.Any(t => t.idKhachHang == kh))
                //{

                //BangThuePhong thue = db.BangThuePhongs.Single(p => p.ID == tp);
                //StringBuilder sb = new StringBuilder();
            }
                
        }

        void TimPhongTrong(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                DateTime? ngaybatdau = dtpkNgayBatDauBieuDo.Value;
                DateTime? ngayketthuc = dtpkNgayKetThucBieuDo.Value;

                var phongs = (from p in db.Phongs
                              join l in db.LoaiPhongs on p.idLoaiPhong equals l.ID
                              join t in db.TinhTrangPhongs on p.idTinhTrangPhong equals t.ID
                              select new
                              {
                                  ID = p.ID,
                                  Tên = p.TenP,
                                  Loại = l.TenLP,
                                  Tình_Trạng = t.TenTTP,
                                  Giá = l.Gia,
                                  Số_Giường = l.SoGiuong
                              }).ToList();

                var filteredPhongs = phongs.Where(p => !db.BangThuePhongs.Any(m => m.idPhong == p.ID && m.CheckOut > ngaybatdau && m.CheckIn < ngayketthuc));

                dtgv.DataSource = filteredPhongs.ToList();
            }
        }


        void LoadDichVu(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from dv in db.DichVus

                             select new
                             {
                                 ID = dv.ID,
                                 Tên_Dịch_Vụ = dv.TenDV,
                                 Giá = dv.Gia
                             };
                dtgv.DataSource = source.ToList();
            }
        }

        void LoadSuDungDichVu(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int id = Int32.Parse(txbIDThuePhong.Text);

                var source = from dv in db.DichVus
                             join sd in db.SuDungDichVus on dv.ID equals sd.idDichVu
                             join thue in db.BangThuePhongs on sd.idBangThuePhong equals thue.ID
                             join kh in db.KhachHangs on thue.idKhachHang equals kh.ID
                             where thue.ID.Equals(id)
                             select new
                             {
                                 Tên_Dịch_Vụ = dv.TenDV,
                                 Số_Lượng = sd.SoLuong,
                                 Giá = sd.TongTien
                             };
                dtgv.DataSource = source.ToList();
            }
        }

        private void btnTimPhongThue_Click(object sender, EventArgs e)
        {
            TimPhongThue(dtgvPhongThuePhong);
        }

        private void btnTaiLaiThue_Click(object sender, EventArgs e)
        {
            LoadTrangThaiThuePhong(dtgvPhongThuePhong);
            txbThongTinKhachThue.Clear();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Checkout();
        }

        void LoadTenDichVu(ComboBox cb)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                cb.DataSource = db.DichVus.ToList();
                cb.DisplayMember = "TenDV";
            }
        }

        void DatDV()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int id = 1;
                if (db.SuDungDichVus.Any())
                {
                    id = db.SuDungDichVus.Max(m => m.ID) + 1;
                }

                int thue = Int32.Parse(txbIDThuePhong.Text);
                string tenDichVu = (cbbDichVu.SelectedItem as DichVu).TenDV;
                int sl = Int32.Parse(txbSoLuong.Text);

                var dichVuInfo = db.DichVus.FirstOrDefault(d => d.TenDV == tenDichVu);
                decimal gia = (decimal)dichVuInfo.Gia;
                decimal sll = sl;
                // Tính tổng tiền
                decimal tongTien = gia * sll;

                SuDungDichVu sd = new SuDungDichVu()
                {
                    ID = id,
                    idBangThuePhong = thue,
                    idDichVu = dichVuInfo.ID,
                    SoLuong = sl,
                    TongTien = tongTien
                };

                db.SuDungDichVus.Add(sd);
                db.SaveChanges();
                MessageBox.Show("Thêm dịch vụ thành công");
                Loaddtgv();
            }
        }

        #endregion
        #region Khach
        void LoadThongTinKhachHang(DataGridView dtgv)
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                var source = from kh in db.KhachHangs
                             select new
                             {
                                 CMND = kh.ID,
                                 Họ_Tên = kh.TenKH,
                                 Giới_Tính = kh.GioiTinh.HasValue ? (kh.GioiTinh.Value ? "Nam" : "Nữ") : string.Empty,
                                 Ngày_Sinh = kh.NgaySinh,
                                 Quoc_Tich = kh.QuocTich
                             };
                dtgv.DataSource = source.ToList();
            }
        }
        void Them()
        {
            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                string id = txbCMND.Text;
                //string id = (Int32.Parse(db.Phongs.Select(m => m.ID).Max()) + 1).ToString();
                string ten = txbTenKH.Text;

                if (string.IsNullOrEmpty(ten))
                {
                    MessageBox.Show("Tên Không Được Để Trống");
                    return;
                }

                KhachHang kh = new KhachHang()
                {
                    ID = id,
                     TenKH = ten
                };

                db.KhachHangs.Add(kh);
                db.SaveChanges();
                MessageBox.Show("Thêm khách thành công");
                Loaddtgv();
                LoadCbb();
            }
        }

        #endregion
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void đỗiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau();
            f.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimKiem(dgtvphong);
        }

        #region An
        void AnQuanLy()
        {

            using (KHACHSANEntities db = new KHACHSANEntities())
            {
                int coll = Cons.content.LoginNhanVien.IDChucDanh;
                if(coll == 2)
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
                if (coll == 1)
                {
                    đăngXuấtToolStripMenuItem.Visible = true;
                }
                else
                {
                    đăngXuấtToolStripMenuItem.Visible = false;
                }
            }
        }
        #endregion

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            f.Show();
            this.Close();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
           DatPhong();
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }


        private void cbbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpkNgayKetThucBieuDo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnTimPhongTrong_Click(object sender, EventArgs e)
        {
            TimPhongTrong(dtgvXemPhong);
        }

        private void btnSuDungDichVu_Click(object sender, EventArgs e)
        {
          
            LoadDichVu(dtgvXemPhong);
        }

        private void btnXemDichVu_Click(object sender, EventArgs e)
        {
            LoadSuDungDichVu(dtgvSuDungDichVu);
        }

        private void btnCCCCC_Click(object sender, EventArgs e)
        {
            DatDV();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tpQuanLyThuePhong_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Them();
        }
    }
}
