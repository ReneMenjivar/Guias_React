using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reactBackend.Repository;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDao _dao = new AlumnoDao();

        [HttpGet("AlumnoProfesors")]
        public List<AlumnoProfesor> GetAlumnoProfesor(string usuario)
        {
            return _dao.AlumnoProfesors(usuario);
        }
    }
}