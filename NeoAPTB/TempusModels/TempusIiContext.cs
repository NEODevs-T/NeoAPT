using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.TempusModels;

public partial class TempusIiContext : DbContext
{
    public TempusIiContext()
    {
    }

    public TempusIiContext(DbContextOptions<TempusIiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrabajadorEnPuestoV> TrabajadorEnPuestoVs { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

        modelBuilder.Entity<TrabajadorEnPuestoV>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TrabajadorEnPuesto_V");

            entity.Property(e => e.CodigoCia)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CodigoDpto)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CodigoTrabajador)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DesPuesto)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.DescTipoTrab)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora).HasMaxLength(4000);
            entity.Property(e => e.Grupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NombreCia)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreDpto)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.NombreTrab)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
