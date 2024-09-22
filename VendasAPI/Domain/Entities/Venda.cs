﻿namespace VendasAPI.Domain.Entities
{
    public class Venda
    {
        public Guid Id { get; set; }
        public int NumeroVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public decimal ValorTotal { get; set; }
        public string Filial { get; set; }
        public bool Cancelado { get; set; }

        public ICollection<VendaItem> Itens { get; set; }
    }

    public class VendaItem
    {
        public Guid ProdutoId { get; set; }
        public Guid VendaId { get; set; }
        public string ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
