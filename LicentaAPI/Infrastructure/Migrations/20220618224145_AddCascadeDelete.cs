using Microsoft.EntityFrameworkCore.Migrations;

namespace LicentaAPI.Infrastructure.Migrations
{
    public partial class AddCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                "FK_ReviewBooks_IdUser_AspNetUsers", "ReviewBooks", "IdUser", "AspNetUsers", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_ReviewFilms_IdUser_AspNetUsers", "ReviewFilms", "IdUser", "AspNetUsers", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_ReviewSeries_IdUser_AspNetUsers", "ReviewSeries", "IdUser", "AspNetUsers", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_ReviewBooks_IdBook_Books", "ReviewBooks", "IdBook", "Books", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_ReviewFilms_IdFilm_Films", "ReviewFilms", "IdFilm", "Films", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_ReviewSeries_IdSeries_Series", "ReviewSeries", "IdSeries", "Series", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_GroupMembers_IdUser_AspNetUsers", "GroupMembers", "IdUser", "AspNetUsers", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_Messages_IdSender_AspNetUsers", "Messages", "IdSender", "AspNetUsers", onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                "FK_Messages_IdReceiver_AspNetUsers", "Messages", "IdReceiver", "AspNetUsers", onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_ReviewBooks_IdUser_AspNetUsers", "ReviewBooks");
            migrationBuilder.DropForeignKey("FK_ReviewFilms_IdUser_AspNetUsers", "ReviewFilms");
            migrationBuilder.DropForeignKey("FK_ReviewSeries_IdUser_AspNetUsers", "ReviewSeries");
            migrationBuilder.DropForeignKey("FK_ReviewBooks_IdBook_Books", "ReviewBooks");
            migrationBuilder.DropForeignKey("FK_ReviewFilms_IdFilm_Films", "ReviewFilms");
            migrationBuilder.DropForeignKey("FK_ReviewSeries_IdSeries_Series", "ReviewSeries");
            migrationBuilder.DropForeignKey("FK_GroupMembers_IdUser_AspNetUsers", "GroupMembers");
            migrationBuilder.DropForeignKey("FK_Messages_IdSender_AspNetUsers", "Messages");
            migrationBuilder.DropForeignKey("FK_Messages_IdReceiver_AspNetUsers", "Messages");
        }
    }
}