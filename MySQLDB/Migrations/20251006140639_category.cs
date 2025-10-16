using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Product",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "Product",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "EsProduct",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "EsProduct",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TrackEmail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserEmail = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(333)", maxLength: 333, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Step = table.Column<int>(type: "int", nullable: true),
                    After = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    At = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    File = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Folder = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: true),
                    Actions = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: true),
                    Gifts = table.Column<string>(type: "varchar(1500)", maxLength: 1500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackEmail_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TrackEmail_UserId",
                table: "TrackEmail",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackEmail");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "EsProduct");

            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "EsProduct");
        }
    }
}
