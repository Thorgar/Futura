using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Entwickler
    {
        [Key]
        public int EntwicklerID { get; set; }
        [Required]
        public string Enwicklername { get; set; }
    }
}