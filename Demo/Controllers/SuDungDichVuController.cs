using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class SuDungDichVuController : Controller
    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: SuDungDichVu
        public ActionResult Index()
        {
            return View(_db.SuDungDichVus.ToList());
        }
    }
}