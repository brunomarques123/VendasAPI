using VendasAPI.Data.Context;
using VendasAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace VendasAPI.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly VendasDbContext _context;

        public VendaRepository(VendasDbContext context)
        {
            _context = context;
        }

        public async Task<Venda> ObterPorIdAsync(Guid id)
        {
            return await _context.Vendas
                .Include(v => v.Itens)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Venda>> ObterTodosAsync()
        {
            return await _context.Vendas
                .Include(v => v.Itens)
                .ToListAsync();
        }

        public async Task AdicionarAsync(Venda venda)
        {
            await _context.Vendas.AddAsync(venda);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Venda venda)
        {
            _context.Vendas.Update(venda);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var venda = await ObterPorIdAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }
        }
    }
}
