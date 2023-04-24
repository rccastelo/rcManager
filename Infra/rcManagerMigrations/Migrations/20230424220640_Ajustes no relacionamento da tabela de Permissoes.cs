using Microsoft.EntityFrameworkCore.Migrations;

namespace rcManagerMigrations.Migrations
{
    public partial class AjustesnorelacionamentodatabeladePermissoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Permissions_system_id",
                table: "Permissions",
                column: "system_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_user_id",
                table: "Permissions",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Systems_system_id",
                table: "Permissions",
                column: "system_id",
                principalTable: "Systems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_user_id",
                table: "Permissions",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Systems_system_id",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_user_id",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_system_id",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_user_id",
                table: "Permissions");
        }
    }
}
