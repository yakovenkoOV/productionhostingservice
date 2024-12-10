﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProductionHostingService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EquipmentPlacementContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProcessEquipmentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionFacilityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProcessEquipmentTypeId");

                    b.HasIndex("ProductionFacilityId");

                    b.ToTable("EquipmentPlacementContracts");
                });

            modelBuilder.Entity("ProcessEquipmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("IX_ProcessEquipmentType_Code");

                    b.ToTable("ProcessEquipmentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = 50,
                            Code = "PET001",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 1",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            Area = 75,
                            Code = "PET002",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 2",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            Area = 60,
                            Code = "PET003",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 3",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            Area = 80,
                            Code = "PET004",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 4",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            Area = 100,
                            Code = "PET005",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 5",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            Area = 45,
                            Code = "PET006",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 6",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            Area = 110,
                            Code = "PET007",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 7",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            Area = 65,
                            Code = "PET008",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 8",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            Area = 90,
                            Code = "PET009",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 9",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            Area = 120,
                            Code = "PET010",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Обладнання 10",
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ProductionFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StandardArea")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("IX_ProductionFacility_Code");

                    b.ToTable("ProductionFacilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "PF001",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 1",
                            StandardArea = 1000,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 2,
                            Code = "PF002",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 2",
                            StandardArea = 1200,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 3,
                            Code = "PF003",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 3",
                            StandardArea = 1500,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 4,
                            Code = "PF004",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 4",
                            StandardArea = 2000,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 5,
                            Code = "PF005",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 5",
                            StandardArea = 1800,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 6,
                            Code = "PF006",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 6",
                            StandardArea = 2200,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 7,
                            Code = "PF007",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 7",
                            StandardArea = 2500,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 8,
                            Code = "PF008",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 8",
                            StandardArea = 3000,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 9,
                            Code = "PF009",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 9",
                            StandardArea = 3500,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = 10,
                            Code = "PF010",
                            CreatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Фабрика 10",
                            StandardArea = 4000,
                            UpdatedAt = new DateTime(2024, 12, 6, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("EquipmentPlacementContract", b =>
                {
                    b.HasOne("ProcessEquipmentType", "ProcessEquipmentType")
                        .WithMany("Contracts")
                        .HasForeignKey("ProcessEquipmentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProductionFacility", "ProductionFacility")
                        .WithMany("Contracts")
                        .HasForeignKey("ProductionFacilityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProcessEquipmentType");

                    b.Navigation("ProductionFacility");
                });

            modelBuilder.Entity("ProcessEquipmentType", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("ProductionFacility", b =>
                {
                    b.Navigation("Contracts");
                });
#pragma warning restore 612, 618
        }
    }
}
