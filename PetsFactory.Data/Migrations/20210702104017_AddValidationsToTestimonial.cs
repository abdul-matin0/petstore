using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsFactory.Data.Migrations
{
    public partial class AddValidationsToTestimonial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentMessage",
                table: "Testimonial",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CommentMessage",
                table: "Testimonial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);
        }
    }
}
