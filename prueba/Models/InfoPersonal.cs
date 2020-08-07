using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class InfoPersonal
    {
        [Key]
        public int InfoPersonaId { get; set; }
        public string Ocupacion { get; set; }
    }
}
