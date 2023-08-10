﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TourFeedBackApp.Models;

#nullable disable

namespace TourFeedBackApp.Migrations
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

            modelBuilder.Entity("TourFeedBackApp.Models.FeedBack", b =>
                {
                    b.Property<int>("FeedBackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedBackId"), 1L, 1);

                    b.Property<string>("FeedBackDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Ratings")
                        .HasColumnType("int");

                    b.Property<string>("TourImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeedBackId");

                    b.ToTable("FeedBacks");
                });
#pragma warning restore 612, 618
        }
    }
}