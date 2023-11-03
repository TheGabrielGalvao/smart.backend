using Domain.Entities.Stock;

namespace Domain.Interface.Repository.Stock
{
    public interface IInventoryAdjustmentRepository
    {
        Task<IEnumerable<InventoryAdjustmentEntity>> Get();
        Task<InventoryAdjustmentEntity> Get(Guid uuid);
        Task<InventoryAdjustmentEntity> Create(InventoryAdjustmentEntity user);
        Task<InventoryAdjustmentEntity> Update(InventoryAdjustmentEntity user);
        Task Delete(Guid uuid);
    }
}
