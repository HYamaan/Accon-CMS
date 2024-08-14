using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcconAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Pages_GalleryPageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_GalleryPageId",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "GalleryPageId",
                table: "Pages");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "284fd3b1-9401-4841-96c8-8ad8e8cb254d", 0, "2d90a92a-1f9e-4367-bef4-ac71b3279b5b", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBLjouNqaeiVWbN0TbXUS3+ChW3d7aQIk/BQEkWBxlrdRRngp14b0BIH0Rp65qD6mA==", null, true, null, false, "admin@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "284fd3b1-9401-4841-96c8-8ad8e8cb254d");

            migrationBuilder.AddColumn<Guid>(
                name: "GalleryPageId",
                table: "Pages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GalleryPageId",
                table: "Pages",
                column: "GalleryPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Pages_GalleryPageId",
                table: "Pages",
                column: "GalleryPageId",
                principalTable: "Pages",
                principalColumn: "Id");
        }
    }
}
