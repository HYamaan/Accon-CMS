using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcconAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GalleryPageId",
                table: "Pages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CommentShow",
                table: "News",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "NewsPageId",
                table: "News",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "News",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GalleryPageId",
                table: "Pages",
                column: "GalleryPageId");

            migrationBuilder.CreateIndex(
                name: "IX_News_NewsPageId",
                table: "News",
                column: "NewsPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Pages_NewsPageId",
                table: "News",
                column: "NewsPageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Pages_GalleryPageId",
                table: "Pages",
                column: "GalleryPageId",
                principalTable: "Pages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Pages_NewsPageId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_GalleryPageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_GalleryPageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_News_NewsPageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "GalleryPageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CommentShow",
                table: "News");

            migrationBuilder.DropColumn(
                name: "NewsPageId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "News");
        }
    }
}
