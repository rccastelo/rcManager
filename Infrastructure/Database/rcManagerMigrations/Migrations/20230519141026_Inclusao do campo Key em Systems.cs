using Microsoft.EntityFrameworkCore.Migrations;

namespace rcManagerMigrations.Migrations
{
    public partial class InclusaodocampoKeyemSystems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "key",
                table: "Systems",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "key",
                table: "Systems");
        }
    }
}
