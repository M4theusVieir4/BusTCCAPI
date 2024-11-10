using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BusTCC.Domain.Entities;

public partial class BusftccContext : DbContext
{
    public BusftccContext()
    {
    }

    public BusftccContext(DbContextOptions<BusftccContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catraca> Catracas { get; set; }

    public virtual DbSet<Comunicacao> Comunicacaos { get; set; }

    public virtual DbSet<Equipamento> Equipamentos { get; set; }

    public virtual DbSet<Onibu> Onibus { get; set; }

    public virtual DbSet<Ponto> Pontos { get; set; }

    public virtual DbSet<Preferencium> Preferencia { get; set; }

    public virtual DbSet<Rota> Rotas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AP20EVO\\SQLDEVELOP;Database=BUSFTCC;User ID=admin_bus;Password=#Killu_410;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Catraca>(entity =>
        {
            entity.HasKey(e => e.IdCatraca).HasName("PK__Catraca__B88D543CBA1F1013");

            entity.ToTable("Catraca");

            entity.Property(e => e.IdCatraca)
                .ValueGeneratedNever()
                .HasColumnName("ID_Catraca");
            entity.Property(e => e.IdEquipamento).HasColumnName("ID_Equipamento");
            entity.Property(e => e.Local)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuantidadeEntrada)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Quantidade_Entrada");
            entity.Property(e => e.QuantidadeSaida)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("Quantidade_Saida");

            entity.HasOne(d => d.IdEquipamentoNavigation).WithMany(p => p.Catracas)
                .HasForeignKey(d => d.IdEquipamento)
                .HasConstraintName("FK__Catraca__ID_Equi__7A672E12");
        });

        modelBuilder.Entity<Comunicacao>(entity =>
        {
            entity.HasKey(e => e.IdDados).HasName("PK__Comunica__5686989247556584");

            entity.ToTable("Comunicacao");

            entity.Property(e => e.IdDados)
                .ValueGeneratedNever()
                .HasColumnName("ID_Dados");
            entity.Property(e => e.IdCatraca).HasColumnName("ID_Catraca");
            entity.Property(e => e.IdEquipamento).HasColumnName("ID_Equipamento");

            entity.HasOne(d => d.IdCatracaNavigation).WithMany(p => p.Comunicacaos)
                .HasForeignKey(d => d.IdCatraca)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comunicacao_catraca");

            entity.HasOne(d => d.IdEquipamentoNavigation).WithMany(p => p.Comunicacaos)
                .HasForeignKey(d => d.IdEquipamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_comunicacao_equipamento");
        });

        modelBuilder.Entity<Equipamento>(entity =>
        {
            entity.HasKey(e => e.IdEquipamento).HasName("PK__Equipame__7ADEBA86434904E6");

            entity.ToTable("Equipamento");

            entity.Property(e => e.IdEquipamento)
                .ValueGeneratedNever()
                .HasColumnName("ID_Equipamento");
            entity.Property(e => e.IdDados).HasColumnName("ID_Dados");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroSerie)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("Numero_Serie");

            entity.HasOne(d => d.IdDadosNavigation).WithMany(p => p.Equipamentos)
                .HasForeignKey(d => d.IdDados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipamento_comunicacao");
        });

        modelBuilder.Entity<Onibu>(entity =>
        {
            entity.HasKey(e => e.IdOnibus).HasName("PK__Onibus__FEB5D74C84AF4425");

            entity.Property(e => e.IdOnibus)
                .ValueGeneratedNever()
                .HasColumnName("ID_Onibus");
            entity.Property(e => e.AnoFabricacao).HasColumnName("Ano_Fabricacao");
            entity.Property(e => e.IdDados).HasColumnName("ID_Dados");
            entity.Property(e => e.IdRotas).HasColumnName("ID_Rotas");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Placa)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.TaxaOnibus)
                .HasColumnType("decimal(9, 6)")
                .HasColumnName("Taxa_Onibus");

            entity.HasOne(d => d.IdDadosNavigation).WithMany(p => p.Onibus)
                .HasForeignKey(d => d.IdDados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_onibus_comunicacao");

            entity.HasOne(d => d.IdRotasNavigation).WithMany(p => p.Onibus)
                .HasForeignKey(d => d.IdRotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_onibus_rotas");
        });

        modelBuilder.Entity<Ponto>(entity =>
        {
            entity.HasKey(e => e.IdPonto).HasName("PK__Ponto__2D43D62046193992");

            entity.ToTable("Ponto");

            entity.Property(e => e.IdPonto)
                .ValueGeneratedNever()
                .HasColumnName("ID_Ponto");
            entity.Property(e => e.Bairro)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdRotas).HasColumnName("ID_Rotas");
            entity.Property(e => e.RuaAvenida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rua_Avenida");

            entity.HasOne(d => d.IdRotasNavigation).WithMany(p => p.Pontos)
                .HasForeignKey(d => d.IdRotas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ponto__ID_Rotas__71D1E811");
        });

        modelBuilder.Entity<Preferencium>(entity =>
        {
            entity.HasKey(e => e.IdPreferencia).HasName("PK__Preferen__F071255A61B88047");

            entity.Property(e => e.IdPreferencia)
                .ValueGeneratedNever()
                .HasColumnName("ID_Preferencia");
            entity.Property(e => e.Deficiencia)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Notificacao)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rota>(entity =>
        {
            entity.HasKey(e => e.IdRotas).HasName("PK__Rotas__2EF76AF7EDB3594A");

            entity.Property(e => e.IdRotas)
                .ValueGeneratedNever()
                .HasColumnName("ID_Rotas");
            entity.Property(e => e.IdOnibus).HasColumnName("ID_Onibus");
            entity.Property(e => e.IdPonto).HasColumnName("ID_Ponto");

            entity.HasOne(d => d.IdOnibusNavigation).WithMany(p => p.Rota)
                .HasForeignKey(d => d.IdOnibus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rotas_onibus");

            entity.HasOne(d => d.IdPontoNavigation).WithMany(p => p.Rota)
                .HasForeignKey(d => d.IdPonto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rotas_ponto");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__DE4431C5859EFF66");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("ID_Usuario");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdPreferencia).HasColumnName("ID_Preferencia");
            entity.Property(e => e.NomeCompleto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("Nome_Completo");
            entity.Property(e => e.NumeroCelular).HasColumnName("Numero_Celular");

            entity.HasOne(d => d.IdPreferenciaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPreferencia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__ID_Pref__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
