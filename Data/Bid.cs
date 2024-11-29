using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionsAPI.Data
{
    public class Bid
    {
        public int Id { get; set; }
        public int Iznos    { get; set; }

        [ForeignKey(nameof(Auction))]
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
       
    }
}
