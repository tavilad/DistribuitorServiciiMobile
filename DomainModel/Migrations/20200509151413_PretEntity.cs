using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class PretEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PretSms",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "SumaPlatita",
                table: "Plati");

            migrationBuilder.DropColumn(
                name: "TotalDePlata",
                table: "Plati");

            migrationBuilder.DropColumn(
                name: "PretMinute",
                table: "Minute");

            migrationBuilder.DropColumn(
                name: "PretData",
                table: "DateMobile");

            migrationBuilder.AddColumn<Guid>(
                name: "PretSmsId",
                table: "Sms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SumaPlatitaId",
                table: "Plati",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "TotalDePlataId",
                table: "Plati",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PretMinuteId",
                table: "Minute",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PretDataId",
                table: "DateMobile",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Preturi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Valuta = table.Column<string>(maxLength: 50, nullable: false),
                    Suma = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preturi", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sms_PretSmsId",
                table: "Sms",
                column: "PretSmsId");

            migrationBuilder.CreateIndex(
                name: "IX_Plati_SumaPlatitaId",
                table: "Plati",
                column: "SumaPlatitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Plati_TotalDePlataId",
                table: "Plati",
                column: "TotalDePlataId");

            migrationBuilder.CreateIndex(
                name: "IX_Minute_PretMinuteId",
                table: "Minute",
                column: "PretMinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMobile_PretDataId",
                table: "DateMobile",
                column: "PretDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_DateMobile_Preturi_PretDataId",
                table: "DateMobile",
                column: "PretDataId",
                principalTable: "Preturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Minute_Preturi_PretMinuteId",
                table: "Minute",
                column: "PretMinuteId",
                principalTable: "Preturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Preturi_SumaPlatitaId",
                table: "Plati",
                column: "SumaPlatitaId",
                principalTable: "Preturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Preturi_TotalDePlataId",
                table: "Plati",
                column: "TotalDePlataId",
                principalTable: "Preturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Sms_Preturi_PretSmsId",
                table: "Sms",
                column: "PretSmsId",
                principalTable: "Preturi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateMobile_Preturi_PretDataId",
                table: "DateMobile");

            migrationBuilder.DropForeignKey(
                name: "FK_Minute_Preturi_PretMinuteId",
                table: "Minute");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Preturi_SumaPlatitaId",
                table: "Plati");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Preturi_TotalDePlataId",
                table: "Plati");

            migrationBuilder.DropForeignKey(
                name: "FK_Sms_Preturi_PretSmsId",
                table: "Sms");

            migrationBuilder.DropTable(
                name: "Preturi");

            migrationBuilder.DropIndex(
                name: "IX_Sms_PretSmsId",
                table: "Sms");

            migrationBuilder.DropIndex(
                name: "IX_Plati_SumaPlatitaId",
                table: "Plati");

            migrationBuilder.DropIndex(
                name: "IX_Plati_TotalDePlataId",
                table: "Plati");

            migrationBuilder.DropIndex(
                name: "IX_Minute_PretMinuteId",
                table: "Minute");

            migrationBuilder.DropIndex(
                name: "IX_DateMobile_PretDataId",
                table: "DateMobile");

            migrationBuilder.DropColumn(
                name: "PretSmsId",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "SumaPlatitaId",
                table: "Plati");

            migrationBuilder.DropColumn(
                name: "TotalDePlataId",
                table: "Plati");

            migrationBuilder.DropColumn(
                name: "PretMinuteId",
                table: "Minute");

            migrationBuilder.DropColumn(
                name: "PretDataId",
                table: "DateMobile");

            migrationBuilder.AddColumn<int>(
                name: "PretSms",
                table: "Sms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SumaPlatita",
                table: "Plati",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalDePlata",
                table: "Plati",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PretMinute",
                table: "Minute",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PretData",
                table: "DateMobile",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
