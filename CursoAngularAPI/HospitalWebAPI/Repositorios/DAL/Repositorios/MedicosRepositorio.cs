using HospitalClases.ViewModels;
using HospitalClases.ViewModels.Medico;
using HospitalModels.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using Repositorios.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios.DAL.Repositorios
{
    public class MedicosRepositorio : IRepositorioMedicos
    {
        private readonly HospitalAppContext dbContext;

        public MedicosRepositorio(HospitalAppContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task BorrarMedico(List<long> Idsmedicos)
        {
            IEnumerable<Medico>? medicosABorrar = dbContext.Medicos.Where(x => Idsmedicos.Contains(x.Id));
            foreach (var item in medicosABorrar)
            {
                item.Borrado = true;
                dbContext.Entry(item).State = EntityState.Modified;
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<long> CrearMedico(Medico medico)
        {
            medico.Borrado = false;

            EntityEntry<Medico> medicoCreado = await dbContext.Medicos.AddAsync(medico);
            await dbContext.SaveChangesAsync();
            return medicoCreado.Entity.Id;
        }

        public async Task ModificarDatosMedico(MedicoVM datosNuevos)
        {
            Medico? medicoUpdate = await dbContext.Medicos.FindAsync(datosNuevos.Id);

            if (medicoUpdate != null)
            {
                medicoUpdate.Nombre = datosNuevos.Nombre;
                medicoUpdate.Apellido = datosNuevos.Apellido;
                medicoUpdate.Cedula = datosNuevos.Cedula;
                medicoUpdate.EsEspecialista = datosNuevos.EsEspecialista;
                medicoUpdate.Habilitado = datosNuevos.Habilitado;

                dbContext.Entry(medicoUpdate).State = EntityState.Modified;
                dbContext.Medicos.Update(medicoUpdate);
                await dbContext.SaveChangesAsync();
            }
        }

        public Task<MedicoVM> ObtenerMedicoPorApellido(string apellido)
        {
            throw new NotImplementedException();
        }

        public Task<MedicoVM> ObtenerMedicoPorDni(string dni)
        {
            throw new NotImplementedException();
        }

        public  async Task<MedicoVM?> ObtenerMedicoPorId(long id)
        {
            MedicoVM? medico = null;
            medico = await dbContext.Medicos.Select(x => new MedicoVM
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Apellido = x.Apellido,
                Cedula = x.Cedula,
                EsEspecialista = x.EsEspecialista,
                Habilitado = x.Habilitado

            }).FirstOrDefaultAsync(x => x.Id == id);

           
            return medico;
        }

        public Task<MedicoVM> ObtenerMedicoPorNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public async Task<ListadoPaginadoVM<MedicoVM>> ObtenerMedicos(int cantidadPorPagina,int nroPagina, string? textoBusqueda)
        {
            ListadoPaginadoVM<MedicoVM> listado = new ();

          // Extraemos los datos 
            var query =  dbContext.Medicos.Select(x => new MedicoVM
            {
                Id = x.Id,
                Nombre = x.Nombre + " " + x.Apellido,
                Cedula = x.Cedula,
                EsEspecialista = x.EsEspecialista,
            });
            //Aplicamos filtro si lo hubiese
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                query = query.Where(m =>
                m.Nombre.Contains(textoBusqueda) || 
                m.Cedula.Contains(textoBusqueda));
            }

            //Paginamos
            int cantidad = await query.CountAsync();
            listado.CantidadTotal = cantidad;
            listado.ElementosVMs = await query.OrderBy(x => x.Id).Skip(cantidadPorPagina * (nroPagina )).Take(cantidadPorPagina).ToListAsync();
            return listado;
        }
    }
}
