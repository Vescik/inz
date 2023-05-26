using Contractor.API.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Contractor.API.Repositories
{
    public class ContractorRepository : IContractorRepository
    {
        private readonly ContractorDbContext _context;

        public ContractorRepository(ContractorDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Entities.Contractor> GetAsync(Guid contractorId)
        {
            return await _context.Contractors.FirstOrDefaultAsync(x => x.Id == contractorId);
        }

        public async Task<IEnumerable<Entities.Contractor>> GetAllAsync()
        {
            return await _context.Contractors.ToListAsync();
        }

        public Task AddAsync(Entities.Contractor contractor)
        {
            throw new NotImplementedException();
        }
    }
}
