namespace Clientes.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        IHealthProblemRepository HealthProblemRepository { get; }
        Task<bool> SaveChangesAsync(); 
    }
}