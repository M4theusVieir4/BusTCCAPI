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
    internal class PontoConfiguration : IEntityTypeConfiguration<Ponto>
    {
        public void Configure(EntityTypeBuilder<Ponto> builder)
        {
            
            builder.HasKey(e => e.IdPonto).HasName("PK__Ponto__2D43D62046193992");

            builder.ToTable("Ponto");

            builder.Property(e => e.IdPonto)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Ponto");
            builder.Property(e => e.Bairro)
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);            
            builder.Property(e => e.RuaAvenida)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("Rua_Avenida");

            builder.HasMany(o => o.RotasPontos)
            .WithOne(or => or.Ponto)
            .HasForeignKey(or => or.IdPonto)
            .HasConstraintName("FK__RotasPont__ID_Po__5D95E53A");
        }
    }
}
