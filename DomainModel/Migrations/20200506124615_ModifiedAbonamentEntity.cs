using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    public partial class ModifiedAbonamentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TraficDate",
                table: "Abonament");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TraficDate",
                table: "Abonament",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
