using VendasAPI.Domain.Entities;

namespace VendasAPI.Data.Repositories
{
    public interface IVendaRepository
    {
        Task<Venda> ObterPorIdAsync(Guid id);
        Task<List<Venda>> ObterTodosAsync();
        Task AdicionarAsync(Venda venda);
        Task AtualizarAsync(Venda venda);
        Task RemoverAsync(Guid id);
    }
}
