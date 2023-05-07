using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace agrconclude.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d87d2f7e-38f2-468b-bcc1-c71175faa82c");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Contracts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "53d2139e-9fce-4612-a65c-c78b06d28faa", 0, "1607e5bc-a1f8-437f-8843-58b9d60dac49", "cf13817c9d2d4f92b3dc25942b46801c", "4a45a10d-6d81-4e75-8bdd-092a910b94f7@example.com", true, "39a0467d-cdc0-4a35-8542-1e8071a9c4f6", 0, "5cf82712-1e9c-4357-b8c5-d4aceb055ecc", false, null, "C50F39EE-B686-416D-BAFE-FAE045B1D107@EXAMPLE.COM", "AF3B5F95-7000-474F-8345-EE813267D54C", "4d460b68e4554d2ab3913e4256362c8e", "555-c514822", true, "e178b746-9cc7-4805-aa84-e181b3b762d6", false, "fd37c9d0-ce57-4309-ba05-2327439e463a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53d2139e-9fce-4612-a65c-c78b06d28faa");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Contracts");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d87d2f7e-38f2-468b-bcc1-c71175faa82c", 0, "420ea201-c8bf-4a37-bac9-eca8f6e7fabc", "f47b6b868c3146a18b037c98d846b1eb", "33ab4c63-a4df-4f09-86b8-15056d5772c0@example.com", true, "7e763676-1dde-4fc9-9aab-02e9e70d2fd1", 0, "131b63f7-3869-4747-8d59-ac956d4a7d3e", false, null, "D7D259C1-1579-4CE2-997A-10D65E52C010@EXAMPLE.COM", "C6B45839-73BC-4161-AFFB-E2E687679276", "a8132a6bbee2449381b5da8971e276d4", "555-06d105b", true, "8f43cde3-f03a-423b-97c4-72705ee34a9a", false, "f0bb3a29-dac5-45a3-b8d6-5f32f1a7503c" });
        }
    }
}
