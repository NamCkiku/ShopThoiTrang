//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PJ3ShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        public KhachHang()
        {
            this.HoaDons = new HashSet<HoaDon>();
        }
    
        public int IDKhachHang { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
        public Nullable<int> SDT { get; set; }
        public Nullable<bool> LaAdmin { get; set; }
    
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
