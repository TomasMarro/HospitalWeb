using HospitalClases.ViewModels;
using HospitalClases.ViewModels.Medico;
using HospitalModels.Modelos;
using Repositorios.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocios.BLL
{
    public class MedicoBLL
    {
        private readonly IRepositorioMedicos repositorioMedicos;

        public MedicoBLL(IRepositorioMedicos repositorioMedicos)
        {
            this.repositorioMedicos = repositorioMedicos;
        }

        public async Task<long> CrearMedico(Medico medico)
        {
           return await repositorioMedicos.CrearMedico(medico);
        }

        public Task ModificarDatosMedico(MedicoVM medico)
        {
            return repositorioMedicos.ModificarDatosMedico(medico);
        }

        public Task EliminarMedico(List<long> medico)
        {
            return repositorioMedicos.BorrarMedico(medico);
        }


        public async Task<MedicoVM?> ObtenerMedicoPorId(long id)
        {
            return await repositorioMedicos.ObtenerMedicoPorId(id);
        }

        public async Task<ListadoPaginadoVM<MedicoVM>> ObtenerMedicos(int cantidad , int pagina , string? textoBusqueda )
        {
            return await repositorioMedicos.ObtenerMedicos(cantidad, pagina, textoBusqueda);
        }

       
    }
}
