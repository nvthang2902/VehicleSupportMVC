using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Models;
using System.IO;
using PagedList;
using Demo.Extensions;

namespace Demo.Controllers
{
    public class DichVuController : Controller
    {
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
            .OrderByDescending(s=>s.IdDV).ToPagedList(pageIndex,pageSize));
        }

        // GET: DichVu/Details/5
        public ActionResult Details(int id)
        {
            return View(_db.DichVus.FirstOrDefault(x => x.IdDV == id));
        }

        // GET: DichVu/Create
        public ActionResult Create()
        {
            DichVu dichVu = new DichVu();
            return View(dichVu);
        }

        // POST: DichVu/Create
        [HttpPost]
        public ActionResult Create(DichVu pro/*,HttpPostedFileBase uploadhinh*/)
        {
            if (ModelState.IsValid)
            {
                if (pro.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(pro.ImageUpload.FileName);
                    string extension = Path.GetExtension(pro.ImageUpload.FileName);
                    fileName = fileName + extension;
                    pro.ImageDV = fileName;
                    pro.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Upload/images/"), fileName));
                }
                _db.DichVus.Add(pro);
                _db.SaveChanges();
                this.AddNotification("Thêm sản phẩm thành công", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(pro);
        }

        // GET: DichVu/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_db.DichVus.Where(s => s.IdDV == id).FirstOrDefault());
        }

        // POST: DichVu/Edit/5
        [HttpPost]
        public ActionResult Edit(DichVu pro, HttpPostedFileBase uploadhinh)
        {
            if (ModelState.IsValid)
            {
                DichVu upro = _db.DichVus.FirstOrDefault(x => x.IdDV == pro.IdDV);
                upro.TenDichVu = pro.TenDichVu;
                upro.GiaDV = pro.GiaDV;
                upro.MoTa = pro.MoTa;
                upro.IdNCC = pro.IdNCC;

                if (uploadhinh != null && uploadhinh.ContentLength > 0)
                {
                    int id = pro.IdDV;

                    string _FileName = "";
                    int index = uploadhinh.FileName.IndexOf('.');
                    _FileName = "pro" + id.ToString() + "." + uploadhinh.FileName.Substring(index + 1);
                    string _path = Path.Combine(Server.MapPath("~/Upload/images/"), _FileName);
                    uploadhinh.SaveAs(_path);
                    upro.ImageDV = _FileName;

                }
                _db.Entry(upro).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                this.AddNotification("Sửa thành công", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View(pro);
        }
        
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var dv = _db.DichVus.SingleOrDefault(x => x.IdDV == id);
                _db.DichVus.Remove(dv);
                _db.SaveChanges();
                this.AddNotification("Xóa thành công", NotificationType.SUCCESS);
                return this.Json(new { code = 200, msg = "Delete Success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return this.Json(new { code = 500, msg = "Fail" + e }, JsonRequestBehavior.AllowGet);
            }
        }

        
        public ActionResult ChooseCategory()
        {
            CoSoDichVu cate = new CoSoDichVu();
            cate.CategoryCSDV = _db.CoSoDichVus.ToList<CoSoDichVu>();

            return PartialView(cate);
        }
    }
}
