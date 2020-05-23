using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class Valability : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Valabil",
                table: "Contract",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Expirat",
                table: "Abonament",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valabil",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Expirat",
                table: "Abonament");
        }
    }
}
