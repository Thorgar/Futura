using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Futura.Models;

namespace Futura.DAL
{
    public class FuturaEntity : DbContext
    {
        public FuturaEntity() : base("FuturaEntity") { }
        public virtual DbSet<Entwickler> Entwickler { get; set; }
        public virtual DbSet<Kunde> Kunden { get; set; }
        public virtual DbSet<Produkt> Produkte { get; set; }
        public virtual DbSet<Sprache> Sprachen { get; set; }
        public virtual DbSet<SkillPool> Skills { get; set; }
        public virtual DbSet<Projekt> Projekte { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}