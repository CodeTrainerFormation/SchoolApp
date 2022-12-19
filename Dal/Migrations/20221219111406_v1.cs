using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HiringDate",
                table: "Teacher",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiringDate",
                table: "Teacher");
        }
    }
}
