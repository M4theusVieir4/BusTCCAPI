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

        public OnibusController(IOnibusService onibusService, IRotaService rotaService,
            IPontoService pontoService)
        {
            _onibusService = onibusService;
            _rotaService = rotaService;
            _pontoService = pontoService;
        }

        [HttpGet("rotas")]
        public async Task<IActionResult> Selecionar(List<PontoDTO> pontos)
        {
            var rotasDTO = await _pontoService.SelecionarAsync(pontos);
            return Ok(rotasDTO);
        }
    }
}
