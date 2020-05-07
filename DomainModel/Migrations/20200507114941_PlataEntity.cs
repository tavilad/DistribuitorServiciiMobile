using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PlataEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plati",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    DataPlata = table.Column<DateTime>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: true),
                    TotalDePlata = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plati", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plati_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Plati_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plati_ClientId",
                table: "Plati",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Plati_ContractId",
                table: "Plati",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plati");
        }
    }
}
