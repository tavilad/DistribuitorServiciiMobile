using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class ConvorbiriContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ContractId",
                table: "ConvorbiriTelefonice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConvorbiriTelefonice_ContractId",
                table: "ConvorbiriTelefonice",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConvorbiriTelefonice_Contract_ContractId",
                table: "ConvorbiriTelefonice",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConvorbiriTelefonice_Contract_ContractId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropIndex(
                name: "IX_ConvorbiriTelefonice_ContractId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "ConvorbiriTelefonice");
        }
    }
}
