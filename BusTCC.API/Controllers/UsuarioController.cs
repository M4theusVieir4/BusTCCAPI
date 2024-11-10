using BusTCC.Application.DTOs;
using BusTCC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTCC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async  Task<IActionResult> Incluir(UsuarioDTO usuarioDTO)
        {
            var usuarioDTOIncluido = await _usuarioService.Incluir(usuarioDTO);
            if (usuarioDTOIncluido == null) 
            {
                return BadRequest("Ocorreu um erro ao incluir o usuário.");
            }

            return Ok("Usuário incluído com sucesso!");
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

