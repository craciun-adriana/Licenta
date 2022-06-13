using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LicentaAPI.Infrastructure.Migrations
{
    public partial class AddMessageTimestampGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastMessageTimestamp",
                table: "Groups",
                type: "TEXT",
                nullable: false,
                defaultValue: DateTime.UtcNow);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMessageTimestamp",
                table: "Groups");
        }
    }
}