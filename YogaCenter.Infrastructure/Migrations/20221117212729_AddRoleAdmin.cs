using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    public partial class AddRoleAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a9102582-a6f9-4730-8dc6-59644bc1a460", "9ad4d36c-baac-4973-9b82-29ed851c69bb", "Admin", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6e1e8c8-e42c-4ab8-99e7-8a01a3a068fa", "AQAAAAEAACcQAAAAEAwoHIb6dlzIX+l1qTVZl+8n00k/sHfA38CAm4Jk+AScgFxIHpw6ujkv6xrfLClLiA==", "120db779-db56-4c7c-8fd3-69cb38038160" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "572a8f3a-585c-4cdf-be0d-dd32b7a581d8", "AQAAAAEAACcQAAAAECacrwXiTs2O+b3j/yCV49MInVuhuNB08q9L7fzEtQxwfx0CAr4Bl264jPmSrJVvRA==", "a896fdd9-60d2-4efe-b698-49e87043e8f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f01035fc-9c12-4f86-a01a-5fe5ce4d5dd2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ba03e77-1dd7-48ff-9f3c-6e324120e300", "AQAAAAEAACcQAAAAEN1DKVAdmmvgLk0b7RGdiv3tOsPjnsutwxTHTQw4S7cTMyQGHq5ei/X1SGXcU96KQA==", "ae7dfd4c-5b6f-47d1-91b5-6ff852e1c147" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9102582-a6f9-4730-8dc6-59644bc1a460");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "737b8ae9-fff1-41e0-bb81-7ed16a44f1c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d22c1e10-8d90-4c5b-a5f7-e0083396e338", "AQAAAAEAACcQAAAAEJ4WQZerZFO56RRr2M84TOyCHxXcy3eK3IaX4egNI5jtmBCYf3LtEFY26JgwHzQkDw==", "7ebb1d4e-814e-49b3-85f6-37ab8011055f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8175b008 - d14c - 4214 - 9e7e - 8dc0bdfa6b0c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "991a2b8b-7002-4f5d-8fb0-5c8d4ed63f39", "AQAAAAEAACcQAAAAEMxggTnhwTLTUWyTepRZLwEEFCRme0t+XUp9yduJztNnO4AwD0BnVHqQ0JTuqVAT0Q==", "16cfa43c-6970-49f1-a67f-a2d46ecd26e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f01035fc-9c12-4f86-a01a-5fe5ce4d5dd2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fdd99c55-0a2a-44f3-9dee-adb9100f06d9", "AQAAAAEAACcQAAAAED2Pp0kdMpcvZ8gJXVnwB40QZKa06jl9gyBq2/1czJqWcleKBGY/VmnoZlfd4b6QMw==", "acd4e622-6cd9-47f7-a8f9-c6571734312f" });
        }
    }
}
