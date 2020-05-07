﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using DistribuitorServiciiMobile.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DomainModel.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(DistribuitorServiciiMobileContext))]
    partial class DistribuitorServiciiMobileContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Abonament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInceput")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataSfarsit")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeAbonament")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Abonament");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Bonus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DateBonus")
                        .HasColumnType("float");

                    b.Property<double>("MinuteBonus")
                        .HasColumnType("float");

                    b.Property<int>("SmsBonus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Bonus");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodNumericPersonal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AbonamentId");

                    b.HasIndex("ClientId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.DateMobile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumarDate")
                        .HasColumnType("int");

                    b.Property<string>("TipDate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbonamentId");

                    b.ToTable("DateMobile");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Minute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumarMinute")
                        .HasColumnType("int");

                    b.Property<string>("TipMinute")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbonamentId");

                    b.ToTable("Minute");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.SMS", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonamentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumarSms")
                        .HasColumnType("int");

                    b.Property<string>("TipSms")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AbonamentId");

                    b.ToTable("Sms");
                });

            modelBuilder.Entity("DomainModel.Models.ConvorbireTelefonica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataApel")
                        .HasColumnType("datetime2");

                    b.Property<double>("DurataConvorbire")
                        .HasColumnType("float");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ReceptorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("InitiatorId");

                    b.HasIndex("ReceptorId");

                    b.ToTable("ConvorbiriTelefonice");
                });

            modelBuilder.Entity("DomainModel.Models.Plata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ContractId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPlata")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalDePlata")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContractId");

                    b.ToTable("Plati");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Bonus", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Contract", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Abonament", "Abonament")
                        .WithMany("Contracte")
                        .HasForeignKey("AbonamentId");

                    b.HasOne("DistribuitorServiciiMobile.Models.Client", "Client")
                        .WithMany("Contracte")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.DateMobile", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Abonament", null)
                        .WithMany("AbonamentDate")
                        .HasForeignKey("AbonamentId");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.Minute", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Abonament", null)
                        .WithMany("AbonamentMinute")
                        .HasForeignKey("AbonamentId");
                });

            modelBuilder.Entity("DistribuitorServiciiMobile.Models.SMS", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Abonament", null)
                        .WithMany("AbonamentSms")
                        .HasForeignKey("AbonamentId");
                });

            modelBuilder.Entity("DomainModel.Models.ConvorbireTelefonica", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Client", "Initiator")
                        .WithMany()
                        .HasForeignKey("InitiatorId");

                    b.HasOne("DistribuitorServiciiMobile.Models.Client", "Receptor")
                        .WithMany()
                        .HasForeignKey("ReceptorId");
                });

            modelBuilder.Entity("DomainModel.Models.Plata", b =>
                {
                    b.HasOne("DistribuitorServiciiMobile.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("DistribuitorServiciiMobile.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");
                });
#pragma warning restore 612, 618
        }
    }
}
