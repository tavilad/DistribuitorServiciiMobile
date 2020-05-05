using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DomainModel.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pret = table.Column<double>(nullable: false),
                    TraficDate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CodNumericPersonal = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateMobile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipDate = table.Column<string>(nullable: true),
                    NumarDate = table.Column<int>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMobile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DateMobile_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Minute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipMinute = table.Column<string>(nullable: true),
                    NumarMinute = table.Column<int>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minute_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipSms = table.Column<string>(nullable: true),
                    NumarSms = table.Column<int>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sms_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    AbonamentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bonus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MinuteBonus = table.Column<double>(nullable: false),
                    SmsBonus = table.Column<int>(nullable: false),
                    DateBonus = table.Column<double>(nullable: false),
                    ContractId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonus_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_ContractId",
                table: "Bonus",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_AbonamentId",
                table: "Contract",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_ClientId",
                table: "Contract",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DateMobile_AbonamentId",
                table: "DateMobile",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Minute_AbonamentId",
                table: "Minute",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sms_AbonamentId",
                table: "Sms",
                column: "AbonamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus");

            migrationBuilder.DropTable(
                name: "DateMobile");

            migrationBuilder.DropTable(
                name: "Minute");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Abonament");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
