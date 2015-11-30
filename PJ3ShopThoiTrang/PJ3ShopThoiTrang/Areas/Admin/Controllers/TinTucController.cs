using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PJ3ShopThoiTrang.Models;
namespace PJ3ShopThoiTrang.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        ShopThoiTrangEntities db = new ShopThoiTrangEntities();
        public ActionResult Hien()
        {
            var tt = db.TinTucs.ToList();
            return View(tt);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(FormCollection connection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TinTuc tt = new TinTuc();
                    int loaitin = int.Parse(connection["secloaitin"]);
                    string tieudetin = connection["txttieudetin"];
                    DateTime ngaydang = DateTime.Parse(connection["datengaynhap"]);
                    string motatomtat = connection["txtmotatomtat"];
                    string motachitiet = connection["txtmotachitiet"];
                    tt.IDLoaiTin = loaitin;
                    tt.TieuDeTin = tieudetin;
                    tt.NgayDang = ngaydang;
                    tt.MoTaTomTat = motatomtat;
                    tt.MoTaChiTiet = motachitiet;
                    db.TinTucs.Add(tt);
                    db.SaveChanges();
                }
                return RedirectToAction("Hien");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }
        public ActionResult Edit(int id)
        {
            var tintuc = db.TinTucs.First(x => x.IDTin == id);
            return View(tintuc);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, FormCollection connection)
        {
            var tt = db.TinTucs.First(x => x.IDTin == id);
            int loaitin = int.Parse(connection["secloaitin"]);
            string tieudetin = connection["TieuDeTin"];
            DateTime ngaydang = DateTime.Parse(connection["NgayDang"]);
            string motatomtat = connection["MoTaTomTat"];
            string motachitiet = connection["MoTaChiTiet"];
            tt.IDLoaiTin = loaitin;
            tt.TieuDeTin = tieudetin;
            tt.NgayDang = ngaydang;
            tt.MoTaTomTat = motatomtat;
            tt.MoTaChiTiet = motachitiet;
            UpdateModel(tt);
            db.SaveChanges();
            return RedirectToAction("Hien");
        }
        public ActionResult Delete(int id = 0)
        {
            TinTuc tt = db.TinTucs.Find(id);
            if (tt == null)
            {
                return HttpNotFound();
            }
            return View(tt);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            TinTuc tt = db.TinTucs.Find(id);
            db.TinTucs.Remove(tt);
            db.SaveChanges();
            return RedirectToAction("Hien");
        }
        public ActionResult Detail(int id = 0)
        {
            return View(db.TinTucs.Find(id));
        }
    }
}
