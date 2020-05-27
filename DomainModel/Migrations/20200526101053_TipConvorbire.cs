using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class TipConvorbire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TipConvorbire",
                table: "ConvorbiriTelefonice",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipConvorbire",
                table: "ConvorbiriTelefonice");
        }
    }
}
