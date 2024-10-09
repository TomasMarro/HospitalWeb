using HospitalClases.ViewModels.Medico;
using HospitalClases.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalModels.Modelos;
using LogicaDeNegocios.BLL;
using System.Net;
using Microsoft.AspNetCore.Cors;


namespace HospitalWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MedicoController : ControllerBase
    {
        private readonly MedicoBLL medicoBLL;

        public MedicoController(MedicoBLL medicoBLL)
        {
            this.medicoBLL = medicoBLL;
        }

        [HttpGet("ObtenerMedicos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicos(int cantidad = 10, int pagina = 1, string? textoBusqueda = null)
        {
            ListadoPaginadoVM<MedicoVM> listado = new();

            try
            {
                // Obtenemos los médicos y los asignamos al listado
                var resultado = await medicoBLL.ObtenerMedicos(cantidad, pagina, textoBusqueda);
                if (resultado != null)
                {
                    listado = resultado;
                }
            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos un 500 con el objeto listado y detalles del error
                return StatusCode((int)HttpStatusCode.InternalServerError, new { listado, mensaje = ex.Message, detalles = ex.ToString() });
            }

            return Ok(new { listado, mensaje = new string[] { }, codigo = HttpStatusCode.OK });
        }


        [HttpGet("ObtenerMedicoPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMedicosById(long id)
        {
            MedicoVM? medico = new();

            try
            {
                // Obtenemos los médicos y los asignamos al listado
                var resultado = await medicoBLL.ObtenerMedicoPorId(id);
                if (resultado != null)
                {
                    medico = resultado;  // Asegúrate de que 'ElementosVMs' es de tipo IEnumerable<MedicoVM>
                }
                else
                {
                    medico = null;
                    return NotFound(new { medico, mensaje = "Elemento no encontrado", codigo = HttpStatusCode.NotFound });
                }
            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos un 500 con el objeto listado y detalles del error
                return StatusCode((int)HttpStatusCode.InternalServerError, new { medico, mensaje = ex.Message, detalles = ex.ToString() });
            }


            return Ok(new { medico, mensaje = new string[] { }, codigo = (int)HttpStatusCode.OK });
        }

        [HttpPost("CrearMedico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateMedico(Medico medico)
        {
            long? id = new();

            try
            {
                // Obtenemos los médicos y los asignamos al listado
                var resultado = await medicoBLL.CrearMedico(medico);
                if (resultado != 0)
                {
                    id = resultado;  // Asegúrate de que 'ElementosVMs' es de tipo IEnumerable<MedicoVM>
                }

            }
            catch (Exception ex)
            {
                // En caso de error, devolvemos un 500 con el objeto listado y detalles del error
                return StatusCode((int)HttpStatusCode.InternalServerError, new { id = 0, mensaje = ex.Message, detalles = ex.ToString() });
            }


            return Ok(new { id, mensaje = new string[] { }, codigo = HttpStatusCode.OK });
        }

        [HttpPut("ModificarMedico/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMedico(long id, MedicoVM medicoAactualizar)
        {
            bool? respuesta = new();

            try
            {
                medicoAactualizar.Id = id;
                // Obtenemos los médicos y los asignamos al listado
                await medicoBLL.ModificarDatosMedico(medicoAactualizar);
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                // En caso de error, devolvemos un 500 con el objeto listado y detalles del error
                return StatusCode((int)HttpStatusCode.InternalServerError, new { respuesta, mensaje = ex.Message, detalles = ex.ToString() });
            }


            return Ok(new { respuesta, mensaje = new string[] { }, codigo = HttpStatusCode.OK });
        }

        [HttpDelete("BorrarMedico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteMedico(List<long> ids)
        {
            bool? respuesta = new();

            try
            {
                // Obtenemos los médicos y los asignamos al listado
                await medicoBLL.EliminarMedico(ids);
                respuesta = true;
            }
            catch (Exception ex)
            {
                respuesta = false;
                // En caso de error, devolvemos un 500 con el objeto listado y detalles del error
                return StatusCode((int)HttpStatusCode.InternalServerError, new { respuesta, mensaje = ex.Message, detalles = ex.ToString() });
            }


            return Ok(new { respuesta, mensaje = new string[] { }, codigo = HttpStatusCode.OK });
        }
    }
}
