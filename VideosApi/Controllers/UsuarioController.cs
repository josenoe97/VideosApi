using Microsoft.AspNetCore.Mvc;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        public IActionResult CadastrarUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
