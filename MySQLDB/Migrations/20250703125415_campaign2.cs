using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class campaign2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CampaignEmailHistory",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FolderName",
                table: "CampaignEmailHistory",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FullPath",
                table: "CampaignEmailHistory",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CampaignEmailHistory");

            migrationBuilder.DropColumn(
                name: "FolderName",
                table: "CampaignEmailHistory");

            migrationBuilder.DropColumn(
                name: "FullPath",
                table: "CampaignEmailHistory");
        }
    }
}
