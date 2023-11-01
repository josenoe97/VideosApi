using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using VideosApi.Data.Dtos;
using VideosApi.Models;

namespace VideosApi.Services
{
    public class UsuarioService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager = null, SignInManager<Usuario> signInManager = null,
            TokenService tokenService = null)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }



        public async Task CadastraAsync(CreateUsuarioDto dto)
        {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded) 
                throw new ApplicationException("Falha ao cadastrar usuários!");



        }

        public async Task<string> LoginAsync(LoginUsuarioDto dto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded)
                throw new ApplicationException("Usuário e senha inválidos");

            var usuario = _signInManager
                .UserManager
                .Users
                .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }

        
    }


}
