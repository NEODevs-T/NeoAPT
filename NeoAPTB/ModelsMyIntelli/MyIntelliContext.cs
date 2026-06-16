using Microsoft.EntityFrameworkCore;

namespace NeoAPTB.ModelsMyIntelli;

public partial class MyIntelliContext : DbContext
{
    public MyIntelliContext()
    {
    }

    public MyIntelliContext(DbContextOptions<MyIntelliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrabajadorEnPuestoVMi> TrabajadorEnPuestoVMis { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrabajadorEnPuestoVMi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ControlPersonal_V_MI");

            entity.Property(e => e.Cedula)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.CodigoTrabajador)
                .HasMaxLength(20);

            entity.Property(e => e.NombreTrabajador)
                .HasMaxLength(100);

            entity.Property(e => e.IdTipoTrabajador)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.Property(e => e.FechaBpcs)
                .HasColumnName("FechaBPCS")
                .HasMaxLength(8)
                .IsUnicode(false);

            entity.Property(e => e.FechaEntrada)
                .HasColumnType("datetime");

            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime");

            entity.Property(e => e.HoraEntrada);

            entity.Property(e => e.HoraSalida);

            entity.Property(e => e.CodigoDpto);

            entity.Property(e => e.NombreDpto)
                .HasMaxLength(255);

            entity.Property(e => e.Grupo)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.CodigoPermiso)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Permiso)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.HorasDelPermiso)
                .HasColumnName("Horas del Permiso");

            entity.Property(e => e.DiasDelPermiso)
                .HasColumnName("Dias del Permiso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}