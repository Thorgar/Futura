using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Kunde
    {
        [Key]
        public int KundenID { get; set; }
        [Required]
        public string KundenName { get; set; }
    }
}