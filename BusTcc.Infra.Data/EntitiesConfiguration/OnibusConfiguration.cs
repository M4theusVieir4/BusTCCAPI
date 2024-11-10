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
    internal class OnibusConfiguration : IEntityTypeConfiguration<Onibus>
    {
        public void Configure(EntityTypeBuilder<Onibus> builder)
        {            
            builder.HasKey(e => e.IdOnibus).HasName("PK__Onibus__FEB5D74C84AF4425");

            builder.Property(e => e.IdOnibus)
                .ValueGeneratedNever()
                .HasColumnName("ID_Onibus");
            builder.Property(e => e.AnoFabricacao).HasColumnName("Ano_Fabricacao");
            builder.Property(e => e.IdDados).HasColumnName("ID_Dados");
            builder.Property(e => e.IdRotas).HasColumnName("ID_Rotas");
            builder.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.Placa)
                .HasMaxLength(7)
                .IsUnicode(false);
            builder.Property(e => e.TaxaOnibus)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("Taxa_Onibus");

            builder.HasOne(d => d.IdDadosNavigation).WithMany(p => p.Onibus)
                .HasForeignKey(d => d.IdDados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_onibus_comunicacao");

            builder.HasOne(d => d.IdRotasNavigation).WithMany(p => p.Onibus)
                .HasForeignKey(d => d.IdRotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_onibus_rotas");            
        }
    }
}
