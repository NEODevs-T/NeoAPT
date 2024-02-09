using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.ModelsViews;

public partial class ViewsContext : DbContext
{
    public ViewsContext()
    {
    }

    public ViewsContext(DbContextOptions<ViewsContext> options)
        : base(options)
    {
    }



    public virtual DbSet<CentrosV> CentrosVs { get; set; }

    public virtual DbSet<DivisionesV> DivisionesVs { get; set; }

    public virtual DbSet<EmpresasV> EmpresasVs { get; set; }

    public virtual DbSet<LineaV> LineaVs { get; set; }

    public virtual DbSet<MaestraV> MaestraVs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      

        modelBuilder.Entity<CentrosV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Centros_V");

            entity.Property(e => e.Centro)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DivisionesV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Divisiones_V");

            entity.Property(e => e.Ndivision)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NDivision");
        });

        modelBuilder.Entity<EmpresasV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Empresas_V");

            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LineaV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Linea_V");

            entity.Property(e => e.Linea)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MaestraV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Maestra_V");

            entity.Property(e => e.Centro)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.División)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Empresa)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Linea)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
