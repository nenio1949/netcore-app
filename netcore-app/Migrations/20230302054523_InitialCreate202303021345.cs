using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netcore_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate202303021345 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "Deleted",
                table: "User",
                type: "bit",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否删除");

            migrationBuilder.AlterColumn<ulong>(
                name: "Deleted",
                table: "Role",
                type: "bit",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否删除");

            migrationBuilder.AlterColumn<ulong>(
                name: "Deleted",
                table: "Department",
                type: "bit",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldComment: "是否删除");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "User",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldComment: "是否删除");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Role",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldComment: "是否删除");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "Department",
                type: "tinyint(1)",
                nullable: false,
                comment: "是否删除",
                oldClrType: typeof(ulong),
                oldType: "bit",
                oldComment: "是否删除");
        }
    }
}
