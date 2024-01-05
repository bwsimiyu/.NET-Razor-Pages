using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesRocket.Migrations
{
    /// <inheritdoc />
    public partial class desiredOrbit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Payload",
                table: "Rocket",
                type: "decimal(18, 2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesiredOrbit",
                table: "Rocket",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesiredOrbit",
                table: "Rocket");

            migrationBuilder.AlterColumn<string>(
                name: "Payload",
                table: "Rocket",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "decimal(18, 2)",
                oldNullable: true);
        }
    }
}
