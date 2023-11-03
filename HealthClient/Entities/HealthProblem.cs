using Clientes.Entities.ValidationDomain;

namespace Clientes.Entities
{
    public class HealthProblem : BaseEntity
    {
        public string Name { get; protected set; }
        public int Degree { get; protected set; }
        public long ClientId { get; protected set; }
        public Client Client { get; protected set; }
        protected HealthProblem(){ }
        public HealthProblem(string name, int degree, long clientId)
        {
            Name = name.Trim();
            DomainExceptionValidation.When(degree < 1 && degree > 2, "Grau deve ser 1 ou 2 apenas");
            Degree = degree;
            ClientId = clientId;
            Active = true;
        }
    }
}