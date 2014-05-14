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
    public class ProjektController : Controller
    {
        private FuturaEntity db = new FuturaEntity();

        // GET: /Projekt/
        public ActionResult Index(string sortOrder)
        {
            ViewBag.ProdukttitelSortParm = String.IsNullOrEmpty(sortOrder) ? "Projekttitel_desc" : "";
            ViewBag.EntwicklerSortPar = sortOrder == "Entwickler" ? "Entwickler_desc" : "Entwickler";
            ViewBag.KundeSortPar = sortOrder == "Kunde" ? "Kunde_desc" : "Kunde";
            ViewBag.ProduktSortPar = sortOrder == "Produkt" ? "Produkt_desc" : "Produkt";           

            var projekte = from p in db.Projekte.Include(p => p.Entwickler).Include(p => p.Kunde).Include(p => p.Produkt)
                         select p;
            switch (sortOrder)
            {
                case "Projekttitel_desc":
                    projekte = projekte.OrderByDescending(p => p.Projekttitel);
                    break;
                case "Entwickler":
                    projekte = projekte.OrderBy(p => p.EntwicklerID);
                    break;
                case "Entwickler_desc":
                    projekte = projekte.OrderByDescending(p => p.EntwicklerID);
                    break;
                case "Kunde_desc":
                    projekte = projekte.OrderByDescending(p => p.KundenID);
                    break;
                case "Kunde":
                    projekte = projekte.OrderBy(p => p.KundenID);
                    break;
                case "Produkt_desc":
                    projekte = projekte.OrderByDescending(p => p.ProduktID);
                    break;
                case "Produkt":
                    projekte = projekte.OrderBy(p => p.ProduktID);
                    break;
                default:
                    projekte = projekte.OrderBy(p => p.Projekttitel);
                    break;
            }            
            return View(projekte.ToList());
        }

        // GET: /Projekt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekte.Find(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }

        // GET: /Projekt/Create
        public ActionResult Create()
        {
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername");
            ViewBag.KundenID = new SelectList(db.Kunden, "KundenID", "KundenName");
            ViewBag.ProduktID = new SelectList(db.Produkte, "ProduktID", "Produkttitel");
            return View();
        }

        // POST: /Projekt/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProjektID,Projekttitel,KundenID,EntwicklerID,ProduktID,Abgabetermin,Abgeschlossen,Projektbeschreibung")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                db.Projekte.Add(projekt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", projekt.EntwicklerID);
            ViewBag.KundenID = new SelectList(db.Kunden, "KundenID", "KundenName", projekt.KundenID);
            ViewBag.ProduktID = new SelectList(db.Produkte, "ProduktID", "Produkttitel", projekt.ProduktID);
            return View(projekt);
        }

        // GET: /Projekt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekte.Find(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", projekt.EntwicklerID);
            ViewBag.KundenID = new SelectList(db.Kunden, "KundenID", "KundenName", projekt.KundenID);
            ViewBag.ProduktID = new SelectList(db.Produkte, "ProduktID", "Produkttitel", projekt.ProduktID);
            return View(projekt);
        }

        // POST: /Projekt/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProjektID,Projekttitel,KundenID,EntwicklerID,ProduktID,Abgabetermin,Abgeschlossen,Projektbeschreibung")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projekt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntwicklerID = new SelectList(db.Entwickler, "EntwicklerID", "Enwicklername", projekt.EntwicklerID);
            ViewBag.KundenID = new SelectList(db.Kunden, "KundenID", "KundenName", projekt.KundenID);
            ViewBag.ProduktID = new SelectList(db.Produkte, "ProduktID", "Produkttitel", projekt.ProduktID);
            return View(projekt);
        }

        // GET: /Projekt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekt projekt = db.Projekte.Find(id);
            if (projekt == null)
            {
                return HttpNotFound();
            }
            return View(projekt);
        }

        // POST: /Projekt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projekt projekt = db.Projekte.Find(id);
            db.Projekte.Remove(projekt);
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
