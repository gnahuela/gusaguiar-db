using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class validto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTo",
                table: "UserProduct",
                type: "DATETIME",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValidTo",
                table: "UserProduct");
        }
    }
}
