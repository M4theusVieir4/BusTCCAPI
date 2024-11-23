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
            builder.HasKey(e => e.IdOnibus).HasName("PK__Onibus__FEB5D74C97507698");

            builder.Property(e => e.IdOnibus)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Onibus");
            builder.Property(e => e.AnoFabricacao).HasColumnName("Ano_Fabricacao");
            builder.Property(e => e.IdEquipamento).HasColumnName("ID_Equipamento");            
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

            builder.HasOne(d => d.IdEquipamentoNavigation).WithOne(p => p.Onibus)
                .HasForeignKey<Onibus>(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Onibus_Equipamento");

            builder.HasMany(o => o.OnibusRotas)   
            .WithOne(or => or.Onibus)         
            .HasForeignKey(or => or.IdOnibus)  
            .HasConstraintName("FK__OnibusRot__ID_On__58D1301D");
            
        }
    }
}
