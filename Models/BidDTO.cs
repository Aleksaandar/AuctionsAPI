
using System.ComponentModel.DataAnnotations;


namespace AuctionsAPI.Models
{


    public class CreateBidDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Iznos { get; set; }
        [Required]
        public int AuctionId { get; set; }
    }
    public class BidDTO:CreateBidDTO
    {
        public int Id { get; set; }

        public AuctionDTO Auction { get; set; }
    }
}
