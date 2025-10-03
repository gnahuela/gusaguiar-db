using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class track : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Event = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Message = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    Path = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    TrafficSource = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    NavigatorUserAgent = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NavigatorLanguage = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NavigatorPlatform = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    FrontendTimeStamp = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackLog", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackLog");
        }
    }
}
