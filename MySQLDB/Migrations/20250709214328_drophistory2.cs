using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class drophistory2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "UserCampaign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NextCampaignId",
                table: "UserCampaign",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PreviousCampaignId",
                table: "UserCampaign",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_CampaignId",
                table: "UserCampaign",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_NextCampaignId",
                table: "UserCampaign",
                column: "NextCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_PreviousCampaignId",
                table: "UserCampaign",
                column: "PreviousCampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaign_Campaign_CampaignId",
                table: "UserCampaign",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaign_Campaign_NextCampaignId",
                table: "UserCampaign",
                column: "NextCampaignId",
                principalTable: "Campaign",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaign_Campaign_PreviousCampaignId",
                table: "UserCampaign",
                column: "PreviousCampaignId",
                principalTable: "Campaign",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaign_Campaign_CampaignId",
                table: "UserCampaign");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaign_Campaign_NextCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaign_Campaign_PreviousCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaign_CampaignId",
                table: "UserCampaign");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaign_NextCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaign_PreviousCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "UserCampaign");

            migrationBuilder.DropColumn(
                name: "NextCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropColumn(
                name: "PreviousCampaignId",
                table: "UserCampaign");
        }
    }
}
