﻿using Microsoft.EntityFrameworkCore;

namespace AuctionsAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Auction> Auctions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bid>()
                  .ToTable(tb => tb.HasTrigger("trg_UpdateBrojLicitacija"));

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Naziv = "Assassins Creed Black Flag IV",
                    Opis = "Kompjuterska igrica",
                    Pocetna_cena = 130,
                    Trenutna_cena = 180,
                    Kategorija = "Kompjuterske Igrice i Filmovi",
                    Picture= "https://spacenetgameshop.net/image/cache/data/001%20PS4%20Cover/assassins-creed-black-flag-546x840.jpg"
                },
               new Item
               {
                   Id = 2,
                   Naziv = "Tastatura",
                   Opis = "Tastatura za kucanje",
                   Pocetna_cena = 60,
                   Trenutna_cena = 88,
                   Kategorija = "Tehnika",
                   Picture= "https://www.kancelarijskimaterijal-bg.rs/images/products/big/398.jpg"

               },
                new Item
                {
                    Id = 3,
                    Naziv = "Kosarkaska lopta",
                    Opis = "lopta za igranje kosarke",
                    Pocetna_cena = 50,
                    Trenutna_cena = 75,
                    Kategorija = "Sport",
                    Picture= "https://trendcoo.rs/wp-content/uploads/2023/08/77-101z-1.jpg"
                }
                );
            modelBuilder.Entity<Auction>().HasData(
                new Auction
                {
                    Id = 1,
                    ItemId = 1,
                    Vreme_pocetka = new DateTime(),
                    Vreme_zavrsetka = new DateTime(),
                    Broj_licitacija = 0,

                },
               new Auction
               {
                   Id = 2,
                   ItemId = 2,
                   Vreme_pocetka = new DateTime(),
                   Vreme_zavrsetka = new DateTime(),
                   Broj_licitacija = 0,

               },
                new Auction
                {
                    Id = 3,
                    ItemId = 3,
                    Vreme_pocetka = new DateTime(),
                    Vreme_zavrsetka = new DateTime(),
                    Broj_licitacija = 0,
                }
                );

        }
    }
}
