using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PJ3ShopThoiTrang.Models
{
    [Serializable]
    public class CartItem
    {
        public SanPham Sanpham { set; get; }
        public int SoLuong { set; get; }
    }
}