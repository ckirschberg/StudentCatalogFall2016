using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentCatalogFall2016.Models;

namespace StudentCatalogFall2016.Controllers
{
    public class CompetencyHeadersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CompetencyHeaders
        public ActionResult Index()
        {
            return View(db.CompetencyHeaderModels.ToList());
        }

        // GET: CompetencyHeaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeaderModel competencyHeaderModel = db.CompetencyHeaderModels.Find(id);
            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompetencyHeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyHeaderModelId,Name")] CompetencyHeaderModel competencyHeaderModel)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyHeaderModels.Add(competencyHeaderModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeaderModel competencyHeaderModel = db.CompetencyHeaderModels.Find(id);
            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeaderModel);
        }

        // POST: CompetencyHeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyHeaderModelId,Name")] CompetencyHeaderModel competencyHeaderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyHeaderModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(competencyHeaderModel);
        }

        // GET: CompetencyHeaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyHeaderModel competencyHeaderModel = db.CompetencyHeaderModels.Find(id);
            if (competencyHeaderModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyHeaderModel);
        }

        // POST: CompetencyHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyHeaderModel competencyHeaderModel = db.CompetencyHeaderModels.Find(id);
            db.CompetencyHeaderModels.Remove(competencyHeaderModel);
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
