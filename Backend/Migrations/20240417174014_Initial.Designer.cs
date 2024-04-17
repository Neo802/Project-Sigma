﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectRunAway.Models;

#nullable disable

namespace ProjectRunAway.Migrations
{
    [DbContext(typeof(TableContext))]
    [Migration("20240417174014_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectRunAway.Models.Availability", b =>
                {
                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<int>("LocationsId")
                        .HasColumnType("int");

                    b.Property<string>("BusyCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly?>("DateEnd")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateStart")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("FromHour")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("ToHour")
                        .HasColumnType("time");

                    b.HasKey("CarsId", "LocationsId");

                    b.HasIndex("LocationsId");

                    b.ToTable("Availability");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Cars", b =>
                {
                    b.Property<int>("CarsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarsId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Doors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("PriceCar")
                        .HasColumnType("real");

                    b.Property<string>("Seats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("TankCapacity")
                        .HasColumnType("real");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("CarsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Features", b =>
                {
                    b.Property<int>("FeaturesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeaturesId"));

                    b.Property<string>("AC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<string>("CilindricalCapacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadLights")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeadtedSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("HorsePower")
                        .HasColumnType("real");

                    b.Property<string>("MaterialOfTheSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navigation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SteeringWheelHeating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SunRoof")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VentilatedSeats")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VirtualCockpit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeaturesId");

                    b.HasIndex("CarsId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Liability", b =>
                {
                    b.Property<int>("LiabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LiabilityId"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarsId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceLiability")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LiabilityId");

                    b.HasIndex("CarsId");

                    b.ToTable("Liability");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Locations", b =>
                {
                    b.Property<int>("LocationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationsId"));

                    b.Property<int?>("CarsAvailable")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationsId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Users", b =>
                {
                    b.Property<int>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsersId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailedAttemptCount")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalAnswer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telephone")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Availability", b =>
                {
                    b.HasOne("ProjectRunAway.Models.Cars", "Cars")
                        .WithMany("Availability")
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectRunAway.Models.Locations", "Locations")
                        .WithMany("Availability")
                        .HasForeignKey("LocationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");

                    b.Navigation("Locations");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Cars", b =>
                {
                    b.HasOne("ProjectRunAway.Models.Users", "Users")
                        .WithMany("Cars")
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Features", b =>
                {
                    b.HasOne("ProjectRunAway.Models.Cars", "Cars")
                        .WithMany("Features")
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Liability", b =>
                {
                    b.HasOne("ProjectRunAway.Models.Cars", "Cars")
                        .WithMany("Liability")
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cars");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Cars", b =>
                {
                    b.Navigation("Availability");

                    b.Navigation("Features");

                    b.Navigation("Liability");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Locations", b =>
                {
                    b.Navigation("Availability");
                });

            modelBuilder.Entity("ProjectRunAway.Models.Users", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
