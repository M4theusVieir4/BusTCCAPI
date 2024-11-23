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
    internal class OnibusRotaConfiguration : IEntityTypeConfiguration<OnibusRota>
    {
        public void Configure(EntityTypeBuilder<OnibusRota> builder)
        {
            builder.HasKey(or => new { or.IdOnibus, or.IdRota })
            .HasName("PK__OnibusRo__9C5AA1E3422DDDA1");
            
            builder
                .HasOne(or => or.Onibus)               
                .WithMany(o => o.OnibusRotas)           
                .HasForeignKey(or => or.IdOnibus)      
                .HasConstraintName("FK__OnibusRot__ID_On__58D1301D");  

            builder
                .HasOne(or => or.Rota)                 
                .WithMany(r => r.OnibusRotas)          
                .HasForeignKey(or => or.IdRota)        
                .HasConstraintName("FK__OnibusRot__ID_Ro__59C55456");

            builder.Property(rp => rp.IdRota)
                .HasColumnName("ID_Rotas");

            builder.Property(rp => rp.IdOnibus)
                .HasColumnName("ID_Onibus");
        }
    }
}
