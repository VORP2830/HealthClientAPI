using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clientes.Context;
using Clientes.Repository.Interfaces;

namespace Clientes.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IClientRepository ClientRepository => new ClientRepository(_context);
        public IHealthProblemRepository HealthProblemRepository => new HealthProblemRepository(_context);
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}