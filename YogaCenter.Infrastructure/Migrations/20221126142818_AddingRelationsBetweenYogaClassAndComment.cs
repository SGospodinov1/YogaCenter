using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    public partial class AddingRelationsBetweenYogaClassAndComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

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

            migrationBuilder.AddColumn<int>(
                name: "YogaClassId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_YogaClassId",
                table: "Comments",
                column: "YogaClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_YogaClasses_YogaClassId",
                table: "Comments",
                column: "YogaClassId",
                principalTable: "YogaClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_YogaClasses_YogaClassId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_YogaClassId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "YogaClassId",
                table: "Comments");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2", 0, "8010a12b-24f8-4827-925b-1cf0f2769b74", "teacher@mail.com", false, "Kristiana", "Bakalova", false, null, "teacher@mail.com", "teacher@mail.com", "AQAAAAEAACcQAAAAEK30x6fFJswMbI7q1UICnyiFeUARYfF2OLED+4Mr/RWTbKsn67dNYzYdE67utSWpww==", null, false, "d1bb6e2b-ab82-4e56-ae5f-bd3dbb29609d", false, "teacher@mail.com" },
                    { "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c", 0, "e5850a5e-4b06-4e7b-9d18-d4f88971036a", "user@mail.com", false, "Maria", "Petrova", false, null, "user@mail.com", "user@mail.com", "AQAAAAEAACcQAAAAEDlUkYkalQQ1TIqm3+wtZHBV4rvQes1NRR8BZPkXqtEpg5V6gGyxJgpJV8L6YZm3LQ==", null, false, "d610d253-57ab-460d-8771-8200f43f31c3", false, "user@mail.com" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserId",
                table: "Comments",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
