using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Db.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBookUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserName1",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserName1",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserName1",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserName",
                table: "Books",
                column: "UserName");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserName",
                table: "Books",
                column: "UserName",
                principalTable: "Users",
                principalColumn: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserName",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserName",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName1",
                table: "Books",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserName1",
                table: "Books",
                column: "UserName1");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserName1",
                table: "Books",
                column: "UserName1",
                principalTable: "Users",
                principalColumn: "UserName");
        }
    }
}
