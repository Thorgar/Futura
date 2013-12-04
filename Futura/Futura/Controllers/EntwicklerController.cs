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
    public class EntwicklerController : Controller
    {
        private FuturaEntity db = new FuturaEntity();

        // GET: /Entwickler/
        public ActionResult Index()
        {
            return View(db.Entwickler.ToList());
        }

        // GET: /Entwickler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entwickler entwickler = db.Entwickler.Find(id);
            if (entwickler == null)
            {
                return HttpNotFound();
            }
            return View(entwickler);
        }

        // GET: /Entwickler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Entwickler/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="EntwicklerID,Enwicklername")] Entwickler entwickler)
        {
            if (ModelState.IsValid)
            {
                db.Entwickler.Add(entwickler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entwickler);
        }

        // GET: /Entwickler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entwickler entwickler = db.Entwickler.Find(id);
            if (entwickler == null)
            {
                return HttpNotFound();
            }
            return View(entwickler);
        }

        // POST: /Entwickler/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="EntwicklerID,Enwicklername")] Entwickler entwickler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entwickler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entwickler);
        }

        // GET: /Entwickler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entwickler entwickler = db.Entwickler.Find(id);
            if (entwickler == null)
            {
                return HttpNotFound();
            }
            return View(entwickler);
        }

        // POST: /Entwickler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entwickler entwickler = db.Entwickler.Find(id);
            db.Entwickler.Remove(entwickler);
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
