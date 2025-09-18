using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class activity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserActivityRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "e.g., twelve_areas_balance"),
                    AreaId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "e.g., finances, health"),
                    Score = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    AttemptNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "To group ratings for each take"),
                    RatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivityRating_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityRatings_UniqueAttempt",
                table: "UserActivityRating",
                columns: new[] { "UserId", "ActivityId", "AreaId", "AttemptNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivityRating");
        }
    }
}
