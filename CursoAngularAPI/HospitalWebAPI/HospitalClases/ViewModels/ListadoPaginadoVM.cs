using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalClases.ViewModels.Medico;

namespace HospitalClases.ViewModels
{
    public class ListadoPaginadoVM<T> where T : class
    {
        public IEnumerable<T>? ElementosVMs { get; set; }

        public int CantidadTotal { get; set; }

        public ListadoPaginadoVM()
        {
            ElementosVMs = [];
            CantidadTotal = 0;
        }
    }
}
