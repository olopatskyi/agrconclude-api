using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactored2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b308520-9636-408d-b4d2-61b1ac29f8c5");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "673b7fe0-5a4d-4d9c-9ecb-7c0a6ce7aac9", 0, "30440b33-3c2f-4ffc-b69f-2ac62ba0cc8c", "89dedbc71ba7497ca80538710808d2e1", "943ef157-4e31-4baf-b5ec-f5d0689ff94c@example.com", true, "50af4423-717f-4815-9e74-1668663ae86d", 0, "efa15b52-0385-458c-8553-bda5541048f3", false, null, "DCF31A11-3DBC-40FA-BE90-45C68F77BC2A@EXAMPLE.COM", "7E6F5234-F378-4505-8990-CD015AD15C4E", "b3e0b9ac903d402483fa10de65eff6af", "555-3d56941", true, "fbe12a57-9db0-4e2f-8b10-a7c261b04549", false, "e57d4571-96a5-4846-a1b1-01ffc16e98bb" },
                    { "a5c8be74-5e83-40a9-8b45-66c9fde89ffa", 0, "af30b25b-879f-421a-8c8a-dd299c1c1851", "fad656a66b974071b1a74030242bda39", "30606798-09db-445a-bdf7-672d6cc40def@example.com", true, "8c39cfdc-43a7-4be9-b6f7-751b89348c2e", 0, "4e64cdc5-e851-4735-95da-183df0f80e05", false, null, "5A05BCB4-8BCC-463D-ADE0-E8EB048E4D71@EXAMPLE.COM", "E4813573-3F10-4BE0-8ED3-55788AC1D1B0", "68f4ec793e2c4b26a8d58a495fd2f2fe", "555-41423a8", true, "d6dc53a7-e0fd-4e65-9f77-80c329732181", false, "077b0519-080d-4971-b360-c2ade3c727af" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "673b7fe0-5a4d-4d9c-9ecb-7c0a6ce7aac9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a5c8be74-5e83-40a9-8b45-66c9fde89ffa");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b308520-9636-408d-b4d2-61b1ac29f8c5", 0, "737c156e-793b-4215-8a28-90fa2734f980", "ac467db7b1f14f1d90341140e05898fe", "26269be0-721e-4978-8259-160fb56b0e6d@example.com", true, "b57fee69-dd01-4a1a-b219-beb429d1c35f", 0, "8b0ad1b8-8a71-4154-a2c4-9158bc766e7a", false, null, "0862D554-840D-4B05-9784-3C32A499C5CD@EXAMPLE.COM", "50E54ED7-C5A3-42E1-97F2-B47619054A22", "b8253f5a2a904fd08f72b311d30237d4", "555-d0f7c33", true, "596b277e-acc6-42a2-a5df-f8d26a52e32f", false, "49f36dca-795d-42d0-8f18-92bc9548db56" });
        }
    }
}
