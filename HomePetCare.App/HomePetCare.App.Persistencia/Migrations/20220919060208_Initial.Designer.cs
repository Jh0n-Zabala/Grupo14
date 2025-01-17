﻿// <auto-generated />
using System;
using HomePetCare.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomePetCare.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220919060208_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HomePetCare.App.Dominio.Historia", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entorno")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Individuo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Individuos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Individuo");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Recomendaciones", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaId");

                    b.ToTable("Recomendaciones");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.SignoVital", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MascotaId")
                        .HasColumnType("int");

                    b.Property<int?>("Signo")
                        .HasColumnType("int");

                    b.Property<float?>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MascotaId");

                    b.ToTable("SignosVitales");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Enfermera", b =>
                {
                    b.HasBaseType("HomePetCare.App.Dominio.Individuo");

                    b.Property<int?>("HorasLaborales")
                        .HasColumnType("int");

                    b.Property<string>("TarjetaProfesional")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Enfermera");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Mascota", b =>
                {
                    b.HasBaseType("HomePetCare.App.Dominio.Individuo");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<int?>("EnfermeraId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaId")
                        .HasColumnType("int");

                    b.Property<int?>("PropietarioId")
                        .HasColumnType("int");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VeterinarioId")
                        .HasColumnType("int");

                    b.HasIndex("EnfermeraId");

                    b.HasIndex("HistoriaId");

                    b.HasIndex("PropietarioId");

                    b.HasIndex("VeterinarioId");

                    b.HasDiscriminator().HasValue("Mascota");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Propietario", b =>
                {
                    b.HasBaseType("HomePetCare.App.Dominio.Individuo");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Propietario_Direccion");

                    b.Property<string>("Parentesco")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Propietario");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("HomePetCare.App.Dominio.Individuo");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Especialidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegistroRethus")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Recomendaciones", b =>
                {
                    b.HasOne("HomePetCare.App.Dominio.Historia", null)
                        .WithMany("Recomendaciones")
                        .HasForeignKey("HistoriaId");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.SignoVital", b =>
                {
                    b.HasOne("HomePetCare.App.Dominio.Mascota", null)
                        .WithMany("SignosVitales")
                        .HasForeignKey("MascotaId");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Mascota", b =>
                {
                    b.HasOne("HomePetCare.App.Dominio.Enfermera", "Enfermera")
                        .WithMany()
                        .HasForeignKey("EnfermeraId");

                    b.HasOne("HomePetCare.App.Dominio.Historia", "Historia")
                        .WithMany()
                        .HasForeignKey("HistoriaId");

                    b.HasOne("HomePetCare.App.Dominio.Propietario", "Propietario")
                        .WithMany()
                        .HasForeignKey("PropietarioId");

                    b.HasOne("HomePetCare.App.Dominio.Veterinario", "Veterinario")
                        .WithMany()
                        .HasForeignKey("VeterinarioId");

                    b.Navigation("Enfermera");

                    b.Navigation("Historia");

                    b.Navigation("Propietario");

                    b.Navigation("Veterinario");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Historia", b =>
                {
                    b.Navigation("Recomendaciones");
                });

            modelBuilder.Entity("HomePetCare.App.Dominio.Mascota", b =>
                {
                    b.Navigation("SignosVitales");
                });
#pragma warning restore 612, 618
        }
    }
}
