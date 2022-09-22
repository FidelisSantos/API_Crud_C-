﻿// <auto-generated />
using System;
using API_CRUD.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220922154323_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("API_CRUD.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("cpf")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("created")
                        .HasColumnType("TEXT");

                    b.Property<string>("email")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("update")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserModels");
                });
#pragma warning restore 612, 618
        }
    }
}