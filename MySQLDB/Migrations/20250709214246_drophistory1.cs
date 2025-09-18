using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class drophistory1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaign_Campaign_InitialCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCampaign_Campaign_LastCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropTable(
                name: "CampaignEmailHistory");

            migrationBuilder.DropTable(
                name: "UserCampaignHistory");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaign_InitialCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropIndex(
                name: "IX_UserCampaign_LastCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropColumn(
                name: "InitialCampaignId",
                table: "UserCampaign");

            migrationBuilder.DropColumn(
                name: "LastCampaignId",
                table: "UserCampaign");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedOn",
                table: "UserCampaign",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCampaignEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: false),
                    FolderName = table.Column<string>(type: "longtext", nullable: false),
                    FullPath = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    ErrorMessage = table.Column<string>(type: "longtext", nullable: true),
                    UserCampaignId = table.Column<int>(type: "int", nullable: false),
                    PreviousUserCampaignEmailId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaignEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCampaignEmail_UserCampaignEmail_PreviousUserCampaignEmai~",
                        column: x => x.PreviousUserCampaignEmailId,
                        principalTable: "UserCampaignEmail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaignEmail_UserCampaign_UserCampaignId",
                        column: x => x.UserCampaignId,
                        principalTable: "UserCampaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignEmail_PreviousUserCampaignEmailId",
                table: "UserCampaignEmail",
                column: "PreviousUserCampaignEmailId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignEmail_UserCampaignId",
                table: "UserCampaignEmail",
                column: "UserCampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCampaignEmail");

            migrationBuilder.DropColumn(
                name: "CompletedOn",
                table: "UserCampaign");

            migrationBuilder.AddColumn<int>(
                name: "InitialCampaignId",
                table: "UserCampaign",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LastCampaignId",
                table: "UserCampaign",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCampaignHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CurrentCampaignId = table.Column<int>(type: "int", nullable: false),
                    PreviousUserCampaignHistoryId = table.Column<int>(type: "int", nullable: true),
                    UserCampaignId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaignHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCampaignHistory_Campaign_CurrentCampaignId",
                        column: x => x.CurrentCampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCampaignHistory_UserCampaignHistory_PreviousUserCampaign~",
                        column: x => x.PreviousUserCampaignHistoryId,
                        principalTable: "UserCampaignHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaignHistory_UserCampaign_UserCampaignId",
                        column: x => x.UserCampaignId,
                        principalTable: "UserCampaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CampaignEmailHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PreviousCampaignEmailHistoryId = table.Column<int>(type: "int", nullable: true),
                    UserCampaignHistoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ErrorMessage = table.Column<string>(type: "longtext", nullable: true),
                    FileName = table.Column<string>(type: "longtext", nullable: false),
                    FolderName = table.Column<string>(type: "longtext", nullable: false),
                    FullPath = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignEmailHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignEmailHistory_CampaignEmailHistory_PreviousCampaignEm~",
                        column: x => x.PreviousCampaignEmailHistoryId,
                        principalTable: "CampaignEmailHistory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CampaignEmailHistory_UserCampaignHistory_UserCampaignHistory~",
                        column: x => x.UserCampaignHistoryId,
                        principalTable: "UserCampaignHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_InitialCampaignId",
                table: "UserCampaign",
                column: "InitialCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_LastCampaignId",
                table: "UserCampaign",
                column: "LastCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEmailHistory_PreviousCampaignEmailHistoryId",
                table: "CampaignEmailHistory",
                column: "PreviousCampaignEmailHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEmailHistory_UserCampaignHistoryId",
                table: "CampaignEmailHistory",
                column: "UserCampaignHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_CurrentCampaignId",
                table: "UserCampaignHistory",
                column: "CurrentCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_PreviousUserCampaignHistoryId",
                table: "UserCampaignHistory",
                column: "PreviousUserCampaignHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_UserCampaignId",
                table: "UserCampaignHistory",
                column: "UserCampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaign_Campaign_InitialCampaignId",
                table: "UserCampaign",
                column: "InitialCampaignId",
                principalTable: "Campaign",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCampaign_Campaign_LastCampaignId",
                table: "UserCampaign",
                column: "LastCampaignId",
                principalTable: "Campaign",
                principalColumn: "Id");
        }
    }
}
