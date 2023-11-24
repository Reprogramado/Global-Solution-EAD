using GS.Models;
using Microsoft.EntityFrameworkCore;

namespace GS.DataBase
{
    
    public class BancoContext : DbContext
    {
        public DbSet<Atendimento> Atendimentos{ get; set; }
        public DbSet<Beneficiario> Beneficiarios { get; set; }
        public DbSet<Medico> Medicos{ get; set; }
        public DbSet<AtendimentoBeneficiario> AtendimentosBeneficiarios { get; set; }

        public BancoContext(DbContextOptions op) : base(op)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<AtendimentoBeneficiario>()
                .HasKey(churros => new { churros.BeneficiarioId, churros.AtendimentoId });

            
            modelBuilder.Entity<AtendimentoBeneficiario>()
                .HasOne(f => f.Beneficiario)
                .WithMany(f => f.AtendimentosBeneficiarios)
                .HasForeignKey(f => f.BeneficiarioId);

            
            modelBuilder.Entity<AtendimentoBeneficiario>()
               .HasOne(f => f.Atendimento)
               .WithMany(f => f.AtendimentosBeneficiarios)
               .HasForeignKey(f => f.AtendimentoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
