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
    
    public partial class TinTuc
    {
        public int IDTin { get; set; }
        public Nullable<int> IDLoaiTin { get; set; }
        public string TieuDeTin { get; set; }
        public Nullable<System.DateTime> NgayDang { get; set; }
        public string MoTaTomTat { get; set; }
        public string MoTaChiTiet { get; set; }
    
        public virtual LoaiTinTuc LoaiTinTuc { get; set; }
    }
}