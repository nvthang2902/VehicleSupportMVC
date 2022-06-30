using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using PagedList;
using PagedList.Mvc;

namespace Demo.Controllers
{
    public class CoSoDichVuController : Controller
    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: CoSoDichVu
        public ActionResult Index(string searchS, int? page)
        {
            return View(_db.CoSoDichVus.Where(x => x.TenNCC.StartsWith(searchS) || searchS == null)
                .OrderByDescending(s => s.IdNCC).ToPagedList(page ?? 1, 5));
        }

        // GET: CoSoDichVu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoSoDichVu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoSoDichVu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CoSoDichVu/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.CoSoDichVus.Where(s => s.IdNCC == id).FirstOrDefault());
        }

        // POST: CoSoDichVu/Edit/5
        [HttpPost]
        public ActionResult Edit(CoSoDichVu pro, HttpPostedFileBase uploadhinh)
        {
            CoSoDichVu upro = _db.CoSoDichVus.FirstOrDefault(x => x.IdNCC == pro.IdNCC);
            upro.TenNCC = pro.TenNCC;
            upro.TenTK = pro.TenTK;
            upro.DiaChi = pro.DiaChi;
            upro.NgayDangKi = pro.NgayDangKi;

            if (uploadhinh != null && uploadhinh.ContentLength > 0)
            {
                int id = pro.IdNCC;

                string _FileName = "";
                int index = uploadhinh.FileName.IndexOf('.');
                _FileName = "pro" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                string _path = Path.Combine(Server.MapPath("~/Upload/images/"), _FileName);
                uploadhinh.SaveAs(_path);
                upro.ImageNCC = _FileName;
            }

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: CoSoDichVu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoSoDichVu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
