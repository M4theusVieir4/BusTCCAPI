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
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Rotas");
            builder.Property(e => e.Nome_Rota).HasColumnName("Nome_Rota");
            builder.HasMany(o => o.OnibusRotas)
            .WithOne(or => or.Rota)
            .HasForeignKey(or => or.IdRota)
            .HasConstraintName("FK__OnibusRot__ID_Ro__59C55456");
            builder.HasMany(o => o.RotasPontos)
            .WithOne(or => or.Rota)
            .HasForeignKey(or => or.IdRota)
            .HasConstraintName("FK__RotasPont__ID_Ro__5CA1C101");

        }
    }
}
