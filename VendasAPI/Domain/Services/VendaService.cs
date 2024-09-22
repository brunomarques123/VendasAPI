using VendasAPI.Data.Repositories;
using VendasAPI.Domain.Entities;

namespace VendasAPI.Domain.Services
{
    public class VendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task CriarVenda(Venda venda)
        {
            venda.DataVenda = DateTime.UtcNow;
            await _vendaRepository.AdicionarAsync(venda);
        }

        public async Task<IEnumerable<Venda>> ObterTodas()
        {
            return await _vendaRepository.ObterTodosAsync();
        }

        public async Task<Venda> ObterPorId(Guid id)
        {
            return await _vendaRepository.ObterPorIdAsync(id);
        }

        public async Task AtualizarVenda(Venda venda)
        {
            await _vendaRepository.AtualizarAsync(venda);
        }

        public async Task RemoverVenda(Guid id)
        {
            await _vendaRepository.RemoverAsync(id);
        }
    }
}
