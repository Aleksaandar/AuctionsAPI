using AuctionsAPI.Data;
using AuctionsAPI.IRepository;

namespace AuctionsAPI.Repository
{
    public class UnitofWork : IUnitofWork

    {
        private readonly DatabaseContext _databaseContext;
        private IGenericRepository<Item> _items;
        private IGenericRepository<Auction> _auctions;
        private IGenericRepository<Bid> _bids;
        public UnitofWork(DatabaseContext context)
        {
            _databaseContext = context;
        }
        public IGenericRepository<Item> Items => _items ??= new GenericRepository<Item>(_databaseContext);

        public IGenericRepository<Auction> Auctions => _auctions ??= new GenericRepository<Auction>(_databaseContext);

        public IGenericRepository<Bid> Bids => _bids ??= new GenericRepository<Bid>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
           await _databaseContext.SaveChangesAsync();
        }
    }
}
