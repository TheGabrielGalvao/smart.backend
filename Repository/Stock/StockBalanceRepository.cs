using Database;
using Domain.Entities.Stock;
using Domain.Interface.Repository.Stock;
using Repository.Common;

namespace Repository.Stock
{
    public class StockBalanceRepository : BaseRepository<StockBalanceEntity>, IStockBalanceRepository
    {
        public StockBalanceRepository(AppDbContext context) : base(context)
        {
        }


    }
}
