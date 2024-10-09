using HospitalClases.ViewModels;
using HospitalClases.ViewModels.Medico;
using HospitalModels.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.DAL.Interfaces
{
    public interface IRepositorioMedicos
    {
        Task<ListadoPaginadoVM<MedicoVM>> ObtenerMedicos(int cantidadPorPagina, int nroPagina, string? textoBusqueda);
        Task<MedicoVM?> ObtenerMedicoPorId(long id);
        Task<MedicoVM> ObtenerMedicoPorNombre(string nombre);

        Task<MedicoVM> ObtenerMedicoPorApellido(string apellido);

        Task<MedicoVM> ObtenerMedicoPorDni(string dni);

        Task<long> CrearMedico(Medico medico);

        Task ModificarDatosMedico(MedicoVM datosNuevos);

        Task BorrarMedico(List<long> Idsmedicos);


    }
}
