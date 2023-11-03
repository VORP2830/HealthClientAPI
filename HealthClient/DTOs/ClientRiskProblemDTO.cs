namespace Clientes.DTOs
{
    public class ClientRiskProblemDTO
    {
        public long Id { get;  set; }
        public string Name { get;  set; }
        public DateOnly BirthDay { get;  set; }
        public string Sex { get;  set; }
        public double HealthScoreRisk { get;  set; }
        public ClientRiskProblemDTO(long id, string name, DateOnly birthDay, string sex, double healthScoreRisk)
        {
            Id = id;
            Name = name;
            BirthDay = birthDay;
            Sex = sex;
            HealthScoreRisk = healthScoreRisk;
        }
    }
}