using BusTCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.Data.EntitiesConfiguration
{
    internal class RotaConfiguration : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            
            builder.HasKey(e => e.IdRotas).HasName("PK__Rotas__2EF76AF7EDB3594A");

            builder.Property(e => e.IdRotas)
                .ValueGeneratedNever()
                .HasColumnName("ID_Rotas");
            builder.Property(e => e.IdOnibus).HasColumnName("ID_Onibus");
            builder.Property(e => e.IdPonto).HasColumnName("ID_Ponto");

            builder.HasOne(d => d.IdOnibusNavigation).WithMany(p => p.Rota)
                .HasForeignKey(d => d.IdOnibus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rotas_onibus");

            builder.HasOne(d => d.IdPontoNavigation).WithMany(p => p.Rota)
                .HasForeignKey(d => d.IdPonto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rotas_ponto");            
        }
    }
}
