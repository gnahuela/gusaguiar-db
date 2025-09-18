using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class campaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FolderName = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false),
                    Hours = table.Column<string>(type: "longtext", nullable: false),
                    Days = table.Column<string>(type: "longtext", nullable: false),
                    InitiateOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DisableOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    NextCampaignId = table.Column<int>(type: "int", nullable: true),
                    PreviousCampaignId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Campaign_NextCampaignId",
                        column: x => x.NextCampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Campaign_Campaign_PreviousCampaignId",
                        column: x => x.PreviousCampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LeadId = table.Column<int>(type: "int", nullable: true),
                    InitialCampaignId = table.Column<int>(type: "int", nullable: false),
                    LastCampaignId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaign", x => x.Id);
                    table.CheckConstraint("CK_UserCampaign_UserOrLead", "UserId IS NOT NULL OR LeadId IS NOT NULL");
                    table.ForeignKey(
                        name: "FK_UserCampaign_Campaign_InitialCampaignId",
                        column: x => x.InitialCampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCampaign_Campaign_LastCampaignId",
                        column: x => x.LastCampaignId,
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaign_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserCampaign_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserCampaignHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserCampaignId = table.Column<int>(type: "int", nullable: false),
                    CurrentCampaignId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true)
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
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    ErrorMessage = table.Column<string>(type: "longtext", nullable: true),
                    UserCampaignHistoryId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignEmailHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignEmailHistory_UserCampaignHistory_UserCampaignHistory~",
                        column: x => x.UserCampaignHistoryId,
                        principalTable: "UserCampaignHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_NextCampaignId",
                table: "Campaign",
                column: "NextCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_PreviousCampaignId",
                table: "Campaign",
                column: "PreviousCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignEmailHistory_UserCampaignHistoryId",
                table: "CampaignEmailHistory",
                column: "UserCampaignHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_InitialCampaignId",
                table: "UserCampaign",
                column: "InitialCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_LastCampaignId",
                table: "UserCampaign",
                column: "LastCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_LeadId",
                table: "UserCampaign",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_UserId",
                table: "UserCampaign",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_CurrentCampaignId",
                table: "UserCampaignHistory",
                column: "CurrentCampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaignHistory_UserCampaignId",
                table: "UserCampaignHistory",
                column: "UserCampaignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignEmailHistory");

            migrationBuilder.DropTable(
                name: "UserCampaignHistory");

            migrationBuilder.DropTable(
                name: "UserCampaign");

            migrationBuilder.DropTable(
                name: "Campaign");
        }
    }
}
