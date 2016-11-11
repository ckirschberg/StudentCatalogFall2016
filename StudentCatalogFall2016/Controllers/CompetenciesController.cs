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
    public class CompetenciesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Competencies
        public ActionResult Index()
        {
            var competencyModels = db.CompetencyModels.Include(c => c.CompetencyHeaderModel);
            return View(competencyModels.ToList());
        }

        // GET: Competencies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyModel competencyModel = db.CompetencyModels.Find(id);
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

        // GET: Competencies/Create
        public ActionResult Create()
        {
            ViewBag.CompetencyHeaderModelId = new SelectList(db.CompetencyHeaderModels, "CompetencyHeaderModelId", "Name");
            return View();
        }

        // POST: Competencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetencyModelId,Name,CompetencyHeaderModelId")] CompetencyModel competencyModel)
        {
            if (ModelState.IsValid)
            {
                db.CompetencyModels.Add(competencyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompetencyHeaderModelId = new SelectList(db.CompetencyHeaderModels, "CompetencyHeaderModelId", "Name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // GET: Competencies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyModel competencyModel = db.CompetencyModels.Find(id);
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompetencyHeaderModelId = new SelectList(db.CompetencyHeaderModels, "CompetencyHeaderModelId", "Name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // POST: Competencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetencyModelId,Name,CompetencyHeaderModelId")] CompetencyModel competencyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competencyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompetencyHeaderModelId = new SelectList(db.CompetencyHeaderModels, "CompetencyHeaderModelId", "Name", competencyModel.CompetencyHeaderModelId);
            return View(competencyModel);
        }

        // GET: Competencies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetencyModel competencyModel = db.CompetencyModels.Find(id);
            if (competencyModel == null)
            {
                return HttpNotFound();
            }
            return View(competencyModel);
        }

        // POST: Competencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompetencyModel competencyModel = db.CompetencyModels.Find(id);
            db.CompetencyModels.Remove(competencyModel);
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
