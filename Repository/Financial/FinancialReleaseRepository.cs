using Database;
using Domain.Entities.Fiancial;
using Domain.Interface.Repository.Financial;
using Microsoft.EntityFrameworkCore;

namespace Repository.Financial
{
    public class FinancialReleaseRepository: IFinancialReleaseRepository
    {
        public readonly AppDbContext _context;
        public FinancialReleaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialReleaseEntity> Create(FinancialReleaseEntity transaction)
        {
            _context.FinancialReleases.Add(transaction);

            return transaction;
        }

        public async Task Delete(Guid uuid)
        {
            var transactionDelete = await _context.FinancialReleases.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.FinancialReleases.Remove(transactionDelete);
        }

        public async Task<IEnumerable<FinancialReleaseEntity>> Get()
        {
            return await _context.FinancialReleases.ToListAsync();
        }

        public async Task<FinancialReleaseEntity> Get(Guid uuid)
        {
            var transaction = await _context.FinancialReleases.FirstOrDefaultAsync(c => c.Uuid == uuid);
            return transaction;
        }

        public async Task<FinancialReleaseEntity> Update(FinancialReleaseEntity transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;
            return transaction;
        }
    }
}
