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
    public class ProduktController : Controller
    {
        private FuturaEntity db = new FuturaEntity();

        // GET: /Produkt/
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.SpracheSortPar = sortOrder == "Language" ? "Language_desc" : "Language";
            var produkte = from p in db.Produkte.Include(p => p.Sprache)
                         select p;
            switch (sortOrder)
            {
                case "Name_desc":
                    produkte = produkte.OrderByDescending(p => p.Produkttitel);
                    break;
                case "Language_desc":
                    produkte = produkte.OrderByDescending(p => p.SprachID);
                    break;
                case "Language":
                    produkte = produkte.OrderBy(p => p.SprachID);
                    break;
                default:
                    produkte = produkte.OrderBy(p => p.Produkttitel);
                    break;
            }
            return View(produkte.ToList());            
        }

        // GET: /Produkt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkte.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: /Produkt/Create
        public ActionResult Create()
        {
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel");
            return View();
        }

        // POST: /Produkt/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProduktID,Produkttitel,SprachID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Produkte.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", produkt.SprachID);
            return View(produkt);
        }

        // GET: /Produkt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkte.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", produkt.SprachID);
            return View(produkt);
        }

        // POST: /Produkt/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProduktID,Produkttitel,SprachID")] Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SprachID = new SelectList(db.Sprachen, "SprachID", "Sprachtitel", produkt.SprachID);
            return View(produkt);
        }

        // GET: /Produkt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Produkte.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: /Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Produkte.Find(id);
            db.Produkte.Remove(produkt);
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
