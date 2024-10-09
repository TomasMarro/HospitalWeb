using Microsoft.EntityFrameworkCore;

namespace HospitalModels.Modelos;

public partial class HospitalAppContext : DbContext
{
    public HospitalAppContext()
    {
    }

    public HospitalAppContext(DbContextOptions<HospitalAppContext> options)
        : base(options)
    {
        this.Database.SetCommandTimeout(680);
    }



    public virtual DbSet<Egreso> Egresos { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Egreso>(entity =>
        {
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tratamiento).IsUnicode(false);

            entity.HasOne(d => d.Ingreso).WithMany(p => p.Egresos)
                .HasForeignKey(d => d.IngresoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Egresos_Ingresos");

            entity.HasOne(d => d.Medico).WithMany(p => p.Egresos)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Egresos_Medicos");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.Property(e => e.Diagnostico).IsUnicode(false);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observacion).IsUnicode(false);

            entity.HasOne(d => d.Medico).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.MedicoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingresos_Medicos");

            entity.HasOne(d => d.Paciente).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.PacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingresos_Pacientes");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            //Ignorar de la bd los medicos que tengan true en borrado
            entity.HasQueryFilter(p => !p.Borrado);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
