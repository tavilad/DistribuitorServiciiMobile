using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace DomainModel.Migrations
{
    public partial class AddedCountersAndPrices : Migration
    {
        [ExcludeFromCodeCoverage]
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PretSms",
                table: "Sms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SmsConsumate",
                table: "Sms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "SumaPlatita",
                table: "Plati",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "MinuteConsumate",
                table: "Minute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PretMinute",
                table: "Minute",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DateConsumate",
                table: "DateMobile",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PretData",
                table: "DateMobile",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PretSms",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "SmsConsumate",
                table: "Sms");

            migrationBuilder.DropColumn(
                name: "SumaPlatita",
                table: "Plati");

            migrationBuilder.DropColumn(
                name: "MinuteConsumate",
                table: "Minute");

            migrationBuilder.DropColumn(
                name: "PretMinute",
                table: "Minute");

            migrationBuilder.DropColumn(
                name: "DateConsumate",
                table: "DateMobile");

            migrationBuilder.DropColumn(
                name: "PretData",
                table: "DateMobile");
        }
    }
}
