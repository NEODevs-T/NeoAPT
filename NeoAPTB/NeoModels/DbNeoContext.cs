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

            entity.ToTable("Centro", tb => tb.HasComment("centro de produccion"));

            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.Cdetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle del centro")
                .HasColumnName("CDetalle");
            entity.Property(e => e.Cestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("CEstado");
            entity.Property(e => e.Cnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre del centro")
                .HasColumnName("CNom");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Centros)
                .HasForeignKey(d => d.IdEmpresa)
                .HasConstraintName("FK_Centro_Empresa");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.IdDivision);

            entity.ToTable("Division");

            entity.Property(e => e.Ddetalle)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DDetalle");
            entity.Property(e => e.Destado).HasColumnName("DEstado");
            entity.Property(e => e.Dnombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DNombre");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdCentro)
                .HasConstraintName("FK_Division_Centro");
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

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.IdLinea);

            entity.ToTable("Linea", tb => tb.HasComment("linea de produccion"));

            entity.Property(e => e.IdLinea).HasComment("identificador de la linea");
            entity.Property(e => e.IdCentro).HasComment("identificador del centro");
            entity.Property(e => e.LcenCos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LCenCos");
            entity.Property(e => e.Ldetalle)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Detalle de la linea")
                .HasColumnName("LDetalle");
            entity.Property(e => e.Lestado)
                .HasComment("0: Inactivo, 1:Activo")
                .HasColumnName("LEstado");
            entity.Property(e => e.Lnom)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("nombre de la linea")
                .HasColumnName("LNom");
            entity.Property(e => e.Lofic)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOFIC");

            entity.HasOne(d => d.IdCentroNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdCentro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Linea_Centro1");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Lineas)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("FK_Linea_Division");
        });

        modelBuilder.Entity<Monto>(entity =>
        {
            entity.HasKey(e => e.IdMontos);

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

            entity.HasOne(d => d.IdPuesTrabNavigation).WithMany(p => p.Montos)
                .HasForeignKey(d => d.IdPuesTrab)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Montos_PuesTrab");
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

        modelBuilder.Entity<Plantilla>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Plantilla");

            entity.Property(e => e.Pcentro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PCentro");
            entity.Property(e => e.PidLinea).HasColumnName("PIdLinea");
            entity.Property(e => e.PidPuesto).HasColumnName("PIdPuesto");
            entity.Property(e => e.Plinea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLinea");
            entity.Property(e => e.Ppuesto)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("PPuesto");

            entity.HasOne(d => d.IdPersonalNavigation).WithMany()
                .HasForeignKey(d => d.IdPersonal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Plantilla_Personal");
        });

        modelBuilder.Entity<PuesTrab>(entity =>
        {
            entity.HasKey(e => e.IdPuesTrab);

            entity.ToTable("PuesTrab");

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
            entity.HasKey(e => e.IdResumen).HasName("PK__Resumen__C15B26E506657487");

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
            entity.HasKey(e => e.IdTipIncen);

            entity.ToTable("TipIncen");

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
            entity.HasKey(e => e.IdTipSuple).HasName("PK__TipSuple__9ECDEC913F95291A");

            entity.ToTable("TipSuple");

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
