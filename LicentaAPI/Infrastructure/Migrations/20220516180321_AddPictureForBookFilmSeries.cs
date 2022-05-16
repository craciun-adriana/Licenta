using Microsoft.EntityFrameworkCore.Migrations;

namespace LicentaAPI.Infrastructure.Migrations
{
    public partial class AddPictureForBookFilmSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Series",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Films",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Books",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Books");
        }
    }
}
