using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedExpiresAtProp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9386dde5-7bf7-447b-ac60-ade78b8900f8");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbb3be60-fdb5-4cde-9b67-d61a09f0b63d", 0, "462c97aa-cd5f-4a76-8acf-070f86c42c82", "bc782f693a5a4689b7bbba395800dda5", "9cb4d9f8-e7e4-49ae-9e89-a56b2af74fb5@example.com", true, "c550e238-de7a-4e8b-9622-486b435a1e3a", "19aa91a2-32cb-4844-8d73-01c72b815603", false, null, "72D94B4E-78A0-4312-9C0B-68924E8B9A27@EXAMPLE.COM", "279408C1-0C89-4B8B-A9EA-58F869C7A1CD", "394a52df131c44d283a2505e2a6f5120", "555-5d47232", true, "4a8ea32e-30d2-477e-b2f4-137a1b63a7a3", false, "eae08d83-c65f-46a8-b48a-a2feb4761e91" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbb3be60-fdb5-4cde-9b67-d61a09f0b63d");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9386dde5-7bf7-447b-ac60-ade78b8900f8", 0, "f95315cd-af46-43d2-ba56-33056825d20e", "dfb444ca10194990ac06cf1f3845df97", "28003e4b-f178-4640-844e-3fc0c330285f@example.com", true, "71b9b5ce-0391-459c-bf65-71f8cbb5e999", "c5ca3826-23da-4e8e-b028-342b3b66aa54", false, null, "B934FB89-C98D-4BEA-8A28-B64CEADA4A1F@EXAMPLE.COM", "4B548AA5-75DA-40B1-AF35-907B2589273E", "75f7f5ab31b54866b441802ec862b76b", "555-d8c5ffa", true, "5a05c317-de6a-482a-8661-e1c409587764", false, "e3d1fec4-57f3-416a-b9f1-5585ccb54b4f" });
        }
    }
}
