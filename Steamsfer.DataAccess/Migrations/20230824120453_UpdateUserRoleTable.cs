using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steamsfer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRoleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "Guest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "Role",
                value: "Admin");
        }
    }
}
