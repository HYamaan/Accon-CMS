using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcconAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class socialMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "GooglePlus",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Snapchat",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Telegram",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "TikTok",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "SocialMedias");

            migrationBuilder.RenameColumn(
                name: "Youtube",
                table: "SocialMedias",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "WhatsApp",
                table: "SocialMedias",
                newName: "Content");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "SocialMedias",
                newName: "Youtube");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "SocialMedias",
                newName: "WhatsApp");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GooglePlus",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Snapchat",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telegram",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TikTok",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "SocialMedias",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
