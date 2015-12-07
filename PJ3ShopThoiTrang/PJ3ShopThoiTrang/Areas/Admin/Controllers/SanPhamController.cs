using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;

namespace PJ3ShopThoiTrang.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Create()
        {
            ViewBag.ListOfClientIDs = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "TenLoaiSanPham");
            return View();
        }
        //Thêm Sản Phẩm
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection connection)
        {
            if (ModelState.IsValid)
            {
                SanPham sp = new SanPham();
                int loaisanpham = int.Parse(connection["IDLoaiSanPham"]);
                int size = int.Parse(connection["secsize"]);
                string tensp = connection["txttensanpham"];
                string thuonghieu = connection["txtthuonghieu"];
                int giamua = int.Parse(connection["txtgiamua"]);
                int giaban = int.Parse(connection["txtgiaban"]);
                string mausac = connection["txtmausac"];
                string kieudang = connection["txtkieudang"];
                int soluong = int.Parse(connection["txtsoluong"]);
                DateTime ngaynhap = DateTime.Parse(connection["datengaynhap"]);
                string anh = connection["anhsp"];
                string mota = connection["txtmota"];
                sp.TenSanPham = tensp;
                sp.IDLoaiSanPham = loaisanpham;
                sp.IDSize = size;
                sp.ThuongHieu = thuonghieu;
                sp.GiaMua = giamua;
                sp.GiaBan = giaban;
                sp.MauSac = mausac;
                sp.KieuDang = kieudang;
                sp.SoLuong = soluong;
                sp.NgayNhap = ngaynhap;
                string path = "img/SanPham/";
                sp.Anh = path + anh;
                sp.MoTa = mota;
                db.SanPhams.Add(sp);
                int i = db.SaveChanges();
                if (i > 0)
                {
                    ViewBag.Msg = "Chúc Mừng Bạn Đã Nhập Thành Công";
                }
            }
            return RedirectToAction("Hien");
        }

        public ActionResult Hien()
        {
            var lst = db.SanPhams.ToList();
            return View(lst);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ListOfClientIDs = new SelectList(db.LoaiSanPhams, "IDLoaiSanPham", "TenLoaiSanPham");
            var sanpham = db.SanPhams.First(x => x.IDSanPham == id);
            return View(sanpham);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection connection)
        {
            var sp = db.SanPhams.First(x => x.IDSanPham == id);
            string tensp = connection["txttensanpham"];
            int loaisanpham = int.Parse(connection["IDLoaiSanPham"]);
            int size = int.Parse(connection["secsize"]);
            string thuonghieu = connection["txtthuonghieu"];
            int giamua = int.Parse(connection["GiaMua"]);
            int giaban = int.Parse(connection["GiaBan"]);
            string mausac = connection["MauSac"];
            string kieudang = connection["KieuDang"];
            int soluong = int.Parse(connection["SoLuong"]);
            DateTime ngaynhap = DateTime.Parse(connection["NgayNhap"]);
            string anh = connection["Anh"];
            string mota = connection["txtmota"];
            sp.TenSanPham = tensp;

            sp.IDLoaiSanPham = loaisanpham;
            sp.IDSize = size;
            sp.ThuongHieu = thuonghieu;
            sp.GiaMua = giamua;
            sp.GiaBan = giaban;
            sp.MauSac = mausac;
            sp.KieuDang = kieudang;
            sp.SoLuong = soluong;
            sp.NgayNhap = ngaynhap;
            string path = "img/SanPham/";
            sp.Anh = path + anh;
            sp.MoTa = mota;
            UpdateModel(sp);
            db.SaveChanges();
            return RedirectToAction("Hien");
        }
        public ActionResult Delete(int id = 0)
        {
            SanPham sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            SanPham sp = db.SanPhams.Find(id);
            db.SanPhams.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Hien");
        }
        public ActionResult Detail(int id = 0)
        {
            return View(db.SanPhams.Find(id));
        }
    }
}
