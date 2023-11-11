﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProyectoFinalProg1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Alcalde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aceptacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("InicioAlcaldia")
                        .HasColumnType("TEXT");

                    b.Property<int>("MunicipalidadId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MunicipalidadId")
                        .IsUnique();

                    b.ToTable("Alcalde");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.FormacionAcademica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AlcaldeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AñoGraduacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Carrera")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdAlcalde")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Universidad")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlcaldeId");

                    b.ToTable("FormacionAcademica");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Municipalidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aceptacion")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Departamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Distrito")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreMunicipalidad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Referencia")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Municipalidad");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Noticias", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resumen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Noticias");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Alcalde", b =>
                {
                    b.HasOne("ProyectoFinalProg1.Models.Entidades.Municipalidad", null)
                        .WithOne("Alcalde")
                        .HasForeignKey("ProyectoFinalProg1.Models.Entidades.Alcalde", "MunicipalidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.FormacionAcademica", b =>
                {
                    b.HasOne("ProyectoFinalProg1.Models.Entidades.Alcalde", null)
                        .WithMany("Academico")
                        .HasForeignKey("AlcaldeId");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Alcalde", b =>
                {
                    b.Navigation("Academico");
                });

            modelBuilder.Entity("ProyectoFinalProg1.Models.Entidades.Municipalidad", b =>
                {
                    b.Navigation("Alcalde");
                });
#pragma warning restore 612, 618
        }
    }
}
