﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ReportsDbContext))]
    partial class ReportsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companys");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Adress = "Av. Calchaquí 3950",
                            Cuit = "30-69730872-1",
                            Name = "Easy SRL",
                            Phone = "4229-4000"
                        },
                        new
                        {
                            CompanyId = 2,
                            Adress = "Av. Rivadavia 430",
                            Cuit = "33-70892523-9",
                            Name = "Remax",
                            Phone = "4253-4987"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdCompany = 1,
                            Name = "Recursos Humanos"
                        },
                        new
                        {
                            Id = 2,
                            IdCompany = 1,
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 3,
                            IdCompany = 1,
                            Name = "Comercial"
                        },
                        new
                        {
                            Id = 4,
                            IdCompany = 2,
                            Name = "Control de Gestión"
                        },
                        new
                        {
                            Id = 5,
                            IdCompany = 2,
                            Name = "Logística y Operaciones"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("ApprovalsFlag")
                        .HasColumnType("bit");

                    b.Property<int>("DepartamentId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("HistoryFlag")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int?>("SuperiorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentId");

                    b.HasIndex("PositionId");

                    b.HasIndex("SuperiorId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApprovalsFlag = false,
                            DepartamentId = 1,
                            FirstName = "diego",
                            HistoryFlag = false,
                            LastName = "rodriguez",
                            PositionId = 1
                        },
                        new
                        {
                            Id = 2,
                            ApprovalsFlag = false,
                            DepartamentId = 1,
                            FirstName = "jose",
                            HistoryFlag = false,
                            LastName = "martinez",
                            PositionId = 2,
                            SuperiorId = 1
                        },
                        new
                        {
                            Id = 3,
                            ApprovalsFlag = false,
                            DepartamentId = 1,
                            FirstName = "Miguel Ángel",
                            HistoryFlag = false,
                            LastName = "Merentiel",
                            PositionId = 1,
                            SuperiorId = 2
                        });
                });

            modelBuilder.Entity("Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Hierarchy")
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hierarchy = 10,
                            IdCompany = 1,
                            MaxAmount = 50000m,
                            Name = "Director"
                        },
                        new
                        {
                            Id = 2,
                            Hierarchy = 10,
                            IdCompany = 1,
                            MaxAmount = 50000m,
                            Name = "Lider"
                        },
                        new
                        {
                            Id = 3,
                            Hierarchy = 10,
                            IdCompany = 1,
                            MaxAmount = 500m,
                            Name = "Empleado"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.HasOne("Domain.Entities.Department", "Departament")
                        .WithMany("Employees")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Employee", "Superior")
                        .WithMany("Subordinates")
                        .HasForeignKey("SuperiorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Departament");

                    b.Navigation("Position");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("Domain.Entities.Position", b =>
                {
                    b.HasOne("Domain.Entities.Company", "Company")
                        .WithMany("Positions")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.Company", b =>
                {
                    b.Navigation("Departments");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Domain.Entities.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Entities.Employee", b =>
                {
                    b.Navigation("Subordinates");
                });

            modelBuilder.Entity("Domain.Entities.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
