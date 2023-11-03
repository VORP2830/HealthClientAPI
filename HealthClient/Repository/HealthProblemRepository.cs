using Clientes.Context;
using Clientes.Entities;
using Clientes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Repository
{
    public class HealthProblemRepository : GenericRepository<HealthProblem>, IHealthProblemRepository
    {
        private readonly ApplicationDbContext _context;
        public HealthProblemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HealthProblem>> GetByClientId(long clientId)
        {
            return await _context.HealthProblems
                                .Where(c => c.Active == true && c.ClientId == clientId)
                                .ToListAsync();
        }

        public async Task<HealthProblem> GetById(long id)
        {
            return await _context.HealthProblems
                                .Where(c => c.Active == true)
                                .FirstOrDefaultAsync();
        }  
    }
}