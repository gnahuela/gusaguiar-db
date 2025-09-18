using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class campaign3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreviousUserCampaignHistoryId",
                table: "UserCampaignHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousCampaignEmailHistoryId",
                table: "CampaignEmailHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_PreviousUserCampaignHistoryId",
                table: "UserCampaignHistory",
                column: "PreviousUserCampaignHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEmailHistory_PreviousCampaignEmailHistoryId",
                table: "CampaignEmailHistory",
                column: "PreviousCampaignEmailHistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignEmailHistory_CampaignEmailHistory_PreviousCampaignEm~",
                table: "CampaignEmailHistory",
                column: "PreviousCampaignEmailHistoryId",
                principalTable: "CampaignEmailHistory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaignHistory_UserCampaignHistory_PreviousUserCampaign~",
                table: "UserCampaignHistory",
                column: "PreviousUserCampaignHistoryId",
                principalTable: "UserCampaignHistory",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignEmailHistory_CampaignEmailHistory_PreviousCampaignEm~",
                table: "CampaignEmailHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaignHistory_UserCampaignHistory_PreviousUserCampaign~",
                table: "UserCampaignHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaignHistory_PreviousUserCampaignHistoryId",
                table: "UserCampaignHistory");

            migrationBuilder.DropIndex(
                name: "IX_CampaignEmailHistory_PreviousCampaignEmailHistoryId",
                table: "CampaignEmailHistory");

            migrationBuilder.DropColumn(
                name: "PreviousUserCampaignHistoryId",
                table: "UserCampaignHistory");

            migrationBuilder.DropColumn(
                name: "PreviousCampaignEmailHistoryId",
                table: "CampaignEmailHistory");
        }
    }
}
