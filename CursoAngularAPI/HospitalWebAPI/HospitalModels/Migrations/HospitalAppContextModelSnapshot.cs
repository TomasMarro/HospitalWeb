﻿// <auto-generated />
using System;
using HospitalModels.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalModels.Migrations
{
    [DbContext(typeof(HospitalAppContext))]
    partial class HospitalAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalModels.Modelos.Egreso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<long>("IngresoId")
                        .HasColumnType("bigint");

                    b.Property<long>("MedicoId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Tratamiento")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IngresoId");

                    b.HasIndex("MedicoId");

                    b.ToTable("Egresos");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Ingreso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<long>("MedicoId")
                        .HasColumnType("bigint");

                    b.Property<int>("NumeroCama")
                        .HasColumnType("int");

                    b.Property<int>("NumeroSala")
                        .HasColumnType("int");

                    b.Property<string>("Observacion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<long>("PacienteId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Medico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("EsEspecialista")
                        .HasColumnType("bit");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Paciente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Egreso", b =>
                {
                    b.HasOne("HospitalModels.Modelos.Ingreso", "Ingreso")
                        .WithMany("Egresos")
                        .HasForeignKey("IngresoId")
                        .IsRequired()
                        .HasConstraintName("FK_Egresos_Ingresos");

                    b.HasOne("HospitalModels.Modelos.Medico", "Medico")
                        .WithMany("Egresos")
                        .HasForeignKey("MedicoId")
                        .IsRequired()
                        .HasConstraintName("FK_Egresos_Medicos");

                    b.Navigation("Ingreso");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Ingreso", b =>
                {
                    b.HasOne("HospitalModels.Modelos.Medico", "Medico")
                        .WithMany("Ingresos")
                        .HasForeignKey("MedicoId")
                        .IsRequired()
                        .HasConstraintName("FK_Ingresos_Medicos");

                    b.HasOne("HospitalModels.Modelos.Paciente", "Paciente")
                        .WithMany("Ingresos")
                        .HasForeignKey("PacienteId")
                        .IsRequired()
                        .HasConstraintName("FK_Ingresos_Pacientes");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Ingreso", b =>
                {
                    b.Navigation("Egresos");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Medico", b =>
                {
                    b.Navigation("Egresos");

                    b.Navigation("Ingresos");
                });

            modelBuilder.Entity("HospitalModels.Modelos.Paciente", b =>
                {
                    b.Navigation("Ingresos");
                });
#pragma warning restore 612, 618
        }
    }
}