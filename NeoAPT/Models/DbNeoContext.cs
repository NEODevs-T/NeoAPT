﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeoAPT.Models;

public partial class DbNeoContext : DbContext
{
    public DbNeoContext()
    {
    }

    public DbNeoContext(DbContextOptions<DbNeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AreaTra> AreaTras { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Plantum> Planta { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Resuman> Resumen { get; set; }

    public virtual DbSet<TipSuple> TipSuples { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=10.20.1.60\\DESARROLLO;Initial Catalog=DbNeo;TrustServerCertificate=True;Persist Security Info=True;User ID=UsrEncuesta;Password=Enc2022**Ing");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AreaTra>(entity =>
        {
            entity.HasKey(e => e.IdAreaTra).HasName("PK__AreaTra__487F56B804138E4C");

            entity.ToTable("AreaTra");

            entity.Property(e => e.AtcodBpc).HasColumnName("ATCodBPC");
            entity.Property(e => e.Atcodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ATCodigo");
            entity.Property(e => e.Atestado).HasColumnName("ATEstado");
            entity.Property(e => e.Atnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ATNombre");

            entity.HasOne(d => d.IdPlantaNavigation).WithMany(p => p.AreaTras)
                .HasForeignKey(d => d.IdPlanta)
                .HasConstraintName("FK_AreaTra_Planta");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.Edescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDescri");
            entity.Property(e => e.Eestado).HasColumnName("EEstado");
            entity.Property(e => e.Enombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENombre");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empresa_Pais");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.Property(e => e.Pestado).HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal).HasName("PK__Personal__05A9201B1DEC2386");

            entity.ToTable("Personal");

            entity.Property(e => e.PeApellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PeFicha)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PeGrupo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.PeNombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Plantum>(entity =>
        {
            entity.HasKey(e => e.IdPlanta).HasName("PK__Planta__12FEC124F71E3A67");

            entity.Property(e => e.PlCodigo)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PlDescri)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Planta)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Planta_Empresa");
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.IdPuesto).HasName("PK__Puesto__ADAC6B9C1C93A40D");

            entity.ToTable("Puesto");

            entity.Property(e => e.PuCodigo)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.PuDescri)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAreaTraNavigation).WithMany(p => p.Puestos)
                .HasForeignKey(d => d.IdAreaTra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Puesto_AreaTra");
        });

        modelBuilder.Entity<Resuman>(entity =>
        {
            entity.HasKey(e => e.IdResumen).HasName("PK__Resumen__C15B26E506657487");

            entity.Property(e => e.Rfecha)
                .HasColumnType("datetime")
                .HasColumnName("RFecha");
            entity.Property(e => e.Rgrupo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("RGrupo");
            entity.Property(e => e.Rsuplido)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("RSuplido");
            entity.Property(e => e.Rturno)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("RTurno");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resumen_Personal");

            entity.HasOne(d => d.IdPuestoNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdPuesto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resumen_Puesto");

            entity.HasOne(d => d.IdTipSupleNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdTipSuple)
                .HasConstraintName("FK_Resumen_TipSuple");
        });

        modelBuilder.Entity<TipSuple>(entity =>
        {
            entity.HasKey(e => e.IdTipSuple).HasName("PK__TipSuple__9ECDEC913F95291A");

            entity.ToTable("TipSuple");

            entity.Property(e => e.Tscodigo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TSCodigo");
            entity.Property(e => e.Tsdescri)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("TSDescri");
            entity.Property(e => e.Tsestado).HasColumnName("TSEstado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
