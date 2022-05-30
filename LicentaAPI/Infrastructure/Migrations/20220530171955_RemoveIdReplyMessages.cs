using Microsoft.EntityFrameworkCore.Migrations;

namespace LicentaAPI.Infrastructure.Migrations
{
    public partial class RemoveIdReplyMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdReply",
                table: "Messages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdReply",
                table: "Messages",
                type: "TEXT",
                nullable: true);
        }
    }
}
