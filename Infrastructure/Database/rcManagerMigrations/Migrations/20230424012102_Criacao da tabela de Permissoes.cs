using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rcManagerMigrations.Migrations
{
    public partial class CriacaodatabeladePermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(nullable: false),
                    system_id = table.Column<long>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    date_from = table.Column<DateTime>(nullable: false),
                    date_to = table.Column<DateTime>(nullable: false),
                    weekday = table.Column<bool>(nullable: false),
                    weekend = table.Column<bool>(nullable: false),
                    start_time = table.Column<TimeSpan>(nullable: false),
                    end_time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
