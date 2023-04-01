using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webMoTo.Models;

namespace webMoTo.Controllers
{
    public class LoaiMoTosController : Controller
    {
        // GET: LoaiMoTos
        MyDataDataContext Data = new MyDataDataContext();
        public ActionResult Index()
        {
            var allLoai = from tt in Data.LoaiMoTos select tt;
            return View(allLoai);
           
        }
        public ActionResult Details(string id)
        {

            var Detail_TheLoai = Data.LoaiMoTos.Where(m => m.LoaiId == id).First();
            return View(Detail_TheLoai);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, LoaiMoTo tl)
        {
            var ten = collection["Tên Hãng"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                tl.TenLoai = ten;
                Data.LoaiMoTos.InsertOnSubmit(tl);
                Data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_category = Data.LoaiMoTos.First(m => m.LoaiId == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var theloai = Data.LoaiMoTos.First(m => m.LoaiId == id);
            var E_tenloai = collection["tenloai"];
            theloai.LoaiId = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                theloai.TenLoai = E_tenloai;
                UpdateModel(theloai);
                Data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(string id)
        {
            var D_theloai = Data.LoaiMoTos.First(m => m.LoaiId == id);
            return View(D_theloai);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_theloai = Data.LoaiMoTos.Where(m => m.LoaiId == id).First();
            Data.LoaiMoTos.DeleteOnSubmit(D_theloai);
            Data.SubmitChanges();
            return RedirectToAction("Index");
        }


    }
}
