﻿// <auto-generated />
using System;
using HR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR.Migrations
{
    [DbContext(typeof(HR_Context))]
    [Migration("20240731010323_employee-listSalaryes")]
    partial class employeelistSalaryes
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.6.24327.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HR_Models.Models.City", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("citys");
                });

            modelBuilder.Entity("HR_Models.Models.Department", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name_Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("HR_Models.Models.Employee", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Father")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Functional_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mather")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary_basis")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UniverCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UniversityDegree")
                        .HasColumnType("int");

                    b.Property<DateTime>("date_of_employment")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.HasIndex("UniverCityId");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("HR_Models.Models.EmployeeDepartment", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Is_available")
                        .HasColumnType("bit");

                    b.Property<bool>("Is_manager")
                        .HasColumnType("bit");

                    b.Property<string>("Path_File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeDepartment");
                });

            modelBuilder.Entity("HR_Models.Models.Leave_Balances", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Carryover_Balance")
                        .HasColumnType("int");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Remaining_Balance")
                        .HasColumnType("int");

                    b.Property<int>("Total_Balance")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("balances");
                });

            modelBuilder.Entity("HR_Models.Models.Penalties", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_Penalties")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path_file")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price_Penalties")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Reason_Penalties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("penalties");
                });

            modelBuilder.Entity("HR_Models.Models.Rewards", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_Rewards")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Path_file")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price_Rewards")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Reason_Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("rewards");
                });

            modelBuilder.Entity("HR_Models.Models.Salary", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_Salarys")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Issue_Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Receipt_Date")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("salaries");
                });

            modelBuilder.Entity("HR_Models.Models.UniverCity", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("univers");
                });

            modelBuilder.Entity("HR_Models.Models.Vacation", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Acceptance")
                        .HasColumnType("bit");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End_Vacation")
                        .HasColumnType("datetime2");

                    b.Property<int>("Leave")
                        .HasColumnType("int");

                    b.Property<string>("NoteBad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Start_Vacation")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("vacations");
                });

            modelBuilder.Entity("HR_Models.Models.Employee", b =>
                {
                    b.HasOne("HR_Models.Models.City", "City")
                        .WithMany("employees")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Models.Models.UniverCity", "UniverCity")
                        .WithMany("employees")
                        .HasForeignKey("UniverCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("UniverCity");
                });

            modelBuilder.Entity("HR_Models.Models.EmployeeDepartment", b =>
                {
                    b.HasOne("HR_Models.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_Models.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HR_Models.Models.Leave_Balances", b =>
                {
                    b.HasOne("HR_Models.Models.Employee", "Employee")
                        .WithMany("leave_Balances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Models.Models.Penalties", b =>
                {
                    b.HasOne("HR_Models.Models.Employee", "Employee")
                        .WithMany("penalties")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Models.Models.Rewards", b =>
                {
                    b.HasOne("HR_Models.Models.Employee", "Employee")
                        .WithMany("rewards")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Models.Models.Salary", b =>
                {
                    b.HasOne("HR_Models.Models.Employee", "Employee")
                        .WithMany("salaries")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Models.Models.Vacation", b =>
                {
                    b.HasOne("HR_Models.Models.Employee", "Employee")
                        .WithMany("vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_Models.Models.City", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("HR_Models.Models.Employee", b =>
                {
                    b.Navigation("leave_Balances");

                    b.Navigation("penalties");

                    b.Navigation("rewards");

                    b.Navigation("salaries");

                    b.Navigation("vacations");
                });

            modelBuilder.Entity("HR_Models.Models.UniverCity", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
