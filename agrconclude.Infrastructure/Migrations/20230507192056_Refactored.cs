using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Refactored : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53d2139e-9fce-4612-a65c-c78b06d28faa");

            migrationBuilder.DropColumn(
                name: "IsSigned",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ExpiresAt",
                table: "Contracts",
                newName: "ExpireAt");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7b308520-9636-408d-b4d2-61b1ac29f8c5", 0, "737c156e-793b-4215-8a28-90fa2734f980", "ac467db7b1f14f1d90341140e05898fe", "26269be0-721e-4978-8259-160fb56b0e6d@example.com", true, "b57fee69-dd01-4a1a-b219-beb429d1c35f", 0, "8b0ad1b8-8a71-4154-a2c4-9158bc766e7a", false, null, "0862D554-840D-4B05-9784-3C32A499C5CD@EXAMPLE.COM", "50E54ED7-C5A3-42E1-97F2-B47619054A22", "b8253f5a2a904fd08f72b311d30237d4", "555-d0f7c33", true, "596b277e-acc6-42a2-a5df-f8d26a52e32f", false, "49f36dca-795d-42d0-8f18-92bc9548db56" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b308520-9636-408d-b4d2-61b1ac29f8c5");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "ExpireAt",
                table: "Contracts",
                newName: "ExpiresAt");

            migrationBuilder.AddColumn<bool>(
                name: "IsSigned",
                table: "Contracts",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "53d2139e-9fce-4612-a65c-c78b06d28faa", 0, "1607e5bc-a1f8-437f-8843-58b9d60dac49", "cf13817c9d2d4f92b3dc25942b46801c", "4a45a10d-6d81-4e75-8bdd-092a910b94f7@example.com", true, "39a0467d-cdc0-4a35-8542-1e8071a9c4f6", 0, "5cf82712-1e9c-4357-b8c5-d4aceb055ecc", false, null, "C50F39EE-B686-416D-BAFE-FAE045B1D107@EXAMPLE.COM", "AF3B5F95-7000-474F-8345-EE813267D54C", "4d460b68e4554d2ab3913e4256362c8e", "555-c514822", true, "e178b746-9cc7-4805-aa84-e181b3b762d6", false, "fd37c9d0-ce57-4309-ba05-2327439e463a" });
        }
    }
}
