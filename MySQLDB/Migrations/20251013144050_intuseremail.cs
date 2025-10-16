using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class intuseremail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "TrackEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEmail",
                table: "TrackEmail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
