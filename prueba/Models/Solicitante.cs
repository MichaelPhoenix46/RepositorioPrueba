using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.Models
{
    public class Solicitante
    {
        [Key]
        public int SolicitanteID { get; set; }
        public string NombreSolicitante { get; set; }

        public int Numero { get; set; }
    }
}
