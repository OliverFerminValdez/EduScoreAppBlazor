﻿// <auto-generated />
using System;
using EduScoreAppBlazor.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduScoreAppBlazor.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230504161205_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduScoreAppBlazor.Shared.Models.ScoreDetail", b =>
                {
                    b.Property<int>("Id_Detail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Detail"));

                    b.Property<int>("Id_Student")
                        .HasColumnType("int");

                    b.Property<int>("Id_Subject")
                        .HasColumnType("int");

                    b.Property<float>("Score")
                        .HasColumnType("real");

                    b.HasKey("Id_Detail");

                    b.HasIndex("Id_Student");

                    b.ToTable("ScoreDetail");
                });

            modelBuilder.Entity("EduScoreAppBlazor.Shared.Models.Student", b =>
                {
                    b.Property<int>("Id_Student")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Student"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Student");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EduScoreAppBlazor.Shared.Models.Subject", b =>
                {
                    b.Property<int>("Id_Subject")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Subject"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Subject");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id_Subject = 1,
                            Name = "Maths"
                        },
                        new
                        {
                            Id_Subject = 2,
                            Name = "English"
                        });
                });

            modelBuilder.Entity("EduScoreAppBlazor.Shared.Models.ScoreDetail", b =>
                {
                    b.HasOne("EduScoreAppBlazor.Shared.Models.Student", null)
                        .WithMany("ScoreDetail")
                        .HasForeignKey("Id_Student")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EduScoreAppBlazor.Shared.Models.Student", b =>
                {
                    b.Navigation("ScoreDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
