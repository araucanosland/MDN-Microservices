using Microsoft.EntityFrameworkCore.Migrations;

namespace CompaniesOperations.API.Infrastructure.Migrations
{
    public partial class AddCityOfCompanyFieldMiG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Company",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Company");
        }
    }
}
