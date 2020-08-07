using prueba.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prueba.ViewModel
{
    public class InfoSolicitanteViewModel
    {
        public InfoSolicitanteViewModel()
        { }
        
        [Key]
        public int SolicitanteID { get; set; }
        public string NombreSolicitante { get; set; }
        public int Numero { get; set; }
        public int InfoPersonaId { get; set; }
        public string Ocupacion { get; set; }

    }
}
