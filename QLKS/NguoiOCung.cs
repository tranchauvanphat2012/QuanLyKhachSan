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
    
    public partial class NguoiOCung
    {
        public int ID { get; set; }
        public int idBangThuePhong { get; set; }
        public string idNguoiOCung { get; set; }
    
        public virtual BangThuePhong BangThuePhong { get; set; }
        public virtual KhachHang KhachHang { get; set; }
    }
}
