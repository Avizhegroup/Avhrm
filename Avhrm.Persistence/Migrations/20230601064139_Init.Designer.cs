﻿// <auto-generated />
using System;
using Avhrm.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avhrm.Persistence.Migrations
{
    [DbContext(typeof(AvhrmDbContext))]
    [Migration("20230601064139_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Avhrm.Core.Entities.VacationRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("FromDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastUpdateUser")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ToDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("Verifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("VerifyDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VacationRequest");
                });
#pragma warning restore 612, 618
        }
    }
}
