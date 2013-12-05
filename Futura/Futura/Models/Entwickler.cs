using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Entwickler
    {
        [Key]
        public int EntwicklerID { get; set; }
        public string Enwicklername { get; set; }
        public virtual ICollection<SkillPool> SkillPool { get; set; }
    }
}