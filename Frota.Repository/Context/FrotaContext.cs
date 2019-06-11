using Frota.Domain.Entities;
using Frota.Repository.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Frota.Repository.Context
{
    public class FrotaContext : DbContext
    {
        public DbSet<Veiculo> Veiculos { get; set; }

        public FrotaContext(DbContextOptions<FrotaContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento das entidades
            modelBuilder.ApplyConfiguration(new VeiculoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
