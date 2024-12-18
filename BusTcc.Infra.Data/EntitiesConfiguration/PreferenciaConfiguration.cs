﻿using BusTCC.Domain.Entities;
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
    internal class PreferenciaConfiguration : IEntityTypeConfiguration<Preferencia>
    {
        public void Configure(EntityTypeBuilder<Preferencia> builder)
        {            
            builder.HasKey(e => e.IdPreferencia).HasName("PK__Preferen__F071255AEC8610B5");

            builder.Property(e => e.IdPreferencia)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Preferencia");
            builder.Property(e => e.Deficiencia)
                .HasColumnName("Deficiencia");
            builder.Property(e => e.Notificacao)
                .HasColumnName("Notificacao");
            builder.Property(e => e.IdUsuario).HasColumnName("ID_Usuario");
            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Preferencias)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Preferencia_Usuario");
        }
    }
}
