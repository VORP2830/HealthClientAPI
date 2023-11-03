using Clientes.Context;
using Clientes.Entities;
using Clientes.Pagination;
using Clientes.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clientes.Repository
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients
                                    .Include(c => c.healthProblems)
                                    .Where(c => c.Active == true)
                                    .ToListAsync();
        }
        public async Task<Client> GetById(long id)
        {
            return await _context.Clients
                                .Include(c => c.healthProblems)
                                .Where(c => c.Active == true)
                                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}