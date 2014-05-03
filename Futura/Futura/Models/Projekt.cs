using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Projekt
    {
        [Key]
        public int ProjektID { get; set; }
        [Required]
        public string Projekttitel { get; set; }

        [ForeignKey("KundenID")]        
        public virtual Kunde Kunde { get; set; }
        public int KundenID { get; set; }

        [ForeignKey("EntwicklerID")]        
        public virtual Entwickler Entwickler { get; set; }
        public int EntwicklerID { get; set; }

        [ForeignKey("ProduktID")]        
        public virtual Produkt Produkt { get; set; }
        public int ProduktID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Abgabetermin { get; set; }        
        
        public bool Abgeschlossen { get; set; }

        public string Projektbeschreibung { get; set; }
    }
}