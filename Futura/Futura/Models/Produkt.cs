using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Produkt
    {
        [Key]
        public int ProduktID { get; set; }
        public string Produkttitel { get; set; }
        public List<Sprache> Sprachen { get; set; }
        public Sprache Sprache { get; set; }
    }
}