using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        // Instancia del elemento CalificacionDao
        private CalificacionDao _cdao = new CalificacionDao();

        [HttpGet("calificaciones")]
        public List<Calificacion> get(int idMatricula)
        {
            // Invocando al metodo CalificacionDao
            return _cdao.seleccion(idMatricula);
        }

        [HttpPost("calificacion")]
        public bool insertar([FromBody] Calificacion calificacion)
        {
            return _cdao.insertar(calificacion);
        }

        [HttpDelete("Calificacion")]
        public bool delete(int idCalificacion)
        {
            return _cdao.eliminarCalificacion(idCalificacion);
        }
    }
}