﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Polgresso.Entities.Drivers;
using Polgresso.PolicyMaker.Web.Service.Db;
using System;

namespace Polgresso.PolicyMaker.Web.Service.Migrations
{
    [DbContext(typeof(PolicyMakerDbContext))]
    [Migration("20170915183328_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Polgresso.Entities.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StateAbbreviation")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StateAbbreviation");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Polgresso.Entities.Coverages.ApplicationCoverage", b =>
                {
                    b.Property<int>("ApplicationId");

                    b.Property<int>("CoverageId");

                    b.HasKey("ApplicationId", "CoverageId");

                    b.HasIndex("CoverageId");

                    b.ToTable("ApplicationCoverage");
                });

            modelBuilder.Entity("Polgresso.Entities.Coverages.Coverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Coverage");
                });

            modelBuilder.Entity("Polgresso.Entities.Coverages.StateCoverage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateAbbreviation");

                    b.Property<int>("CoverageId");

                    b.Property<decimal?>("Deductible");

                    b.Property<bool>("IsRequired");

                    b.Property<decimal?>("PerAccidentLimit");

                    b.Property<decimal?>("PerPersonLimit");

                    b.HasKey("Id", "StateAbbreviation", "CoverageId");

                    b.HasIndex("CoverageId");

                    b.HasIndex("StateAbbreviation");

                    b.ToTable("StateCoverages");
                });

            modelBuilder.Entity("Polgresso.Entities.Drivers.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationId");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<bool>("IsInsured");

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("LicenseNumber")
                        .IsRequired();

                    b.Property<int>("MartialStatus");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Polgresso.Entities.Drivers.DriverViolation", b =>
                {
                    b.Property<int>("DriverId");

                    b.Property<int>("ViolationId");

                    b.HasKey("DriverId", "ViolationId");

                    b.HasIndex("ViolationId");

                    b.ToTable("DriverViolation");
                });

            modelBuilder.Entity("Polgresso.Entities.Drivers.Violation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AcdCode");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("Violations");
                });

            modelBuilder.Entity("Polgresso.Entities.NamedInsured", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("PrimaryPhoneNumber")
                        .IsRequired();

                    b.Property<string>("SecondaryPhoneNumber");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId")
                        .IsUnique();

                    b.ToTable("NamedInsured");
                });

            modelBuilder.Entity("Polgresso.Entities.State", b =>
                {
                    b.Property<string>("Abbreviation")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Abbreviation");

                    b.ToTable("States");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeId");

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ApplicationId");

                    b.Property<string>("Class");

                    b.Property<string>("Color");

                    b.Property<int>("Cylinders");

                    b.Property<bool>("HasAbsBrakes");

                    b.Property<bool>("HasAntiTheft");

                    b.Property<string>("OriginCountry");

                    b.Property<string>("Transmission");

                    b.Property<int?>("TypeId");

                    b.Property<string>("Vin");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("TypeId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.VehicleMake", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("MakeId");

                    b.HasKey("VehicleId", "MakeId");

                    b.HasIndex("MakeId");

                    b.ToTable("VehicleMake");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.VehicleModel", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("ModelId");

                    b.HasKey("VehicleId", "ModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("VehicleModel");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.VehicleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("VehicleType");
                });

            modelBuilder.Entity("Polgresso.Entities.Application", b =>
                {
                    b.HasOne("Polgresso.Entities.State", "State")
                        .WithMany("Applications")
                        .HasForeignKey("StateAbbreviation")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.Coverages.ApplicationCoverage", b =>
                {
                    b.HasOne("Polgresso.Entities.Application", "Application")
                        .WithMany("ApplicationCoverages")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polgresso.Entities.Coverages.Coverage", "Coverage")
                        .WithMany("ApplicationCoverages")
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.Coverages.StateCoverage", b =>
                {
                    b.HasOne("Polgresso.Entities.Coverages.Coverage", "Coverage")
                        .WithMany("StateCoverages")
                        .HasForeignKey("CoverageId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polgresso.Entities.State", "State")
                        .WithMany("StateCoverages")
                        .HasForeignKey("StateAbbreviation")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.Drivers.Driver", b =>
                {
                    b.HasOne("Polgresso.Entities.Application")
                        .WithMany("Drivers")
                        .HasForeignKey("ApplicationId");
                });

            modelBuilder.Entity("Polgresso.Entities.Drivers.DriverViolation", b =>
                {
                    b.HasOne("Polgresso.Entities.Drivers.Driver", "Driver")
                        .WithMany("DriverViolations")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polgresso.Entities.Drivers.Violation", "Violation")
                        .WithMany("DriverViolations")
                        .HasForeignKey("ViolationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.NamedInsured", b =>
                {
                    b.HasOne("Polgresso.Entities.Application", "Application")
                        .WithOne("NamedInsured")
                        .HasForeignKey("Polgresso.Entities.NamedInsured", "ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Polgresso.Entities.Address", "MailingAddress", b1 =>
                        {
                            b1.Property<int>("NamedInsuredId");

                            b1.Property<string>("City")
                                .IsRequired();

                            b1.Property<string>("County")
                                .IsRequired();

                            b1.Property<string>("PostalCode")
                                .IsRequired();

                            b1.Property<string>("StateAbbreviation")
                                .IsRequired();

                            b1.Property<string>("StreetLine1")
                                .IsRequired();

                            b1.Property<string>("StreetLine2");

                            b1.ToTable("NamedInsured");

                            b1.HasOne("Polgresso.Entities.NamedInsured")
                                .WithOne("MailingAddress")
                                .HasForeignKey("Polgresso.Entities.Address", "NamedInsuredId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Polgresso.Entities.Address", "PhysicalAddress", b1 =>
                        {
                            b1.Property<int?>("NamedInsuredId");

                            b1.Property<string>("City")
                                .IsRequired();

                            b1.Property<string>("County")
                                .IsRequired();

                            b1.Property<string>("PostalCode")
                                .IsRequired();

                            b1.Property<string>("StateAbbreviation")
                                .IsRequired();

                            b1.Property<string>("StreetLine1")
                                .IsRequired();

                            b1.Property<string>("StreetLine2");

                            b1.ToTable("NamedInsured");

                            b1.HasOne("Polgresso.Entities.NamedInsured")
                                .WithOne("PhysicalAddress")
                                .HasForeignKey("Polgresso.Entities.Address", "NamedInsuredId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.Model", b =>
                {
                    b.HasOne("Polgresso.Entities.Vehicles.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.Vehicle", b =>
                {
                    b.HasOne("Polgresso.Entities.Application")
                        .WithMany("Vehicles")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Polgresso.Entities.Vehicles.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.VehicleMake", b =>
                {
                    b.HasOne("Polgresso.Entities.Vehicles.Make", "Make")
                        .WithMany("VehicleMakes")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polgresso.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("VehicleMakes")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Polgresso.Entities.Vehicles.VehicleModel", b =>
                {
                    b.HasOne("Polgresso.Entities.Vehicles.Model", "Model")
                        .WithMany("VehicleModels")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Polgresso.Entities.Vehicles.Vehicle", "Vehicle")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}