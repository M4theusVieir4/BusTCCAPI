using BusTCC.Application.DTOs;
using BusTCC.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusTCC.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnibusController : Controller
    {
        private readonly IOnibusService _onibusService;
        private readonly IRotaService _rotaService;
        private readonly IPontoService _pontoService;
        private readonly IEquipamentoService _equipamentoService;

        public OnibusController(IOnibusService onibusService, IRotaService rotaService,
            IPontoService pontoService, IEquipamentoService equipamentoService)
        {
            _onibusService = onibusService;
            _rotaService = rotaService;
            _pontoService = pontoService;
            _equipamentoService = equipamentoService;
        }

        [HttpPost("pontos-detalhe")]
        public async Task<IActionResult> Selecionar([FromBody] List<PontoDTO> pontos)
        {
            var rotasDTO = await _pontoService.SelecionarAsync(pontos);
            return Ok(rotasDTO);
        }

        [HttpGet("onibus")]
        public async Task<IActionResult> SelecionarOnibus(int idOnibus)
        {
            var onibusDTO = await _onibusService.SelecionarAsync(idOnibus);
            return Ok(onibusDTO);
        }

        [HttpGet("localizacao")]
        public async Task<IActionResult> BuscarLocalizacao(int idEquipamento)
        {
            var equipamentoDTO = await _equipamentoService.SelecionarAsync(idEquipamento);
            return Ok(equipamentoDTO);
        }
        
    }
}
