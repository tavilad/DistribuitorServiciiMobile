using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class NumeAbonament : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeAbonament",
                table: "Abonament",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeAbonament",
                table: "Abonament");
        }
    }
}
