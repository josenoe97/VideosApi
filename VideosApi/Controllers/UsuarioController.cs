using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VideosApi.Data.Dtos;
using VideosApi.Models;
using VideosApi.Services;

namespace VideosApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
        {
            await _usuarioService.CadastraAsync(dto);
            return Ok("Usuário cadastrado!");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUsuarioDto dto)
        {
            var token = await _usuarioService.LoginAsync(dto);

            if (token is null)
                return BadRequest("Usuário e senha inválidos");

            return Ok(token);
        }


    }
}
