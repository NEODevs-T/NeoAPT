using System;
using System.Collections.Generic;
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=aztdtdb03\\dbven01;Initial Catalog=TempusII;TrustServerCertificate=True;Persist Security Info=True;User ID=UsrLecMyInt;Password=Sql*Db-2628**");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrabajadorEnPuestoVMi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TrabajadorEnPuesto_V_MI");

            entity.Property(e => e.CodigoTrabajador).HasMaxLength(20);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.FechaHora)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.FechaHoraCompleta).HasMaxLength(50);
            entity.Property(e => e.FechaHoraSubida).HasMaxLength(50);
            entity.Property(e => e.NombreDpto).HasMaxLength(255);
            entity.Property(e => e.NombreTrab).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
