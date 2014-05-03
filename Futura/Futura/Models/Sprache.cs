using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Sprache
    {
        [Key]
        public int SprachID { get; set; }
        [Required]
        public string Sprachtitel { get; set; }
    }
}