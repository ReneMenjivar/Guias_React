using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pruebaController : ControllerBase
    {
        #region prueba
        // Indica la url
        [HttpGet("Prueba")]

        public string Get() {
            return "Hola mundo";
        }
        #endregion
    }
}
