using AuctionsAPI.Data;
using AuctionsAPI.Models;
using AutoMapper;

namespace AuctionsAPI.Configurations
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Item,ItemDTO>().ReverseMap();
            CreateMap<Item,CreateItemDTO>().ReverseMap();
            CreateMap<Auction,AuctionDTO>().ReverseMap();
            CreateMap<Auction,CreateAuctionDTO>().ReverseMap();
            CreateMap<Bid,BidDTO>().ReverseMap();
            CreateMap<Bid,CreateBidDTO>().ReverseMap();
        }
    }
}
