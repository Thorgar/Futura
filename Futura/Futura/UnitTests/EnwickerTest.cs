using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Futura.Models;
using Futura.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;

namespace Futura.UnitTests
{
    public class TestFunctions
    {
        private FuturaEntity _db;

        public TestFunctions(FuturaEntity db)
        {
            _db = db;
        }

        public Entwickler EnwicklerHinzufügen(int id, string name)
        {
            var entwickler = _db.Entwickler.Add(new Entwickler { EntwicklerID = id, Enwicklername = name });
            _db.SaveChanges();
            return entwickler;
        }
        public Kunde KundeHinzufügen(int id, string name)
        {
            var kunde = _db.Kunden.Add(new Kunde { KundenID = id, KundenName = name });
            _db.SaveChanges();
            return kunde;
        }
        public Produkt ProduktHinzufügen(int id, string titel, Sprache sprache, int sprachID)
        {
            var produkt = _db.Produkte.Add(new Produkt { ProduktID = id, Produkttitel = titel, Sprache = sprache, SprachID = sprachID });
            _db.SaveChanges();
            return produkt;
        }
        public Sprache SpracheHinzufügen(int id, string name)
        {
            var sprache = _db.Sprachen.Add(new Sprache { SprachID = id, Sprachtitel = name });
            _db.SaveChanges();
            return sprache;
        }
        public SkillPool SkillPoolHinzufügen(int skillPoolID, Entwickler entwickler, int entwicklerID , Sprache sprache, int sprachID)
        {
            var skill = _db.Skills.Add(new SkillPool {  SkillPoolID = skillPoolID, Entwickler = entwickler, EntwicklerID = entwicklerID, Sprachen = sprache, SprachID = sprachID});
            _db.SaveChanges();
            return skill;
        }
        public Projekt ProjektHinzufügen(int projektID, string projekttitel, int kundenID,Kunde kunde, int entwicklerID,Entwickler entwickler, int produktID,Produkt produkt, DateTime abgabetermin , bool abgeschlossen , string projektbeschreibung)
        {
            var projekt = _db.Projekte.Add(new Projekt{ ProjektID = produktID, Abgabetermin = abgabetermin, Abgeschlossen = abgeschlossen, Entwickler = entwickler, EntwicklerID = entwicklerID, Kunde = kunde, KundenID = kundenID, Produkt = produkt, ProduktID = produktID, Projektbeschreibung = projektbeschreibung, Projekttitel = projekttitel});
            _db.SaveChanges();
            return projekt;
        }

        [TestClass]
        public class EnwickerTest : Controller
        {


            [TestMethod]
            public void EntwicklerErstellen()
            {
                var mockSet = new Mock<DbSet<Entwickler>>();
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Entwickler).Returns(mockSet.Object);
                var test = new TestFunctions(mockDb.Object);
                test.EnwicklerHinzufügen(999, "EntwicklerA");
                mockSet.Verify(m => m.Add(It.IsAny<Entwickler>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void KundeErstellen()
            {
                var mockSet = new Mock<DbSet<Kunde>>();
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Kunden).Returns(mockSet.Object);
                var test = new TestFunctions(mockDb.Object);
                test.KundeHinzufügen(999, "KundeA");
                mockSet.Verify(m => m.Add(It.IsAny<Kunde>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void ProduktErstellen()
            {
                var mockSet = new Mock<DbSet<Produkt>>();            
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Produkte).Returns(mockSet.Object);                
                var test = new TestFunctions(mockDb.Object);
                Sprache sprache = new Sprache();
                sprache.SprachID= 999;
                sprache.Sprachtitel = "SpracheA";
                test.ProduktHinzufügen(999, "ProduktA", sprache, sprache.SprachID);
                mockSet.Verify(m => m.Add(It.IsAny<Produkt>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void SpracheErstellen()
            {
                var mockSet = new Mock<DbSet<Sprache>>();
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Sprachen).Returns(mockSet.Object);
                var test = new TestFunctions(mockDb.Object);
                test.SpracheHinzufügen(999, "SpracheA");
                mockSet.Verify(m => m.Add(It.IsAny<Sprache>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void SkillErstellen()
            {
                var mockSet = new Mock<DbSet<SkillPool>>();
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Skills).Returns(mockSet.Object);
                var test = new TestFunctions(mockDb.Object);
                Entwickler entwickler = new Entwickler();
                entwickler.EntwicklerID = 999;
                entwickler.Enwicklername = "EntwicklerA";
                Sprache sprache = new Sprache();
                sprache.SprachID = 999;
                sprache.Sprachtitel = "SpracheA";
                test.SkillPoolHinzufügen(999, entwickler, entwickler.EntwicklerID, sprache, sprache.SprachID);
                mockSet.Verify(m => m.Add(It.IsAny<SkillPool>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
            [TestMethod]
            public void ProjektErstellen()
            {
                var mockSet = new Mock<DbSet<Projekt>>();
                var mockDb = new Mock<FuturaEntity>();
                mockDb.Setup(m => m.Projekte).Returns(mockSet.Object);
                var test = new TestFunctions(mockDb.Object);
                Kunde kunde = new Kunde();
                kunde.KundenID = 999;
                kunde.KundenName = "KundeA";
                Entwickler entwickler = new Entwickler();
                entwickler.EntwicklerID = 999;
                entwickler.Enwicklername = "EntwicklerA";
                Produkt produkt = new Produkt();
                produkt.ProduktID = 999;
                produkt.Produkttitel = "ProduktA";
                DateTime date = new DateTime();
                date = DateTime.Now;
                test.ProjektHinzufügen(999, "ProjektA", kunde.KundenID, kunde, entwickler.EntwicklerID, entwickler, produkt.ProduktID, produkt, date, false, "PorjektbeschreibungA");
                mockSet.Verify(m => m.Add(It.IsAny<Projekt>()), Times.Once());
                mockDb.Verify(m => m.SaveChanges(), Times.Once());
            }
        }
    }
}