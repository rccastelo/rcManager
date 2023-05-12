using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rcManagerMigrations.Migrations
{
    public partial class CriacaodatabeladeLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Systems_system_id",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_user_id",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "pk_id_user");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Systems",
                newName: "pk_id_system");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Permissions",
                newName: "fk_user_id");

            migrationBuilder.RenameColumn(
                name: "system_id",
                table: "Permissions",
                newName: "fk_system_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Permissions",
                newName: "pk_id_permission");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_user_id",
                table: "Permissions",
                newName: "IX_Permissions_fk_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_system_id",
                table: "Permissions",
                newName: "IX_Permissions_fk_system_id");

            migrationBuilder.AddColumn<DateTime>(
                name: "createdAt",
                table: "Systems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updatedAt",
                table: "Systems",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    pk_id_login = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(maxLength: 200, nullable: false),
                    secret = table.Column<string>(maxLength: 200, nullable: true),
                    fk_user_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.pk_id_login);
                    table.ForeignKey(
                        name: "FK_Login_Users_fk_user_id",
                        column: x => x.fk_user_id,
                        principalTable: "Users",
                        principalColumn: "pk_id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Login_fk_user_id",
                table: "Login",
                column: "fk_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Systems_fk_system_id",
                table: "Permissions",
                column: "fk_system_id",
                principalTable: "Systems",
                principalColumn: "pk_id_system",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_Users_fk_user_id",
                table: "Permissions",
                column: "fk_user_id",
                principalTable: "Users",
                principalColumn: "pk_id_user",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Systems_fk_system_id",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_Users_fk_user_id",
                table: "Permissions");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropColumn(
                name: "createdAt",
                table: "Systems");

            migrationBuilder.DropColumn(
                name: "updatedAt",
                table: "Systems");

            migrationBuilder.RenameColumn(
                name: "pk_id_user",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "pk_id_system",
                table: "Systems",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "fk_user_id",
                table: "Permissions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "fk_system_id",
                table: "Permissions",
                newName: "system_id");

            migrationBuilder.RenameColumn(
                name: "pk_id_permission",
                table: "Permissions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_fk_user_id",
                table: "Permissions",
                newName: "IX_Permissions_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Permissions_fk_system_id",
                table: "Permissions",
                newName: "IX_Permissions_system_id");

            migrationBuilder.AddColumn<string>(
                name: "login",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

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
    }
}
