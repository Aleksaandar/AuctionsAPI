using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionsAPI.Data
{
    public class Auction
    {
        public int Id { get; set; }

        public int  Broj_licitacija { get; set; }
        public DateTime Vreme_pocetka { get; set; }

        public DateTime Vreme_zavrsetka { get; set; }

        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
       
    }
}
