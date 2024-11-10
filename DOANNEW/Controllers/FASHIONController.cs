using DOANNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANNEW.Controllers
{
    public class FASHIONController : Controller
    {
        private TAPCHI2Entities db = new TAPCHI2Entities();
        // GET: FASHION
        public ActionResult Index()
        {
            // Lấy danh sách bài viết thuộc danh mục Fashion
            var fashionArticles = db.Bai_viet.Where(b => b.DanhMucID == 1).ToList(); // Thay 1 bằng ID thực tế của danh mục Fashion
            return View(fashionArticles);
        }
       
        public PartialViewResult DanhMucList()
        {
            var danhmuclist =db.Danh_Muc.ToList();
            return PartialView(danhmuclist);
        }
    }
}