using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class SkillPool
    {
        [Key]
        public int SkillPoolID { get; set; }       

        public int EntwicklerID { get; set; }
        [ForeignKey("EntwicklerID")]
        public virtual Entwickler Entwickler { get; set; }

        public int SprachID { get; set; }
        [ForeignKey("SprachID")]
        public virtual Sprache Sprachen { get; set; }     
    }
}