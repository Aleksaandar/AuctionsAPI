﻿using System.ComponentModel.DataAnnotations;

namespace AuctionsAPI.Models
{

    public class CreateItemDTO
    {
    

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Naziv proizvoda je predugacak.")]
        public string Naziv { get; set; }

        [Required]
        public string Opis { get; set; }

        [Required]
        public double Pocetna_cena { get; set; }
        [Required]
        public double Trenutna_cena { get; set; }

        [Required]
        public string Kategorija { get; set; }

    }
    public class ItemDTO:CreateItemDTO
    {
        public int Id { get; set; }

        

    }
}
