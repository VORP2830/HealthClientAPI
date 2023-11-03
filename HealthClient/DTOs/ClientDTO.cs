namespace Clientes.DTOs
{
    public class ClientDTO
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public DateOnly BirthDay { get;  set; }
        public string Sex { get;  set; }
        public IEnumerable<HealthProblemDTO> healthProblems { get;  set; }
    }
}