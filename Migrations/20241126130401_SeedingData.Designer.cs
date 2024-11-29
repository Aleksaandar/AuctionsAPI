﻿// <auto-generated />
using System;
using AuctionsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AuctionsAPI.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241126130401_SeedingData")]
    partial class SeedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionsAPI.Data.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Broj_licitacija")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Vreme_pocetka")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Vreme_zavrsetka")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Broj_licitacija = 0,
                            ItemId = 1,
                            Vreme_pocetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Vreme_zavrsetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Broj_licitacija = 0,
                            ItemId = 2,
                            Vreme_pocetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Vreme_zavrsetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Broj_licitacija = 0,
                            ItemId = 3,
                            Vreme_pocetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Vreme_zavrsetka = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AuctionsAPI.Data.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int>("Iznos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("AuctionsAPI.Data.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Kategorija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pocetna_cena")
                        .HasColumnType("float");

                    b.Property<double>("Trenutna_cena")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Kategorija = "Kompjuterske Igrice i Filmovi",
                            Naziv = "Assassins Creed Black Flag IV",
                            Opis = "Kompjuterska igrica",
                            Pocetna_cena = 130.0,
                            Trenutna_cena = 180.0
                        },
                        new
                        {
                            Id = 2,
                            Kategorija = "Tehnika",
                            Naziv = "Tastatura",
                            Opis = "Tastatura za kucanje",
                            Pocetna_cena = 60.0,
                            Trenutna_cena = 88.0
                        },
                        new
                        {
                            Id = 3,
                            Kategorija = "Sport",
                            Naziv = "Kosarkaska lopta",
                            Opis = "lopta za igranje kosarke",
                            Pocetna_cena = 50.0,
                            Trenutna_cena = 75.0
                        });
                });

            modelBuilder.Entity("AuctionsAPI.Data.Auction", b =>
                {
                    b.HasOne("AuctionsAPI.Data.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("AuctionsAPI.Data.Bid", b =>
                {
                    b.HasOne("AuctionsAPI.Data.Auction", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Auction");
                });
#pragma warning restore 612, 618
        }
    }
}