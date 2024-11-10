﻿using DOANNEW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DOANNEW.Controllers
{
    public class ENTERTAIMENTController : Controller
    {
        private TAPCHI2Entities db = new TAPCHI2Entities();
        // GET: SPORT
        public ActionResult Index()
        {
            // Lấy danh sách bài viết thuộc danh mục Fashion
            var fashionArticles = db.Bai_viet.Where(b => b.DanhMucID == 3).ToList(); // Thay 1 bằng ID thực tế của danh mục Fashion
            return View(fashionArticles);
        }

    }
}