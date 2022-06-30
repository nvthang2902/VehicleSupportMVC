using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Demo.Extensions;

namespace Demo.Controllers
{
    public class LoginController : Controller
    {
        CuuHoXe_Entities _db = new CuuHoXe_Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(TaiKhoan _user)
        {
            if (ModelState.IsValidField("TenTK") && ModelState.IsValidField("MatKhau"))
            {
                
                var login = _db.TaiKhoans.Where(u => u.Status == false && u.TenTK.Equals(_user.TenTK) && u.MatKhau.Equals(_user.MatKhau)).FirstOrDefault();
                if (login == null)
                {
                    
                    this.AddNotification("Login failed", NotificationType.ERROR);
                    return View("Index");
                }
                else
                {
                    var check = _db.TaiKhoans.FirstOrDefault(s => s.TenTK == _user.TenTK);
                    if (check.TenTK != "admin" && check.TenTK != "ctv1")
                    {
                        TempData["TenTK"] = login.TenTK;
                        TempData["Id"] = login.Id;

                        TempData.Keep("Id"); TempData.Keep("TenTK");

                        return RedirectToAction("DemoChatBox", "HomeCustomer");
                    }
                    else if (check.TenTK == "ctv1")
                    {
                        return RedirectToAction("Index", "LoginCoSoDichVu");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }

            }

            return View(_user);
        }
        public ActionResult ResetPassword()
        {
            if (TempData["TenTK"] == null)
            {
                return RedirectToAction("Index");
            }
            else { }
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string password, string newPassword, string confirmPass)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            string user = TempData["TenTK"].ToString();
            int id = int.Parse(TempData["Id"].ToString());
            var login = _db.TaiKhoans.Where(u => u.Status == false && u.TenTK.Equals(user) && u.Id.Equals(id)).FirstOrDefault();
            if (login.MatKhau == password)
            {
                if (confirmPass == newPassword)
                {
                    login.XacNhanMK = confirmPass;
                    login.MatKhau = newPassword;
                    _db.Entry(login).State = EntityState.Modified;
                    _db.SaveChanges();
                    TempData["msg"] = "<script>alert('Đổi mật khẩu thành công !!!');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Mật khẩu mới sai !!! Mời nhập lại!');</script>";
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Mật khẩu cũ không đúng !!! Mời nhập lại!');</script>";
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(TaiKhoan _user)
        {
            if (ModelState.IsValid)
            {
                var check = _db.TaiKhoans.FirstOrDefault(s => s.TenTK == _user.TenTK);
                if (check == null)//chua dc su dung trong db
                {
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.TaiKhoans.Add(_user);
                    _db.SaveChanges();
                    //neu ma dang ki thanh cong thi chuyen huong trang register sang page login
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "TenTK is exist! Use another TenTK pls";
                    return View();
                }
            }
            return View();
        }


        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");//method login la index
        }

        public ActionResult _HeaderLayoutTest()
        {
            if (TempData["TenTK"] == null)
            {
                return RedirectToAction("Index");
            }
            else { }

            return View();
        }

    }
}