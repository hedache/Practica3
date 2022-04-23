﻿// <auto-generated />
using System;
using Colegio.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Colegio.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220423145911_lol2")]
    partial class lol2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Colegio.Web.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BarrioId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BarrioId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("Colegio.Web.Models.Barrio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MunicipioId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Barrios");
                });

            modelBuilder.Entity("Colegio.Web.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("Colegio.Web.Models.Alumno", b =>
                {
                    b.HasOne("Colegio.Web.Models.Barrio", null)
                        .WithMany("Alumnos")
                        .HasForeignKey("BarrioId");
                });

            modelBuilder.Entity("Colegio.Web.Models.Barrio", b =>
                {
                    b.HasOne("Colegio.Web.Models.Municipio", null)
                        .WithMany("Barrios")
                        .HasForeignKey("MunicipioId");
                });

            modelBuilder.Entity("Colegio.Web.Models.Barrio", b =>
                {
                    b.Navigation("Alumnos");
                });

            modelBuilder.Entity("Colegio.Web.Models.Municipio", b =>
                {
                    b.Navigation("Barrios");
                });
#pragma warning restore 612, 618
        }
    }
}
