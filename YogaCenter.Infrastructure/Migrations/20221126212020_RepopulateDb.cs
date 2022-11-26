using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    public partial class RepopulateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2", 0, "561638c2-d071-4dba-bfc5-38a1a6346f9f", "teacher@mail.com", false, "Kristiana", "Bakalova", false, null, "teacher@mail.com", "teacher@mail.com", "AQAAAAEAACcQAAAAEE1dWsidlIYcK9/GgFGmsN33hXDDEDAayWSXRR0roSO15KUiKByA2WUFuADCRVAipw==", null, false, "cfcb9adc-4824-4677-a3b2-562c61c0a715", false, "teacher@mail.com" },
                    { "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c", 0, "4052e406-a3b7-4738-ac58-51356fa299b3", "user@mail.com", false, "Maria", "Petrova", false, null, "user@mail.com", "user@mail.com", "AQAAAAEAACcQAAAAEKKwCnE4fCgoEYgcQyesrtqsSNqu2ZlvIp600hOZFAJ49L1h5xMcWAb2+WqYvFbOtQ==", null, false, "de7e3713-3846-4a7e-9069-9f0407855409", false, "user@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hatha Yoga" },
                    { 2, "Ashtanga Yoga" },
                    { 3, "Iyengar Yoga" },
                    { 4, "Viniasa Yoga" },
                    { 5, "In Yoga" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "AppUserId", "Description" },
                values: new object[] { 1, "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2", "I`m a yoga teacher." });

            migrationBuilder.InsertData(
                table: "YogaClasses",
                columns: new[] { "Id", "CategoryId", "EndTime", "IsEdited", "Name", "Price", "StartTime", "TeacherId" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 11, 19, 30, 0, 0, DateTimeKind.Unspecified), false, "Balance and clear your mind", 15m, new DateTime(2022, 11, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "YogaClasses",
                columns: new[] { "Id", "CategoryId", "EndTime", "IsEdited", "Name", "Price", "StartTime", "TeacherId" },
                values: new object[] { 2, 4, new DateTime(2022, 11, 11, 21, 30, 0, 0, DateTimeKind.Unspecified), false, "Dinamic Viniasa with Krisi", 20m, new DateTime(2022, 11, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c");

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YogaClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2");
        }
    }
}
