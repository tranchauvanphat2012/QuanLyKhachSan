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
    
    public partial class User
    {
        public string ID { get; set; }
        public string Pass { get; set; }
        public string idNhanVien { get; set; }
    
        public virtual NhanVien NhanVien { get; set; }
    }
}
