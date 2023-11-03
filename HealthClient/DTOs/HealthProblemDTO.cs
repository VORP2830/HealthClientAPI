namespace Clientes.DTOs
{
    public class HealthProblemDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public long? ClientId { get; set; }
    }
}