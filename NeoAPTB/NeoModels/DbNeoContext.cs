using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.NeoModels;

public partial class DbNeoContext : DbContext
{
    public DbNeoContext()
    {
    }

    public DbNeoContext(DbContextOptions<DbNeoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Centro> Centros { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<Master> Masters { get; set; }

    public virtual DbSet<Monedum> Moneda { get; set; }

    public virtual DbSet<Monto> Montos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Personal> Personals { get; set; }

    public virtual DbSet<Plantilla> Plantillas { get; set; }

    public virtual DbSet<PuesTrab> PuesTrabs { get; set; }

    public virtual DbSet<Resuman> Resumen { get; set; }

    public virtual DbSet<TipIncen> TipIncens { get; set; }

    public virtual DbSet<TipSuple> TipSuples { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Centro>(entity =>
        {
            entity.HasKey(e => e.IdCentro);

            entity.ToTable("Centro", "mae");

            entity.Property(e => e.Cdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("CDetalle");
            entity.Property(e => e.Cestado).HasColumnName("CEstado");
            entity.Property(e => e.Cnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("CNom");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision).HasName("PK_Division_1");

            entity.ToTable("Division", "mae");

            entity.Property(e => e.Ddetalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DDetalle");
            entity.Property(e => e.Destado).HasColumnName("DEstado");
            entity.Property(e => e.Dnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DNombre");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa).HasName("PK_Empresa_1");

            entity.ToTable("Empresa", "mae");

            entity.Property(e => e.Edescri)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("EDescri");
            entity.Property(e => e.Eestado).HasColumnName("EEstado");
            entity.Property(e => e.Enombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ENombre");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea).HasName("PK_Linea_1");

            entity.ToTable("Linea", "mae");

            entity.Property(e => e.LcenCos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LCenCos");
            entity.Property(e => e.Ldetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("LDetalle");
            entity.Property(e => e.Lestado).HasColumnName("LEstado");
            entity.Property(e => e.Lnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("LNom");
            entity.Property(e => e.Lofic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOFIC");
        });

        modelBuilder.Entity<Master>(entity =>
        {
            entity.HasKey(e => e.IdMaster);

            entity.ToTable("Master", "mae");

            entity.HasIndex(e => e.IdLinea, "IX_IdLinea").IsUnique();

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Masters)
                .HasForeignKey(d => d.IdCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_Centro");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Masters)
                .HasForeignKey(d => d.IdDivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_Division");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Masters)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_Empresa");

            entity.HasOne(d => d.IdLineaNavigation).WithOne(p => p.Master)
                .HasForeignKey<Master>(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_Linea");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Masters)
                .HasForeignKey(d => d.IdPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Master_Pais");
        });

        modelBuilder.Entity<Monedum>(entity =>
        {
            entity.HasKey(e => e.IdMoneda);

            entity.ToTable("Moneda", "per");

            entity.Property(e => e.Mestado).HasColumnName("MEstado");
            entity.Property(e => e.Mpais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MPais");
            entity.Property(e => e.Mtipo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MTipo");
        });

        modelBuilder.Entity<Monto>(entity =>
        {
            entity.HasKey(e => e.IdMontos).HasName("PK_Montos_1");

            entity.ToTable("Montos", "per");

            entity.Property(e => e.Mescalon).HasColumnName("MEscalon");
            entity.Property(e => e.Mesta).HasColumnName("MEsta");
            entity.Property(e => e.MfecAct)
                .HasColumnType("datetime")
                .HasColumnName("MFecAct");
            entity.Property(e => e.Mmonto).HasColumnName("MMonto");
            entity.Property(e => e.Muser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MUser");

            entity.HasOne(d => d.IdLineaNavigation).WithMany(p => p.Montos)
                .HasForeignKey(d => d.IdLinea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Montos_Linea");

            entity.HasOne(d => d.IdMonedaNavigation).WithMany(p => p.Montos)
                .HasForeignKey(d => d.IdMoneda)
                .HasConstraintName("FK_Montos_Moneda");

            entity.HasOne(d => d.IdPuesTrabNavigation).WithMany(p => p.Montos)
                .HasForeignKey(d => d.IdPuesTrab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Montos_PuesTrab");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais);

            entity.ToTable("Pais", "mae");

            entity.Property(e => e.Pestado).HasColumnName("PEstado");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PNombre");
        });

        modelBuilder.Entity<Personal>(entity =>
        {
            entity.HasKey(e => e.IdPersonal);

            entity.ToTable("Personal", "per");

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

        modelBuilder.Entity<Plantilla>(entity =>
        {
            entity.HasKey(e => e.IdPlantilla).HasName("PK_Plantilla_1");

            entity.ToTable("Plantilla", "per");

            entity.Property(e => e.Pcentro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PCentro");
            entity.Property(e => e.PidLinea).HasColumnName("PIdLinea");
            entity.Property(e => e.PidMaestra).HasColumnName("PIdMaestra");
            entity.Property(e => e.PidPuesto).HasColumnName("PIdPuesto");
            entity.Property(e => e.Plinea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLinea");
            entity.Property(e => e.Ppuesto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PPuesto");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Plantillas)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plantilla_Personal");
        });

        modelBuilder.Entity<PuesTrab>(entity =>
        {
            entity.HasKey(e => e.IdPuesTrab).HasName("PK_PuesTrab_1");

            entity.ToTable("PuesTrab", "per");

            entity.Property(e => e.Ptdescri)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PTDescri");
            entity.Property(e => e.Ptesta).HasColumnName("PTEsta");
            entity.Property(e => e.Ptnombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PTNombre");
        });

        modelBuilder.Entity<Resuman>(entity =>
        {
            entity.HasKey(e => e.IdResumen);

            entity.ToTable("Resumen", "per");

            entity.Property(e => e.RaprNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RAprNom");
            entity.Property(e => e.RaproJef).HasColumnName("RAproJef");
            entity.Property(e => e.RfecPago)
                .HasColumnType("datetime")
                .HasColumnName("RFecPago");
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
            entity.Property(e => e.Rturno).HasColumnName("RTurno");
            entity.Property(e => e.RuserPago)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RUserPago");
            entity.Property(e => e.RuserVali)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RUserVali");
            entity.Property(e => e.Rvalido).HasColumnName("RValido");

            entity.HasOne(d => d.IdMontosNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdMontos)
                .HasConstraintName("FK_Resumen_Montos");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Resumen_Personal");

            entity.HasOne(d => d.IdTipIncenNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdTipIncen)
                .HasConstraintName("FK_Resumen_TipIncen");

            entity.HasOne(d => d.IdTipSupleNavigation).WithMany(p => p.Resumen)
                .HasForeignKey(d => d.IdTipSuple)
                .HasConstraintName("FK_Resumen_TipSuple");
        });

        modelBuilder.Entity<TipIncen>(entity =>
        {
            entity.HasKey(e => e.IdTipIncen).HasName("PK_TipIncen_1");

            entity.ToTable("TipIncen", "per");

            entity.Property(e => e.Tidesc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TIDesc");
            entity.Property(e => e.Tiesta).HasColumnName("TIEsta");
            entity.Property(e => e.Tinombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TINombre");
        });

        modelBuilder.Entity<TipSuple>(entity =>
        {
            entity.HasKey(e => e.IdTipSuple);

            entity.ToTable("TipSuple", "per");

            entity.Property(e => e.Tscausa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TSCausa");
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
