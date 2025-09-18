using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class addstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "LeadHistory",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "LeadHistory",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Section",
                table: "LeadHistory");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "LeadHistory");
        }
    }
}
