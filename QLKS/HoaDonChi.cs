//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLKS
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonChi
    {
        public int ID { get; set; }
        public string idNhanVien { get; set; }
        public string TenNguoiNhan { get; set; }
        public string LyDo { get; set; }
        public Nullable<bool> ChapNhan { get; set; }
        public Nullable<decimal> TongTien { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
