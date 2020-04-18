﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataMapper.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    NumarDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMobile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipMinute = table.Column<string>(nullable: true),
                    NumarMinute = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipSms = table.Column<string>(nullable: true),
                    NumarSms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Pret = table.Column<double>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: true),
                    TraficDate = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abonament_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbonamentDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true),
                    DateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonamentDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonamentDate_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbonamentDate_DateMobile_DateId",
                        column: x => x.DateId,
                        principalTable: "DateMobile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbonamentMinute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true),
                    MinuteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonamentMinute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonamentMinute_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbonamentMinute_Minute_MinuteId",
                        column: x => x.MinuteId,
                        principalTable: "Minute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbonamentSms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AbonamentId = table.Column<Guid>(nullable: true),
                    SmsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbonamentSms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbonamentSms_Abonament_AbonamentId",
                        column: x => x.AbonamentId,
                        principalTable: "Abonament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AbonamentSms_Sms_SmsId",
                        column: x => x.SmsId,
                        principalTable: "Sms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_ClientId",
                table: "Abonament",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentDate_AbonamentId",
                table: "AbonamentDate",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentDate_DateId",
                table: "AbonamentDate",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentMinute_AbonamentId",
                table: "AbonamentMinute",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentMinute_MinuteId",
                table: "AbonamentMinute",
                column: "MinuteId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentSms_AbonamentId",
                table: "AbonamentSms",
                column: "AbonamentId");

            migrationBuilder.CreateIndex(
                name: "IX_AbonamentSms_SmsId",
                table: "AbonamentSms",
                column: "SmsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbonamentDate");

            migrationBuilder.DropTable(
                name: "AbonamentMinute");

            migrationBuilder.DropTable(
                name: "AbonamentSms");

            migrationBuilder.DropTable(
                name: "DateMobile");

            migrationBuilder.DropTable(
                name: "Minute");

            migrationBuilder.DropTable(
                name: "Abonament");

            migrationBuilder.DropTable(
                name: "Sms");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
