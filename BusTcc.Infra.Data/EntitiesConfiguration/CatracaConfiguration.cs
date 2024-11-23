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
    internal class CatracaConfiguration : IEntityTypeConfiguration<Catraca>
    {
        public void Configure(EntityTypeBuilder<Catraca> builder)
        {
            
            builder.HasKey(e => e.IdCatraca).HasName("PK__Catraca__B88D543CBA1F1013");

            builder.ToTable("Catraca");

            builder.Property(e => e.IdCatraca)
                .ValueGeneratedNever()
                .HasColumnName("ID_Catraca");
            builder.Property(e => e.IdEquipamento).HasColumnName("ID_Equipamento");
            builder.Property(e => e.Local)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.QuantidadeEntrada)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Quantidade_Entrada");
            builder.Property(e => e.QuantidadeSaida)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Quantidade_Saida");
            builder.HasOne(d => d.IdEquipamentoNavigation).WithOne(p => p.Catraca)
                .HasForeignKey<Catraca>(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Catraca__ID_Equi__7A672E12");
        }
    }
}
