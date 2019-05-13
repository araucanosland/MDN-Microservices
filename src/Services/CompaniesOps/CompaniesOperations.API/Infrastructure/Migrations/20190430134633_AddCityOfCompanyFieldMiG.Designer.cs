﻿// <auto-generated />
using System;
using CompaniesOperations.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CompaniesOperations.API.Infrastructure.Migrations
{
    [DbContext(typeof(CompaniesOperationsDbContext))]
    [Migration("20190430134633_AddCityOfCompanyFieldMiG")]
    partial class AddCityOfCompanyFieldMiG
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CompaniesOperations.API.Model.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("CompanyDv");

                    b.Property<string>("CompanyName");

                    b.Property<int>("CompanyRut");

                    b.Property<string>("Email");

                    b.Property<int>("EmployeesCount");

                    b.Property<int>("LastViewPeriod");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Segment");

                    b.Property<int>("UnlistedMonthsCount");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignedOfficce");

                    b.Property<string>("AssignedTo");

                    b.Property<string>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("LeadTypeId");

                    b.Property<int>("Period");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LeadTypeId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.LeadType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("LeadTypes");
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.Management", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int>("CreatedIn");

                    b.Property<int>("LeadId");

                    b.Property<DateTime?>("NextCommitment");

                    b.Property<string>("Stats");

                    b.HasKey("Id");

                    b.HasIndex("LeadId");

                    b.ToTable("Managements");
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.ManagementStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LeadTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Options");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("LeadTypeId");

                    b.ToTable("ManagementStats");
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.Lead", b =>
                {
                    b.HasOne("CompaniesOperations.API.Model.Company", "Company")
                        .WithMany("Leads")
                        .HasForeignKey("CompanyId");

                    b.HasOne("CompaniesOperations.API.Model.LeadType", "LeadType")
                        .WithMany("Leads")
                        .HasForeignKey("LeadTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.Management", b =>
                {
                    b.HasOne("CompaniesOperations.API.Model.Lead", "Lead")
                        .WithMany("Managements")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CompaniesOperations.API.Model.ManagementStats", b =>
                {
                    b.HasOne("CompaniesOperations.API.Model.LeadType", "LeadType")
                        .WithMany("ManagementStats")
                        .HasForeignKey("LeadTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}