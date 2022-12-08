using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YogaCenter.Infrastructure.Migrations
{
    public partial class AddIsDeletedToTeacherEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "YogaClasses");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teachers",
                type: "bit",
                nullable: false,
                defaultValue: false);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "YogaClasses",
                type: "bit",
                nullable: false,
                defaultValue: false);

          
        }
    }
}
