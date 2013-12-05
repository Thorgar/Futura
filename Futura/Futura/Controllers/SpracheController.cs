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
    public class SpracheController : Controller
    {
        private FuturaEntity db = new FuturaEntity();

        // GET: /Sprache/
        public ActionResult Index()
        {
            return View(db.Sprachen.ToList());
        }

        // GET: /Sprache/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Sprachen.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // GET: /Sprache/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Sprache/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SprachID,Sprachtitel")] Sprache sprache)
        {
            if (ModelState.IsValid)
            {
                db.Sprachen.Add(sprache);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sprache);
        }

        // GET: /Sprache/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Sprachen.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // POST: /Sprache/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SprachID,Sprachtitel")] Sprache sprache)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sprache).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sprache);
        }

        // GET: /Sprache/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprache sprache = db.Sprachen.Find(id);
            if (sprache == null)
            {
                return HttpNotFound();
            }
            return View(sprache);
        }

        // POST: /Sprache/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sprache sprache = db.Sprachen.Find(id);
            db.Sprachen.Remove(sprache);
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
