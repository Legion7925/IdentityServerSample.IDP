using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TTech.IDP.Migrations
{
    /// <inheritdoc />
    public partial class addAccountActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("11255f39-603b-44bf-a035-8c5b6055c7cf"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("2c756e2f-1764-4f38-8008-5dc29cf1108d"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("619fd386-cc4d-4a78-a0e8-7e405014f1fd"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("61ba73bd-215a-46f3-9b97-3de44c6c7d53"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("877a2629-a3a9-4c7d-a572-4925cefd86aa"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c8fa9aa1-06ac-4bdd-ada9-a344ff03174b"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c9f44c68-2f7a-408d-8e9f-df2634899197"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("e166175f-7e3b-480c-80b3-27076da7de5d"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecurityCode",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SecurityCodeExpirationDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("5e5ca366-4a1f-4e5f-bbe9-7502eaaff25f"), "49deee11-1ae8-4fc8-a932-9287c75a105e", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("75814bb7-3b93-4c46-823e-d3c95452a058"), "5aba3761-8cc4-4526-b812-502948f00914", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" },
                    { new Guid("8a7080d0-72f5-47ff-9985-21b9ebe9e1e5"), "5472ae2d-8535-4f33-9d09-79b5efbfd66c", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("a58bf061-b633-4180-89ca-371f7cf276f9"), "d216f638-97ff-4053-abe1-3f4ef6e7506a", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("a7fe18d8-20bc-458f-b1d0-9ae6721a3dcc"), "835f7e9e-b7f2-4926-9c53-b408f2b9b9c4", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("b4bf8f68-3db1-4546-bbcd-061473298ae4"), "e96dbef3-b941-41a7-857b-36338cc5551f", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("c773a2c3-1804-4d6a-a539-7b94a9d2646f"), "b7133428-5b63-4652-8981-c92340dad684", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("c9867ef5-5ab2-49fb-8853-846596f21c80"), "3dadd9a8-a8d2-4723-ad8b-a0b7b9ef1569", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "7c35f831-092a-433a-8be9-e618509ab9a1", "David@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityCode", "SecurityCodeExpirationDate" },
                values: new object[] { "f90daea6-498e-4070-b7d0-37ae1c11e4ff", "Emma@gmail.com", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("5e5ca366-4a1f-4e5f-bbe9-7502eaaff25f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("75814bb7-3b93-4c46-823e-d3c95452a058"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("8a7080d0-72f5-47ff-9985-21b9ebe9e1e5"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a58bf061-b633-4180-89ca-371f7cf276f9"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("a7fe18d8-20bc-458f-b1d0-9ae6721a3dcc"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("b4bf8f68-3db1-4546-bbcd-061473298ae4"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c773a2c3-1804-4d6a-a539-7b94a9d2646f"));

            migrationBuilder.DeleteData(
                table: "UserClaims",
                keyColumn: "Id",
                keyValue: new Guid("c9867ef5-5ab2-49fb-8853-846596f21c80"));

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityCodeExpirationDate",
                table: "Users");

            migrationBuilder.InsertData(
                table: "UserClaims",
                columns: new[] { "Id", "ConcurrencyStamp", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { new Guid("11255f39-603b-44bf-a035-8c5b6055c7cf"), "102ea7cc-f2b5-4a24-932d-0bae39b28df2", "role", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "FreeUser" },
                    { new Guid("2c756e2f-1764-4f38-8008-5dc29cf1108d"), "ae87ffbd-e829-419a-b990-f29ef1ba70e2", "family_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "Flagg" },
                    { new Guid("619fd386-cc4d-4a78-a0e8-7e405014f1fd"), "f0280c7e-adc0-4856-9c21-6adfccc7d998", "country", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "nl" },
                    { new Guid("61ba73bd-215a-46f3-9b97-3de44c6c7d53"), "c7669f0f-4b96-442f-9cc2-39b999135d27", "given_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Emma" },
                    { new Guid("877a2629-a3a9-4c7d-a572-4925cefd86aa"), "d79bc495-a9a8-41b1-8b49-d682b4873682", "country", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "be" },
                    { new Guid("c8fa9aa1-06ac-4bdd-ada9-a344ff03174b"), "276f9fc1-027a-460f-9645-ada68ae505e3", "given_name", new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"), "David" },
                    { new Guid("c9f44c68-2f7a-408d-8e9f-df2634899197"), "3ec379da-856c-466e-b215-64f1b9bd9c81", "family_name", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "Flagg" },
                    { new Guid("e166175f-7e3b-480c-80b3-27076da7de5d"), "98220617-3104-4b23-8fb4-eca766375116", "role", new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"), "PayingUser" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13229d33-99e0-41b3-b18d-4f72127e3971"),
                column: "ConcurrencyStamp",
                value: "875ab8ba-4745-4715-8a99-cab57c652139");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("96053525-f4a5-47ee-855e-0ea77fa6c55a"),
                column: "ConcurrencyStamp",
                value: "da9ca723-b3c3-4175-b0f3-28c5548a92ff");
        }
    }
}
