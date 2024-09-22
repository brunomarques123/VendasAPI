using Microsoft.EntityFrameworkCore;
using VendasAPI.Domain.Entities;

namespace VendasAPI.Data.Context
{
    public class VendasDbContext : DbContext
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura chave composta para VendaItem (ProdutoId e VendaId)
            modelBuilder.Entity<VendaItem>()
                .HasKey(vi => new { vi.ProdutoId, vi.VendaId });

            // Configura relacionamento de 1:N entre Venda e VendaItem
            modelBuilder.Entity<Venda>()
                .HasMany(v => v.Itens)
                .WithOne()
                .HasForeignKey(vi => vi.VendaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
