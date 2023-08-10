﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourBookingApp.Models;

#nullable disable

namespace TourBookingApp.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TourBookingApp.Models.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"), 1L, 1);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonsCount")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.Property<int>("TravellerId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("TourBookingApp.Models.UserTourBooking", b =>
                {
                    b.Property<int>("BookingUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingUserId"), 1L, 1);

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("BookingUserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingUserGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BookingUserPhnNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookingUserId");

                    b.HasIndex("BookingId");

                    b.ToTable("UserTourBookings");
                });

            modelBuilder.Entity("TourBookingApp.Models.UserTourBooking", b =>
                {
                    b.HasOne("TourBookingApp.Models.Booking", "Booking")
                        .WithMany("UserTourBookings")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("TourBookingApp.Models.Booking", b =>
                {
                    b.Navigation("UserTourBookings");
                });
#pragma warning restore 612, 618
        }
    }
}
