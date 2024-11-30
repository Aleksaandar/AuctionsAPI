using System.ComponentModel.DataAnnotations;

namespace AuctionsAPI.Models
{
    

    public class CreateAuctionDTO
    {
        public int Id { get; set; }

        public int Broj_licitacija { get; set; }
        public DateTime Vreme_pocetka { get; set; }

        [Required]
        public DateTime Vreme_zavrsetka { get; set; }
        [Required]
        public int ItemId { get; set; }
    }
    public class AuctionDTO:CreateAuctionDTO
    {
        public int Id { get; set; }
        public ItemDTO Item { get; set; }
       
    }
}
