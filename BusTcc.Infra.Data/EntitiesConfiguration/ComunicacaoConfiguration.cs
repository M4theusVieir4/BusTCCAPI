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
    internal class ComunicacaoConfiguration : IEntityTypeConfiguration<Comunicacao>
    {
        public void Configure(EntityTypeBuilder<Comunicacao> builder)
        {            
            builder.HasKey(e => e.IdDados).HasName("PK__Comunica__5686989247556584");

            builder.ToTable("Comunicacao");

            builder.Property(e => e.IdDados)
                .ValueGeneratedNever()
                .HasColumnName("ID_Dados");
            builder.Property(e => e.IdCatraca).HasColumnName("ID_Catraca");
            builder.Property(e => e.IdEquipamento).HasColumnName("ID_Equipamento");

            builder.HasOne(d => d.IdCatracaNavigation).WithMany(p => p.Comunicacaos)
                .HasForeignKey(d => d.IdCatraca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comunicacao_catraca");

            builder.HasOne(d => d.IdEquipamentoNavigation).WithMany(p => p.Comunicacaos)
                .HasForeignKey(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comunicacao_equipamento");            
        }
    }
}
