﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DOANNEW.Models;

namespace DOANNEW.Controllers
{
    public class TrangChuController : Controller
    {
        private TAPCHI2Entities db = new TAPCHI2Entities();

        // GET: TrangChu
        public ActionResult Index()
        {
            var bai_viet = db.Bai_viet.Include(b => b.Danh_Muc).Include(b => b.User);
            return View(bai_viet.ToList());
        }

        // GET: TrangChu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bai_viet bai_viet = db.Bai_viet.Find(id);
            if (bai_viet == null)
            {
                return HttpNotFound();
            }
            return View(bai_viet);
        }

        // GET: TrangChu/Create
        public ActionResult Create()
        {
            ViewBag.DanhMucID = new SelectList(db.Danh_Muc, "DanhMucID", "TenDanhMuc");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: TrangChu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BaiVietID,TieuDe,NoiDung,DanhMucID,Hinh_Anh,UserID")] Bai_viet bai_viet)
        {
            if (ModelState.IsValid)
            {
                db.Bai_viet.Add(bai_viet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DanhMucID = new SelectList(db.Danh_Muc, "DanhMucID", "TenDanhMuc", bai_viet.DanhMucID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", bai_viet.UserID);
            return View(bai_viet);
        }

        // GET: TrangChu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bai_viet bai_viet = db.Bai_viet.Find(id);
            if (bai_viet == null)
            {
                return HttpNotFound();
            }
            ViewBag.DanhMucID = new SelectList(db.Danh_Muc, "DanhMucID", "TenDanhMuc", bai_viet.DanhMucID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", bai_viet.UserID);
            return View(bai_viet);
        }

        // POST: TrangChu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BaiVietID,TieuDe,NoiDung,DanhMucID,Hinh_Anh,UserID")] Bai_viet bai_viet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bai_viet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DanhMucID = new SelectList(db.Danh_Muc, "DanhMucID", "TenDanhMuc", bai_viet.DanhMucID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", bai_viet.UserID);
            return View(bai_viet);
        }

        // GET: TrangChu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bai_viet bai_viet = db.Bai_viet.Find(id);
            if (bai_viet == null)
            {
                return HttpNotFound();
            }
            return View(bai_viet);
        }

        // POST: TrangChu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bai_viet bai_viet = db.Bai_viet.Find(id);
            db.Bai_viet.Remove(bai_viet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
