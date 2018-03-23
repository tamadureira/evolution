using Microsoft.EntityFrameworkCore;
using EvolutionAPI.Infrastructure.Entity.Entities;

namespace EvolutionAPI.Infrastructure.Entity
{
    public class EvolutionContext: DbContext
    {
        public virtual DbSet<Evolution> Evolution { get; set; }

        public EvolutionContext(DbContextOptions<EvolutionContext> options) : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MensagemSMS>(entity =>
        //    {
        //        entity.HasKey(e => e.IdMensagem).HasName("PK_MensagemSMS"); ;

        //        entity.Property(e => e.IdMensagem).HasColumnType("varchar(50)");
        //        entity.Property(e => e.Mensagem).HasColumnType("varchar(255)");

        //        entity.ToTable("MensagemSMS");
        //    });

        //}

    }
}