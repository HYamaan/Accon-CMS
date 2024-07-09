using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcconAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class nullcheckaboutpage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_ImageFiles_PhotoId",
                table: "Pages");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_ImageFiles_PhotoId",
                table: "Pages",
                column: "PhotoId",
                principalTable: "ImageFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_ImageFiles_PhotoId",
                table: "Pages");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_ImageFiles_PhotoId",
                table: "Pages",
                column: "PhotoId",
                principalTable: "ImageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
