// <auto-generated />
using System;
using Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Day2.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20220716211937_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.Property<int>("minDegree")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dept_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Day2.Models.CrsResult", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("crs_id")
                        .HasColumnType("int");

                    b.Property<int>("degree")
                        .HasColumnType("int");

                    b.Property<int>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("crs_id");

                    b.HasIndex("trainee_id");

                    b.ToTable("CrsResults");
                });

            modelBuilder.Entity("Day2.Models.Department", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Day2.Models.Instructor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("crs_id")
                        .HasColumnType("int");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("salary")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("crs_id");

                    b.HasIndex("dept_id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.Property<int?>("grade")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("dept_id");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("course")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.CrsResult", b =>
                {
                    b.HasOne("Day2.Models.Course", "course")
                        .WithMany("crsResult")
                        .HasForeignKey("crs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2.Models.Trainee", "trainee")
                        .WithMany("crsResult")
                        .HasForeignKey("trainee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("trainee");
                });

            modelBuilder.Entity("Day2.Models.Instructor", b =>
                {
                    b.HasOne("Day2.Models.Course", "course")
                        .WithMany("instructor")
                        .HasForeignKey("crs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("instructor")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("course");

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.HasOne("Day2.Models.Department", "department")
                        .WithMany("trainee")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("department");
                });

            modelBuilder.Entity("Day2.Models.Course", b =>
                {
                    b.Navigation("crsResult");

                    b.Navigation("instructor");
                });

            modelBuilder.Entity("Day2.Models.Department", b =>
                {
                    b.Navigation("course");

                    b.Navigation("instructor");

                    b.Navigation("trainee");
                });

            modelBuilder.Entity("Day2.Models.Trainee", b =>
                {
                    b.Navigation("crsResult");
                });
#pragma warning restore 612, 618
        }
    }
}
