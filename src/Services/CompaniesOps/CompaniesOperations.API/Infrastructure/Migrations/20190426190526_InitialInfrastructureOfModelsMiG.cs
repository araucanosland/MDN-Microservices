using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesOperations.API.Infrastructure.Migrations
{
    public partial class InitialInfrastructureOfModelsMiG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyRut = table.Column<int>(nullable: false),
                    CompanyDv = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Segment = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EmployeesCount = table.Column<int>(nullable: false),
                    UnlistedMonthsCount = table.Column<int>(nullable: false),
                    LastViewPeriod = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Period = table.Column<int>(nullable: false),
                    LeadTypeId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    AssignedOfficce = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Leads_LeadTypes_LeadTypeId",
                        column: x => x.LeadTypeId,
                        principalTable: "LeadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagementStats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    LeadTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Options = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagementStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagementStats_LeadTypes_LeadTypeId",
                        column: x => x.LeadTypeId,
                        principalTable: "LeadTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Stats = table.Column<string>(nullable: true),
                    NextCommitment = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedIn = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managements_Leads_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CompanyId",
                table: "Leads",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadTypeId",
                table: "Leads",
                column: "LeadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Managements_LeadId",
                table: "Managements",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagementStats_LeadTypeId",
                table: "ManagementStats",
                column: "LeadTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managements");

            migrationBuilder.DropTable(
                name: "ManagementStats");

            migrationBuilder.DropTable(
                name: "Leads");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "LeadTypes");
        }
    }
}
