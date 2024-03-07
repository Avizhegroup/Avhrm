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
    [Migration("20240306232220_Fix_WorkingDate_Type")]
    partial class Fix_WorkingDate_Type
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Avhrm.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.VacationRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("FromDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ToDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Verifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("VerifyDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("VacationRequests");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.WorkType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkTypes");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.WorkingReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdateUser")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersianDate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<decimal>("SpentHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("WorkDayDateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkDayType")
                        .HasColumnType("int");

                    b.Property<int>("WorkTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("WorkTypeId");

                    b.ToTable("WorkingReports");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.WorkingReport", b =>
                {
                    b.HasOne("Avhrm.Core.Entities.Project", "Project")
                        .WithMany("WorkingReports")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Avhrm.Core.Entities.WorkType", "WorkType")
                        .WithMany("WorkingReports")
                        .HasForeignKey("WorkTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("WorkType");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.Project", b =>
                {
                    b.Navigation("WorkingReports");
                });

            modelBuilder.Entity("Avhrm.Core.Entities.WorkType", b =>
                {
                    b.Navigation("WorkingReports");
                });
#pragma warning restore 612, 618
        }
    }
}
