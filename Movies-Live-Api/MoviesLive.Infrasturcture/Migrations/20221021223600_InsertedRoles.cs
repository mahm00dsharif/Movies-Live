using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesLive.Infrasturcture.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "494b56bd-203c-4f4a-8781-eb07bf7a26ea", "5d3d658e-8e82-4f09-bf77-9f43ea46b897", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a8f1c094-f1e7-4ea0-adbe-395ed6b0669a", "a102b5a1-4195-4ea0-84f6-3cef65e16ae9", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "494b56bd-203c-4f4a-8781-eb07bf7a26ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8f1c094-f1e7-4ea0-adbe-395ed6b0669a");
        }
    }
}
