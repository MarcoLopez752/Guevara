using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Antonio.Models;

namespace Antonio.Controllers
{
    public class Fairies1Controller : Controller
    {
        private DataContext db = new DataContext();

        // GET: Fairies1
        public ActionResult Index()
        {
            return View(db.Fairies.ToList());
        }

        // GET: Fairies1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fairy fairy = db.Fairies.Find(id);
            if (fairy == null)
            {
                return HttpNotFound();
            }
            return View(fairy);
        }

        // GET: Fairies1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fairies1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FairyID,NickName,wishes,Email,Birthday")] Fairy fairy)
        {
            if (ModelState.IsValid)
            {
                db.Fairies.Add(fairy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fairy);
        }

        // GET: Fairies1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fairy fairy = db.Fairies.Find(id);
            if (fairy == null)
            {
                return HttpNotFound();
            }
            return View(fairy);
        }

        // POST: Fairies1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FairyID,NickName,wishes,Email,Birthday")] Fairy fairy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fairy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fairy);
        }

        // GET: Fairies1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fairy fairy = db.Fairies.Find(id);
            if (fairy == null)
            {
                return HttpNotFound();
            }
            return View(fairy);
        }

        // POST: Fairies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fairy fairy = db.Fairies.Find(id);
            db.Fairies.Remove(fairy);
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
