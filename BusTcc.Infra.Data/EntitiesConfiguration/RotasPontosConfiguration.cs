using BusTCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTCC.Infra.Data.EntitiesConfiguration
{
    internal class RotasPontosConfiguration : IEntityTypeConfiguration<RotasPontos>
    {
        public void Configure(EntityTypeBuilder<RotasPontos> builder)
        {
            
            builder.HasKey(rp => new { rp.IdRota, rp.IdPonto })
            .HasName("PK__RotasPon__3C2357955DA53A1F");

            builder.HasOne(rp => rp.Rota)
                .WithMany(r => r.RotasPontos)
                .HasForeignKey(rp => rp.IdRota)
                .HasConstraintName("FK__RotasPont__ID_Ro__5CA1C101");                
                

            builder.HasOne(rp => rp.Ponto)
                .WithMany(p => p.RotasPontos) 
                .HasForeignKey(rp => rp.IdPonto) 
                .HasConstraintName("FK__RotasPont__ID_Po__5D95E53A");

            builder.Property(rp => rp.IdRota)
                .HasColumnName("ID_Rotas");

            builder.Property(rp => rp.IdPonto)
                .HasColumnName("ID_Ponto");
            
            builder.Property(rp => rp.Ordem)
                .IsRequired(); 
        }
    }
}
