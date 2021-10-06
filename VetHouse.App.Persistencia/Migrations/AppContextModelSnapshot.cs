﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetHouse.App.Persistencia;

namespace VetHouse.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VetHouse.App.Dominio.CareSuggestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HistoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.ToTable("CareSuggestion");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnose")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("History");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.Persons", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persons");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("AuxVetId")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VetId")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AuxVetId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("VetId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.VitalSign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("BreathingFreq")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("HeartRate")
                        .HasColumnType("real");

                    b.Property<int?>("HistoryId")
                        .HasColumnType("int");

                    b.Property<float>("Temperature")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("HistoryId");

                    b.ToTable("VitalSign");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.AuxVet", b =>
                {
                    b.HasBaseType("VetHouse.App.Dominio.Persons");

                    b.Property<float>("LaborHours")
                        .HasColumnType("real");

                    b.Property<string>("ProfessionalCard")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("AuxVet");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.Owner", b =>
                {
                    b.HasBaseType("VetHouse.App.Dominio.Persons");

                    b.Property<string>("CC")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.Vet", b =>
                {
                    b.HasBaseType("VetHouse.App.Dominio.Persons");

                    b.Property<string>("RegisterRethus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Vet");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.CareSuggestions", b =>
                {
                    b.HasOne("VetHouse.App.Dominio.History", "History")
                        .WithMany()
                        .HasForeignKey("HistoryId");

                    b.Navigation("History");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.Pet", b =>
                {
                    b.HasOne("VetHouse.App.Dominio.AuxVet", "AuxVet")
                        .WithMany()
                        .HasForeignKey("AuxVetId");

                    b.HasOne("VetHouse.App.Dominio.Owner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.HasOne("VetHouse.App.Dominio.Vet", "Vet")
                        .WithMany()
                        .HasForeignKey("VetId");

                    b.Navigation("AuxVet");

                    b.Navigation("Owner");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.VitalSign", b =>
                {
                    b.HasOne("VetHouse.App.Dominio.History", null)
                        .WithMany("VitalSign")
                        .HasForeignKey("HistoryId");
                });

            modelBuilder.Entity("VetHouse.App.Dominio.History", b =>
                {
                    b.Navigation("VitalSign");
                });
#pragma warning restore 612, 618
        }
    }
}