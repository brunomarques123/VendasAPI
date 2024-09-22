using Microsoft.AspNetCore.Mvc;
using VendasAPI.Domain.Entities;
using VendasAPI.Domain.Services;

namespace VendasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly VendaService _vendaService;

        public VendasController(VendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var vendas = await _vendaService.ObterTodas();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var venda = await _vendaService.ObterPorId(id);
            if (venda == null) return NotFound();

            return Ok(venda);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Venda venda)
        {
            await _vendaService.CriarVenda(venda);
            return CreatedAtAction(nameof(GetById), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Venda venda)
        {
            if (id != venda.Id) return BadRequest();

            await _vendaService.AtualizarVenda(venda);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _vendaService.RemoverVenda(id);
            return NoContent();
        }
    }
}
