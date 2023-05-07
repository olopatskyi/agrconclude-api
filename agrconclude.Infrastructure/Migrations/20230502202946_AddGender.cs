using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dbb3be60-fdb5-4cde-9b67-d61a09f0b63d");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d87d2f7e-38f2-468b-bcc1-c71175faa82c", 0, "420ea201-c8bf-4a37-bac9-eca8f6e7fabc", "f47b6b868c3146a18b037c98d846b1eb", "33ab4c63-a4df-4f09-86b8-15056d5772c0@example.com", true, "7e763676-1dde-4fc9-9aab-02e9e70d2fd1", 0, "131b63f7-3869-4747-8d59-ac956d4a7d3e", false, null, "D7D259C1-1579-4CE2-997A-10D65E52C010@EXAMPLE.COM", "C6B45839-73BC-4161-AFFB-E2E687679276", "a8132a6bbee2449381b5da8971e276d4", "555-06d105b", true, "8f43cde3-f03a-423b-97c4-72705ee34a9a", false, "f0bb3a29-dac5-45a3-b8d6-5f32f1a7503c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d87d2f7e-38f2-468b-bcc1-c71175faa82c");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dbb3be60-fdb5-4cde-9b67-d61a09f0b63d", 0, "462c97aa-cd5f-4a76-8acf-070f86c42c82", "bc782f693a5a4689b7bbba395800dda5", "9cb4d9f8-e7e4-49ae-9e89-a56b2af74fb5@example.com", true, "c550e238-de7a-4e8b-9622-486b435a1e3a", "19aa91a2-32cb-4844-8d73-01c72b815603", false, null, "72D94B4E-78A0-4312-9C0B-68924E8B9A27@EXAMPLE.COM", "279408C1-0C89-4B8B-A9EA-58F869C7A1CD", "394a52df131c44d283a2505e2a6f5120", "555-5d47232", true, "4a8ea32e-30d2-477e-b2f4-137a1b63a7a3", false, "eae08d83-c65f-46a8-b48a-a2feb4761e91" });
        }
    }
}
