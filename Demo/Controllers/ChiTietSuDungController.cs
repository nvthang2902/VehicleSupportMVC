using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Demo.Controllers
{
    public class ChiTietSuDungController : Controller
    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: ChiTietSuDung
        public ActionResult Index(string searchS, int? page)
        {
            return View(_db.ChiTietSuDungDVs.Where(x => x.DichVu.TenDichVu.StartsWith(searchS) || searchS == null)
                .OrderByDescending(s=>s.IdSDDV).ToPagedList(page ?? 1, 5));
        }
    }
}