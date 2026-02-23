using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transparity.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var utcNow = DateTime.UtcNow;

            migrationBuilder.InsertData(
                table: "Roles",
                columns: ["Id", "Name", "Description", "CreatedAt", "DeletedAt"],
                values: [1L, "Anonymous", "Anonymous Role", utcNow, null]
            );

            migrationBuilder.InsertData(
                table: "UserInfos",
                columns: ["Id", "FirstName", "LastName", "Email", "Mobile", "Address1", "Address2"],
                values: [1L, "Anonymous", "Anonymous", null, null, "Anonymous", null]
            );

            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Id", "UserInfoId", "RoleId", "IsVerified", "CreatedAt", "DeletedAt"],
                values: [1L, 1L, 1L, true, utcNow, null]
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(table: "Users", keyColumn: "Id", keyValue: 1L);
            migrationBuilder.DeleteData(table: "UserInfos", keyColumn: "Id", keyValue: 1L);
            migrationBuilder.DeleteData(table: "Roles", keyColumn: "Id", keyValue: 1L);
        }
    }
}
