using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsFactory.Data.Migrations
{
    public partial class AddConnectionString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "AspNetUsers");
        }
    }
}
