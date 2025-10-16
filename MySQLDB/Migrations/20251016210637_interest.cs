using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySQLDB.Migrations
{
    /// <inheritdoc />
    public partial class interest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstInterests",
                table: "User",
                type: "varchar(333)",
                maxLength: 333,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                column: "FirstInterests",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstInterests",
                table: "User");
        }
    }
}
