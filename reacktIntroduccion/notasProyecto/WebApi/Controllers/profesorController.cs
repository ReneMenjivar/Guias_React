using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Models;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private ProfesorDao _proDao = new ProfesorDao();

        // Creando endpoint con el metodo http post
        [HttpPost("autenticacion")]

        public string loginProfesor([FromBody] Profesor profesor)
        {
            var prof1 = _proDao.login(profesor.Usuario, profesor.Pass);

            if (prof1 != null)
            {
                return prof1.Usuario;
            }

            return "Elemento no encontrado";
        }
    }
}
