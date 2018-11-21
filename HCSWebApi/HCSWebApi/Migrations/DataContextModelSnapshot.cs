﻿// <auto-generated />
using System;
using HCSWebApi.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HCSWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("firstnetcore.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("firstnetcore.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("firstnetcore.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BrandId");

                    b.Property<Guid>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<DateTime>("MaxPeriod");

                    b.Property<string>("Model");

                    b.Property<int>("Permission");

                    b.Property<string>("SerialNumber");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("firstnetcore.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DeviceId");

                    b.Property<Guid?>("LastResponseId");

                    b.Property<string>("Message");

                    b.Property<DateTime>("RentEndDate");

                    b.Property<DateTime>("RentStartDate");

                    b.Property<DateTime>("RequestDate");

                    b.Property<int>("Status");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("LastResponseId");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("firstnetcore.Models.Response", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Message");

                    b.Property<int>("NewStatus");

                    b.Property<Guid?>("RequestId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Responses");
                });

            modelBuilder.Entity("firstnetcore.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<byte[]>("AvatarImage");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<int>("Permission");

                    b.Property<string>("SerialNumber");

                    b.Property<string>("TelNumber");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("firstnetcore.Models.Device", b =>
                {
                    b.HasOne("firstnetcore.Models.Brand", "Brand")
                        .WithMany("Devices")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("firstnetcore.Models.Category", "Category")
                        .WithMany("Devices")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("firstnetcore.Models.Request", b =>
                {
                    b.HasOne("firstnetcore.Models.User", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("firstnetcore.Models.Response", "LastResponse")
                        .WithMany()
                        .HasForeignKey("LastResponseId");

                    b.HasOne("firstnetcore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("firstnetcore.Models.Response", b =>
                {
                    b.HasOne("firstnetcore.Models.Request")
                        .WithMany("Responses")
                        .HasForeignKey("RequestId");

                    b.HasOne("firstnetcore.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
