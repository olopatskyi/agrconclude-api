using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class testUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9386dde5-7bf7-447b-ac60-ade78b8900f8", 0, "f95315cd-af46-43d2-ba56-33056825d20e", "dfb444ca10194990ac06cf1f3845df97", "28003e4b-f178-4640-844e-3fc0c330285f@example.com", true, "71b9b5ce-0391-459c-bf65-71f8cbb5e999", "c5ca3826-23da-4e8e-b028-342b3b66aa54", false, null, "B934FB89-C98D-4BEA-8A28-B64CEADA4A1F@EXAMPLE.COM", "4B548AA5-75DA-40B1-AF35-907B2589273E", "75f7f5ab31b54866b441802ec862b76b", "555-d8c5ffa", true, "5a05c317-de6a-482a-8661-e1c409587764", false, "e3d1fec4-57f3-416a-b9f1-5585ccb54b4f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9386dde5-7bf7-447b-ac60-ade78b8900f8");
        }
    }
}
