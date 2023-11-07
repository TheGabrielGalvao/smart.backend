using Domain.Entities.Fiancial;

namespace Domain.Interface.Repository.Financial
{
    public interface IFinancialReleaseRepository
    {
        Task<IEnumerable<FinancialReleaseEntity>> Get();
        Task<FinancialReleaseEntity> Get(Guid uuid);
        Task<FinancialReleaseEntity> Create(FinancialReleaseEntity user);
        Task<FinancialReleaseEntity> Update(FinancialReleaseEntity user);
        Task Delete(Guid uuid);
    }
}
