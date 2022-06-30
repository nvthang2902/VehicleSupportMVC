using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using PagedList;
using PagedList.Mvc;
using System.Configuration;
using System.IO;
using System.Data;
using Demo.Common;

namespace Demo.Controllers
{
    public class UserController : Controller
    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: User
        public ActionResult Index(string searchS, int? page, string sortOrder, string CurrentSort)
        {
            //return View(_db.TaiKhoans.Where(x => x.TenTK.StartsWith(searchS) || searchS == null)
            //    .OrderBy(s=>s.TenTK).ToPagedList(page ?? 1, 5));
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "TenTK" : sortOrder;
            IPagedList<TaiKhoan> taiKhoans = null;
            switch (sortOrder)
            {
                case "TenTK":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.TenTK).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.TenTK).ToPagedList(pageIndex, pageSize);
                    break;
                case "Email":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.Email).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.Email).ToPagedList(pageIndex, pageSize);
                    break;
                case "HoTen":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.HoTen).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.HoTen).ToPagedList(pageIndex, pageSize);
                    break;
                case "SoDienThoai":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.SoDienThoai).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.SoDienThoai).ToPagedList(pageIndex, pageSize);
                    break;
                case "DiaChi":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.DiaChi).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.DiaChi).ToPagedList(pageIndex, pageSize);
                    break;
                case "NgaySinh":
                    if (sortOrder.Equals(CurrentSort))
                        taiKhoans = _db.TaiKhoans.OrderByDescending
                                (m => m.NgaySinh).ToPagedList(pageIndex, pageSize);
                    else
                        taiKhoans = _db.TaiKhoans.OrderBy
                                (m => m.NgaySinh).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    break;
            }
            return View(_db.TaiKhoans.Where(x => x.TenTK.StartsWith(searchS) || searchS == null).OrderBy
                        (m => m.TenTK).ToPagedList(pageIndex, pageSize));

        }

        //UserProfile


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.TaiKhoans.Where(s => s.Id == id).FirstOrDefault());
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }
        public bool IsNameExist(string name)
        {

            var result = _db.TaiKhoans.Any(c => c.TenTK == name);
            return result;
        }
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(TaiKhoan user)
        {
            if (ModelState.IsValid)
            {

                // TODO: Add insert logic here
                _db.TaiKhoans.Add(user);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View();

        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.TaiKhoans.Where(s => s.Id == id).FirstOrDefault());
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TaiKhoan user)
        {
            try
            {
                // TODO: Add update logic here
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5

        // POST: User/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            TaiKhoan user = _db.TaiKhoans.Find(id);
            _db.TaiKhoans.Remove(user);
            _db.SaveChanges();
            return View();
        }
        public ActionResult ProfileUser()
        {
            string userId = Convert.ToString(TempData["TenTK"]);
            return View(_db.TaiKhoans.Find(userId));
        }
        [HttpPost]
        public ActionResult ProfileUser(TaiKhoan user)
        {
            if (TempData["TenTK"] != null)
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add update logic here
                    _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return RedirectToAction("ProfileUser");

                }
                return View(user);
            }
            return RedirectToAction("Index");
        }

    }
}
