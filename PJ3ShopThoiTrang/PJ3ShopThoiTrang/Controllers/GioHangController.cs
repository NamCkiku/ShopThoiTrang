using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;

namespace PJ3ShopThoiTrang.Controllers
{
    public class GioHangController : Controller
    {
        private const string CartSession = "CartSession";
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            var sp = db.SanPhams.Find(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var itemProduct = ((List<CartItem>)cart).SingleOrDefault(x => x.Sanpham.IDSanPham == productId);
                //Ktra neu ton tai SP roi thi tang so luong
                if (itemProduct != null)
                {
                    itemProduct.SoLuong += quantity;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.Sanpham = sp;
                    item.SoLuong = quantity;
                    ((List<CartItem>)cart).Add(item);
                }
                //Gán vào session
                Session[CartSession] = (List<CartItem>)cart;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.Sanpham = sp;
                item.SoLuong = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        public int soluong { get; set; }

        public SanPham Sanpham { get; set; }
        public ActionResult Order()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        //public ActionResult Order(FormCollection fr)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HoaDon hd = new HoaDon();
        //        string hoten = fr["nguoinhan"];
        //        int dienthoai = int.Parse(fr["dienthoai"]);
        //        string diachi = fr["diachi"];
        //        hd.HoTen = hoten;
        //        hd.DiaChi = diachi;
        //        hd.SDT = dienthoai;
        //        hd.NgayLap = DateTime.Now;
        //        db.HoaDons.Add(hd);

        //        var cart = (List<CartItem>)Session[CartSession];
        //        foreach (var item in cart)
        //        {
        //            var chitiet = new ChiTietHoaDon();
        //            chitiet.IDHoaDon = hd.IDHoaDon;
        //            chitiet.IDSanPham = item.Sanpham.IDSanPham;
        //            chitiet.SoLuong = item.SoLuong;
        //            db.ChiTietHoaDons.Add(chitiet);
        //        }
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("XacNhan");
        //}
        public ActionResult XacNhan()
        {
            return View();
        }
    }
}
