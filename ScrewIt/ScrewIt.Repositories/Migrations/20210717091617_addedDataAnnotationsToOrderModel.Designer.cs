﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScrewIt.Repositories;

namespace ScrewIt.Repositories.Migrations
{
    [DbContext(typeof(ScrewItDbContext))]
    [Migration("20210717091617_addedDataAnnotationsToOrderModel")]
    partial class addedDataAnnotationsToOrderModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ScrewIt.Models.Dimension", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalProcessing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirstDimFirstEdge")
                        .HasColumnType("int");

                    b.Property<int>("FirstDimSecondEdge")
                        .HasColumnType("int");

                    b.Property<int>("FirstDimension")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Rotation")
                        .HasColumnType("bit");

                    b.Property<int>("SecondDimFirstEdge")
                        .HasColumnType("int");

                    b.Property<int>("SecondDimSecondEdge")
                        .HasColumnType("int");

                    b.Property<int>("SecondDimension")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Dimensions");
                });

            modelBuilder.Entity("ScrewIt.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateToBeCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ScrewIt.Models.Dimension", b =>
                {
                    b.HasOne("ScrewIt.Models.Order", "Order")
                        .WithMany("Dimensions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
