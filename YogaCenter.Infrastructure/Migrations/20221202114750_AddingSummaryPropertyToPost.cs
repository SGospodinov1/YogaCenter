using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    public partial class AddingSummaryPropertyToPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Posts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Posts");

            
        }
    }
}
