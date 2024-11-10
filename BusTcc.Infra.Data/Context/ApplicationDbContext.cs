using System;
using System.Collections.Generic;
using BusTCC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusTCC.Domain.Infra.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Catraca> Catracas { get; set; }

    public virtual DbSet<Comunicacao> Comunicacaos { get; set; }

    public virtual DbSet<Equipamento> Equipamentos { get; set; }

    public virtual DbSet<Onibus> Onibus { get; set; }

    public virtual DbSet<Ponto> Pontos { get; set; }

    public virtual DbSet<Preferencia> Preferencia { get; set; }

    public virtual DbSet<Rota> Rota { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AP20EVO\\SQLDEVELOP;Database=BUSFTCC;User ID=admin_bus;Password=#Killu_410;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);     

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
