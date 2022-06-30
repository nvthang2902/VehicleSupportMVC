using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using PagedList;

namespace Demo.Controllers
{
    public class LoginCoSoDichVuController : Controller
    {
        // GET: LoginCoSoDichVu
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: DichVu
        public ActionResult Index(string searchS, int? page, string sortOrder, string CurrentSort)
        {
            //return View(_db.DichVus.Where(x => x.TenDichVu.StartsWith(searchS) || searchS == null)
            //.OrderByDescending(s=>s.IdDV).ToPagedList(page ?? 1, 5));
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "IdDV" : sortOrder;
            IPagedList<DichVu> dichVus = null;
            switch (sortOrder)
            {
                case "IdDV":
                    if (sortOrder.Equals(CurrentSort))
                        dichVus = _db.DichVus.OrderByDescending
                                (m => m.IdDV).ToPagedList(pageIndex, pageSize);
                    else
                        dichVus = _db.DichVus.OrderBy
                                (m => m.IdDV).ToPagedList(pageIndex, pageSize);
                    break;
                case "TenDichVu":
                    if (sortOrder.Equals(CurrentSort))
                        dichVus = _db.DichVus.OrderByDescending
                                (m => m.TenDichVu).ToPagedList(pageIndex, pageSize);
                    else
                        dichVus = _db.DichVus.OrderBy
                                (m => m.TenDichVu).ToPagedList(pageIndex, pageSize);
                    break;
                case "GiaDV":
                    if (sortOrder.Equals(CurrentSort))
                        dichVus = _db.DichVus.OrderByDescending
                                (m => m.GiaDV).ToPagedList(pageIndex, pageSize);
                    else
                        dichVus = _db.DichVus.OrderBy
                                (m => m.GiaDV).ToPagedList(pageIndex, pageSize);
                    break;
                case "MoTa":
                    if (sortOrder.Equals(CurrentSort))
                        dichVus = _db.DichVus.OrderByDescending
                                (m => m.MoTa).ToPagedList(pageIndex, pageSize);
                    else
                        dichVus = _db.DichVus.OrderBy
                                (m => m.MoTa).ToPagedList(pageIndex, pageSize);
                    break;
                case "ImageDV":
                    if (sortOrder.Equals(CurrentSort))
                        dichVus = _db.DichVus.OrderByDescending
                                (m => m.ImageDV).ToPagedList(pageIndex, pageSize);
                    else
                        dichVus = _db.DichVus.OrderBy
                                (m => m.ImageDV).ToPagedList(pageIndex, pageSize);
                    break;
                case "Default":
                    break;
            }
            return View(_db.DichVus.Where(x => x.TenDichVu.StartsWith(searchS) || searchS == null)
            .OrderByDescending(s => s.IdDV).ToPagedList(pageIndex, pageSize));
        }

    }
}