using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using PagedList;
using System.IO;

namespace Demo.Controllers
{
    public class HomeCustomerController : Controller
    {
        // GET: HomeCustomer
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
       
        public ActionResult CoSoDichVuCusTest()
        {
            return View(_db.CoSoDichVus.ToList());
        }
        public ActionResult CSDV()
        {
            return View(_db.CoSoDichVus.ToList());
        }
        public ActionResult WelcomeHome()
        {
            return View();
        }
        
        public ActionResult DichVuCusTest()
        {

            return View(_db.DichVus.ToList());

        }
        public ActionResult DV()
        {

            return View(_db.DichVus.ToList());

        }
        public ActionResult ContactUs()
        {

            return View();

        }

        // GET: HomeCustomer/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.TaiKhoans.Where(s => s.Id == id).FirstOrDefault());
        }

        // GET: HomeCustomer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeCustomer/Create
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

        // GET: HomeCustomer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeCustomer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeCustomer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeCustomer/Delete/5
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
        [ChildActionOnly]
        public ActionResult _HeaderLayoutTest()
        {
            if (TempData["TenTK"] == null)
            {
                return RedirectToAction("index");
            }
            else { }
            
            return PartialView();
        }
        public ActionResult ChatBot()
        {
            return View();
        }
        public ActionResult Chatbotx()
        {
            return View();
        }
        public ActionResult DemoChatBox()
        {
            return View();
        }
    }
}
