using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonus_Contract_ContractId",
                table: "Bonus");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Abonament_AbonamentId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_InitiatorId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_ReceptorId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Client_ClientId",
                table: "Plati");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Contract_ContractId",
                table: "Plati");

            migrationBuilder.AlterColumn<string>(
                name: "TipSms",
                table: "Sms",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractId",
                table: "Plati",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Plati",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipMinute",
                table: "Minute",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipDate",
                table: "DateMobile",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceptorId",
                table: "ConvorbiriTelefonice",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "InitiatorId",
                table: "ConvorbiriTelefonice",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Contract",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AbonamentId",
                table: "Contract",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Client",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Client",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CodNumericPersonal",
                table: "Client",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractId",
                table: "Bonus",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumeAbonament",
                table: "Abonament",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bonus_Contract_ContractId",
                table: "Bonus",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Abonament_AbonamentId",
                table: "Contract",
                column: "AbonamentId",
                principalTable: "Abonament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_InitiatorId",
                table: "ConvorbiriTelefonice",
                column: "InitiatorId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_ReceptorId",
                table: "ConvorbiriTelefonice",
                column: "ReceptorId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Client_ClientId",
                table: "Plati",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Contract_ContractId",
                table: "Plati",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bonus_Contract_ContractId",
                table: "Bonus");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Abonament_AbonamentId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Client_ClientId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_InitiatorId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_ReceptorId",
                table: "ConvorbiriTelefonice");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Client_ClientId",
                table: "Plati");

            migrationBuilder.DropForeignKey(
                name: "FK_Plati_Contract_ContractId",
                table: "Plati");

            migrationBuilder.AlterColumn<string>(
                name: "TipSms",
                table: "Sms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractId",
                table: "Plati",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Plati",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "TipMinute",
                table: "Minute",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "TipDate",
                table: "DateMobile",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "ReceptorId",
                table: "ConvorbiriTelefonice",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "InitiatorId",
                table: "ConvorbiriTelefonice",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Contract",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AbonamentId",
                table: "Contract",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CodNumericPersonal",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContractId",
                table: "Bonus",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "NumeAbonament",
                table: "Abonament",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Bonus_Contract_ContractId",
                table: "Bonus",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Abonament_AbonamentId",
                table: "Contract",
                column: "AbonamentId",
                principalTable: "Abonament",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Client_ClientId",
                table: "Contract",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_InitiatorId",
                table: "ConvorbiriTelefonice",
                column: "InitiatorId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConvorbiriTelefonice_Client_ReceptorId",
                table: "ConvorbiriTelefonice",
                column: "ReceptorId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Client_ClientId",
                table: "Plati",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plati_Contract_ContractId",
                table: "Plati",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
