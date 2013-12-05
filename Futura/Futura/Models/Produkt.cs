using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Produkt
    {
        [Key]
        public int ProduktID { get; set; }
        public string Produkttitel { get; set; }
        public int SprachID { get; set; }

        [ForeignKey("SprachID")]
        public virtual Sprache Sprache { get; set; }
    }
}