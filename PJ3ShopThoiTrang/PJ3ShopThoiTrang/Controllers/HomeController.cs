using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PJ3ShopThoiTrang.Models;

namespace PJ3ShopThoiTrang.Controllers
{
    public class HomeController : Controller
    {
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Index(int page = 1)
        {
            var loaisanpham = db.LoaiSanPhams.ToList();
            var pg = db.SanPhams.OrderByDescending(v => v.IDSanPham).ToPagedList(page, 3);
            var sanpham = (from p in db.SanPhams orderby p.IDSanPham descending select p).ToList();
            return View(Tuple.Create(loaisanpham, sanpham, pg));
        }
        public ActionResult ChiTietSanPham(int id)
        {
            return View(db.SanPhams.Find(id));
        }
        public ActionResult Search(FormCollection fr)
        {
            string name = fr["name"];
            if (name != null)
            {
                List<SanPham> data = db.SanPhams.Where(p => p.TenSanPham.Contains(name)).ToList();
                return View(data);
            }
            else
            {
                return View();
            }

        }
    }
}
