﻿// <auto-generated />
using System;
using Data_Access_Layer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data_Access_Layer.Entities.Car", b =>
                {
                    b.Property<Guid>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RentalPrice")
                        .HasColumnType("float");

                    b.HasKey("VehicleId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            VehicleId = new Guid("94729d91-3614-45c6-853c-b84813e79b48"),
                            Maker = "Tata",
                            Model = "Tiago",
                            RentalPrice = 1000.0
                        },
                        new
                        {
                            VehicleId = new Guid("32a3762b-d35d-468f-a516-4b7cfabca284"),
                            Maker = "Tata",
                            Model = "Altrox",
                            RentalPrice = 900.0
                        },
                        new
                        {
                            VehicleId = new Guid("6efaa307-81d0-4301-ab41-1330fdcdd40c"),
                            Maker = "Maruti Suzuki",
                            Model = "Ignis",
                            RentalPrice = 2000.0
                        },
                        new
                        {
                            VehicleId = new Guid("b7739c8f-dfca-472b-a9b1-86b5db19f578"),
                            Maker = "Maruti Suzuki",
                            Model = "Claz",
                            RentalPrice = 1200.0
                        });
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.RentalAgreement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RentalPrice")
                        .HasColumnType("float");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<double>("TotalCost")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RentalAgreements");
                });

            modelBuilder.Entity("Data_Access_Layer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "pawan123@gmail.com",
                            Name = "Pawan",
                            Password = "Pawan123@",
                            PhoneNumber = "123456789",
                            Role = "User"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Suraj123@gmail.com",
                            Name = "Suraj",
                            Password = "Suraj123@",
                            PhoneNumber = "123456789",
                            Role = "User"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Admin1234@gmail.com",
                            Name = "Admin",
                            Password = "Admin111@",
                            PhoneNumber = "12345671111",
                            Role = "Admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}