using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Futura.Models;
using Futura.DAL;

namespace Futura.Controllers
{
    public class SkillPoolController : Controller
    {
        private FuturaEntity db = new FuturaEntity();

        // GET: /SkillPool/
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.SpracheSortPar = sortOrder == "Language" ? "Language_desc" : "Language";
            var skills = from s in db.Skills.Include(s => s.Entwickler).Include(s => s.Sprachen)
                           select s;
            switch (sortOrder)
            {
                case "Name_desc":
                    skills = skills.OrderByDescending(s => s.EntwicklerID);
                    break;
                case "Language_desc":
                    skills = skills.OrderByDescending(s => s.SprachID);
                    break;
                case "Language":
                    skills = skills.OrderBy(s => s.SprachID);
                    break;
                default:
                    skills = skills.OrderBy(s => s.EntwicklerID);
                    break;
            }
            return View(skills.ToList());                        
        }

        // GET: /SkillPool/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillPool skillpool = db.Skills.Find(id);
            if (skillpool == null)
            {
                return HttpNotFound();
            }
            return View(skillpool);
        }

        // GET: /SkillPool/Create
        public ActionResult Create()
        {
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername");
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel");
            return View();
        }

        // POST: /SkillPool/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SkillPoolID,EntwicklerID,SprachID")] SkillPool skillpool)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skillpool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", skillpool.EntwicklerID);
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", skillpool.SprachID);
            return View(skillpool);
        }

        // GET: /SkillPool/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillPool skillpool = db.Skills.Find(id);
            if (skillpool == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", skillpool.EntwicklerID);
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", skillpool.SprachID);
            return View(skillpool);
        }

        // POST: /SkillPool/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SkillPoolID,EntwicklerID,SprachID")] SkillPool skillpool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skillpool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", skillpool.EntwicklerID);
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", skillpool.SprachID);
            return View(skillpool);
        }

        // GET: /SkillPool/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillPool skillpool = db.Skills.Find(id);
            if (skillpool == null)
            {
                return HttpNotFound();
            }
            return View(skillpool);
        }

        // POST: /SkillPool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SkillPool skillpool = db.Skills.Find(id);
            db.Skills.Remove(skillpool);
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
