using Microsoft.EntityFrameworkCore.Migrations;

namespace LicentaAPI.Infrastructure.Migrations
{
    public partial class AddRankToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "AspNetUsers");
        }
    }
}
