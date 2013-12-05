using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Futura.Models
{
    public class SkillPool
    {
        [Key]
        public int SkillPoolID { get; set; }
        public int EntwicklerID { get; set; }
        public int SprachID { get; set; }
        //public List<Entwickler> Entwickler { get; set; }
        //public List<Sprache> Sprache { get; set; }
        
    }
}