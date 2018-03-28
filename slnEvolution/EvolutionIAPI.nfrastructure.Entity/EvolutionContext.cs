using EvolutionAPI.Infrastructure.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace EvolutionAPI.Infrastructure.Entity
{
    public class EvolutionContext: DbContext
    {
        public virtual DbSet<Teste> Teste { get; set; }

        public EvolutionContext(DbContextOptions<EvolutionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teste>(entity =>
            {
                entity.HasKey(e => e.Codigo).HasName("PK_Teste"); ;

                entity.Property(e => e.DataCadastro).HasColumnType("datetime");
                entity.Property(e => e.Descricao).HasColumnType("varchar(255)");

                entity.ToTable("Teste");
            });

        }

    }
}