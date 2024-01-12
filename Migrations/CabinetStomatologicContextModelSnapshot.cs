﻿// <auto-generated />
using System;
using CabinetStomatologic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CabinetStomatologic.Migrations
{
    [DbContext(typeof(CabinetStomatologicContext))]
    partial class CabinetStomatologicContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CabinetStomatologic.Models.Cabinet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Etaj")
                        .HasColumnType("int");

                    b.Property<int>("NumarSala")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Cabinet");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonMobil")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Titulatura")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Doctor");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Pacient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonMobil")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Programare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataProgramare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Programare");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Specializare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeSpecializare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.SpecializariDoctori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int>("SpecializareID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("SpecializareID");

                    b.ToTable("SpecializariDoctori");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.SpecializariDoctori", b =>
                {
                    b.HasOne("CabinetStomatologic.Models.Doctor", "Doctor")
                        .WithMany("SpecializariDoctori")
                        .HasForeignKey("DoctorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CabinetStomatologic.Models.Specializare", "Specializare")
                        .WithMany("SpecializariDoctori")
                        .HasForeignKey("SpecializareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Specializare");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Doctor", b =>
                {
                    b.Navigation("SpecializariDoctori");
                });

            modelBuilder.Entity("CabinetStomatologic.Models.Specializare", b =>
                {
                    b.Navigation("SpecializariDoctori");
                });
#pragma warning restore 612, 618
        }
    }
}
