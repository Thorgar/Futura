using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class Sprache
    {
        [Key]
        public int SprachID { get; set; }
        public string Sprachtitel { get; set; }

        public virtual ICollection<SkillPool> SkillPool {get;set;}
    }
}