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
    internal class EquipamentoConfiguration : IEntityTypeConfiguration<Equipamento>
    {
        public void Configure(EntityTypeBuilder<Equipamento> builder)
        {            
                builder.HasKey(e => e.IdEquipamento).HasName("PK__Equipame__7ADEBA86434904E6");

                builder.ToTable("Equipamento");

                builder.Property(e => e.IdEquipamento)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Equipamento");
                builder.Property(e => e.IdDados).HasColumnName("ID_Dados");
                builder.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
                builder.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
                builder.Property(e => e.Modelo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                builder.Property(e => e.NumeroSerie)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Serie");

                builder.HasOne(d => d.IdDadosNavigation).WithMany(p => p.Equipamentos)
                    .HasForeignKey(d => d.IdDados)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_equipamento_comunicacao");
            
        }
    }
}
