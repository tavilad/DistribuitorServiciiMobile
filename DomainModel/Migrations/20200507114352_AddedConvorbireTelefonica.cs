using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    public partial class AddedConvorbireTelefonica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConvorbiriTelefonice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InitiatorId = table.Column<Guid>(nullable: true),
                    ReceptorId = table.Column<Guid>(nullable: true),
                    DurataConvorbire = table.Column<double>(nullable: false),
                    DataApel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvorbiriTelefonice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConvorbiriTelefonice_Client_InitiatorId",
                        column: x => x.InitiatorId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConvorbiriTelefonice_Client_ReceptorId",
                        column: x => x.ReceptorId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvorbiriTelefonice_InitiatorId",
                table: "ConvorbiriTelefonice",
                column: "InitiatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvorbiriTelefonice_ReceptorId",
                table: "ConvorbiriTelefonice",
                column: "ReceptorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConvorbiriTelefonice");
        }
    }
}
