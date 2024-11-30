using AuctionsAPI.Data;

namespace AuctionsAPI.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Auction> Auctions{ get; }
        IGenericRepository<Bid> Bids{ get; }
        Task Save();
    }
}
