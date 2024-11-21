using AutoMapper;
using BusTCC.API.Models;
using BusTCC.Application.DTOs;
using BusTCC.Application.Interfaces;
using BusTCC.Domain.Account;
using BusTCC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Versioning;

namespace BusTCC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthenticate _authenticateService;
        private readonly IMapper _mapper;
        private readonly IPreferenciaService _preferenciaService;

        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authenticateService, IMapper mapper, IPreferenciaService preferenciaService)
        {
            _usuarioService = usuarioService;
            _authenticateService = authenticateService;
            _mapper = mapper;
            _preferenciaService = preferenciaService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste)
            {
                return BadRequest("Este e-mail já possui um cadastro");
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);
            if(usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }
            PreferenciaDTO preferenciaDTO = new PreferenciaDTO()
            {
                Deficiencia = false,
                Notificacao = false,
                IdUsuario = usuario.IdUsuario,
            };

            await _preferenciaService.Incluir(preferenciaDTO);

            var token = _authenticateService.GenerateToken(usuario.IdUsuario, usuario.Email);
            return Ok("Usuário cadastrado com sucesso!");
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe) return Unauthorized("Usuário não existe.");

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);
            var usuarioDTO = _mapper.Map<UsuarioDTO>(usuario);

            var preferencia = await _preferenciaService.SelecionarAsync(usuario.IdUsuario);

            usuarioDTO.Preferencia = preferencia;
            

            var token = _authenticateService.GenerateToken(usuario.IdUsuario, usuario.Email);
            

            return new UserToken {User = usuarioDTO, Token = token };
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(UsuarioDTO usuarioDTO)
        {
            var usuarioDTOAlterado = await _usuarioService.Alterar(usuarioDTO);
            if (usuarioDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o usuário.");
            }

            return Ok("Usuário alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var usuarioDTOExcluido = await _usuarioService.Excluir(id);
            if (usuarioDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o usuário.");
            }

            return Ok("Usuário excluído com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var usuarioDTO = await _usuarioService.SelecionarAsync(id);
            if (usuarioDTO == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok(usuarioDTO);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var usuariosDTO = await _usuarioService.SelecionarTodosAsync();           

            return Ok(usuariosDTO);
        }
    }
}

