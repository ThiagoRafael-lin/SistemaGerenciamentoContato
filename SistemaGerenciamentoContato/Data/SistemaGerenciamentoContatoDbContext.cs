using Microsoft.EntityFrameworkCore;
using SistemaGerenciamentoContato.Models;

namespace SistemaGerenciamentoContato.Data
{
    public class SistemaGerenciamentoContatoDbContext : DbContext
    {
        public SistemaGerenciamentoContatoDbContext(DbContextOptions<SistemaGerenciamentoContatoDbContext> options)
            : base(options)
        {

        }
            public DbSet<ContatoModel> Contato { get; set; }
            public DbSet<ItemModel> Item { get; set; }

    }
}
