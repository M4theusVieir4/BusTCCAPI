using BusTCC.Application.DTOs;
using BusTCC.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusTCC.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PreferenciaController : Controller
    {
        private readonly IPreferenciaService _preferenciaService;

        public PreferenciaController(IPreferenciaService preferenciaService)
        {
            _preferenciaService = preferenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> Incluir(PreferenciaDTO preferenciaDTO)
        {
            var preferenciaDTOIncluido = await _preferenciaService.Incluir(preferenciaDTO);
            if (preferenciaDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o preferência.");
            }

            return Ok("Preferência incluído com sucesso!");
        }

        [HttpPut]
        public async Task<IActionResult> Alterar(PreferenciaDTO preferenciaDTO)
        {
            var preferenciaDTOAlterado = await _preferenciaService.Alterar(preferenciaDTO);
            if (preferenciaDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o preferência.");
            }

            return Ok("Preferência alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<IActionResult> Excluir(int id)
        {
            var preferenciaDTOExcluido = await _preferenciaService.Excluir(id);
            if (preferenciaDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o preferência.");
            }

            return Ok("Preferência excluído com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Selecionar(int id)
        {
            var preferenciaDTO = await _preferenciaService.SelecionarAsync(id);
            if (preferenciaDTO == null)
            {
                return NotFound("Preferência não encontrado.");
            }

            return Ok(preferenciaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var preferenciasDTO = await _preferenciaService.SelecionarTodosAsync();

            return Ok(preferenciasDTO);
        }
    }
}
