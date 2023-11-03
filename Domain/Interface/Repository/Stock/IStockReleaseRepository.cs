using Domain.Entities.Stock;

namespace Domain.Interface.Repository.Stock
{
    internal interface IStockReleaseRepository
    {
        Task<IEnumerable<StockReleaseEntity>> Get();
        Task<StockReleaseEntity> Get(Guid uuid);
        Task<StockReleaseEntity> Create(StockReleaseEntity data);
        Task<StockReleaseEntity> Update(StockReleaseEntity data);
        Task Delete(Guid uuid);
    }
}
