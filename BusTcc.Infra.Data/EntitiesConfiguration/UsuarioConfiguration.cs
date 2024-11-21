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
    internal class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {            
            builder.HasKey(e => e.IdUsuario).HasName("PK__Usuario__2B3DE7B8A0EE4196");

            builder.ToTable("Usuario");

            builder.Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Usuario");
            builder.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);            
            builder.Property(e => e.NomeCompleto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Nome_Completo");            
        
        }
    }
}
