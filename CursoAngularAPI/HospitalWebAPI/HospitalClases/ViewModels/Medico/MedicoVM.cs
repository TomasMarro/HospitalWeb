using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClases.ViewModels.Medico
{
    public class MedicoVM
    {

        public long Id { get; set; }

        [Display(Name = "DNI")]
        public string Cedula { get; set; } = null!;


        public string Apellido { get; set; } = null!;


        public bool EsEspecialista { get; set; }


        public bool Habilitado { get; set; }


        public string Nombre { get; set; } = null!;
    }
}
