using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Futura.Models;

namespace Futura.DAL
{
    public class Projectinitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<FuturaEntity>
    {
        protected override void Seed(FuturaEntity context)
        {
            var entwickler = new List<Entwickler>
            {
                new Entwickler{EntwicklerID=1, Enwicklername="Lotfi"},
                new Entwickler{EntwicklerID=2, Enwicklername="Norman"},
                new Entwickler{EntwicklerID=3, Enwicklername="Ismael"},
                new Entwickler{EntwicklerID=4, Enwicklername="Niklas"},
                new Entwickler{EntwicklerID=5, Enwicklername="Werner"},
                new Entwickler{EntwicklerID=6, Enwicklername="Raymond"}
            };
            entwickler.ForEach(s => context.Entwickler.Add(s));
            context.SaveChanges();

            var kunde = new List<Kunde>
            {
                new Kunde{KundenID=1,KundenName="Lotman GmbH"},
                new Kunde{KundenID=1,KundenName="Mantis Corporation"},
                new Kunde{KundenID=1,KundenName="Shrimp Co.KG"},
                new Kunde{KundenID=1,KundenName="HitchHiker GmbH"}
            };
            kunde.ForEach(s => context.Kunden.Add(s));
            context.SaveChanges();

            var sprachen = new List<Sprache>
            {
                new Sprache{SprachID=1, Sprachtitel="C#"},
                new Sprache{SprachID=2, Sprachtitel="C++"},
                new Sprache{SprachID=3,Sprachtitel="Java"},
                new Sprache{SprachID=4,Sprachtitel="Delphi"}
            };
            sprachen.ForEach(s => context.Sprachen.Add(s));
            context.SaveChanges();

            var produkte = new List<Produkt>
            {
                new Produkt{ProduktID=1, Produkttitel="Futura",SprachID=1},
                new Produkt{ProduktID=2, Produkttitel="Suchengine",SprachID=2},
                new Produkt{ProduktID=3, Produkttitel="Buchungsmanager",SprachID=1},
                new Produkt{ProduktID=4, Produkttitel="Suchbackend",SprachID=3},
                new Produkt{ProduktID=5, Produkttitel="SuchAPI", SprachID=4}
            };
            produkte.ForEach(s => context.Produkte.Add(s));
            context.SaveChanges();

         

            var skillPool = new List<SkillPool>
            {
                new SkillPool{SkillPoolID=1,EntwicklerID=1,SprachID=1},
                new SkillPool{SkillPoolID=2,EntwicklerID=1,SprachID=2},
                new SkillPool{SkillPoolID=3,EntwicklerID=2,SprachID=1},
                new SkillPool{SkillPoolID=4,EntwicklerID=2,SprachID=2},
                new SkillPool{SkillPoolID=5,EntwicklerID=3,SprachID=1},
                new SkillPool{SkillPoolID=6,EntwicklerID=3,SprachID=2},
                new SkillPool{SkillPoolID=7,EntwicklerID=3,SprachID=3},
                new SkillPool{SkillPoolID=8,EntwicklerID=3,SprachID=4}
            };
            skillPool.ForEach(s => context.Skills.Add(s));
            context.SaveChanges();
        }
    }
}