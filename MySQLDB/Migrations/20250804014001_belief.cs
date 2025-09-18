using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class belief : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserActivityBeliefThreshold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ManifestGoal = table.Column<string>(type: "text", nullable: false),
                    Hesitations = table.Column<string>(type: "json", nullable: true),
                    CurrentTimeIndex = table.Column<int>(type: "int", nullable: false),
                    PerfectTimeFrameLabel = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    PerfectTimeFrameYears = table.Column<decimal>(type: "decimal(10,4)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivityBeliefThreshold", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActivityBeliefThreshold_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivityBeliefThreshold_UserId",
                table: "UserActivityBeliefThreshold",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActivityBeliefThreshold");
        }
    }
}
