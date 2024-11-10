using DOANNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DOANNEW.Controllers
{
   
    public class AccountController : Controller
    {
        private TAPCHI2Entities db = new TAPCHI2Entities();
        // GET: Account
        public ActionResult DANGNHAP()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DANGNHAP(User user, Role role)
        {
            using (var db = new TAPCHI2Entities())
            {
                var nguoidung = db.Users.FirstOrDefault(u => u.Email == user.Email && u.UserPassword == user.UserPassword);
                if (nguoidung != null)
                {
                    FormsAuthentication.SetAuthCookie(nguoidung.UserName, false);
                    Session["Role"] = nguoidung.Roles.FirstOrDefault()?.RoleName; // luu vai tro nguoi dung trong Session 
                    return RedirectToAction("Index", "TrangChu");
                }

                ViewBag.ErrorMessage = "Invalid Username or Password";
                return View();
            }
        }
        public ActionResult DANGKY()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DANGKY(User user)
        {
            using (var db = new TAPCHI2Entities())
            {
                // Kiểm tra xem email đã tồn tại chưa
                var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ViewBag.ErrorMessage = "Email đã được sử dụng.";
                    return View(user);
                }

                // Thêm người dùng mới vào cơ sở dữ liệu
                db.Users.Add(user);
                db.SaveChanges();

                // Đăng nhập tự động sau khi đăng ký
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["Role"] = user.Roles.FirstOrDefault()?.RoleName; // Lưu vai trò người dùng vào Session

                return RedirectToAction("Index", "TrangChu");
            }

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["Role"] = null;  // Xóa session vai trò người dùng
            return RedirectToAction("DANGNHAP", "Account");
        }

    }
}