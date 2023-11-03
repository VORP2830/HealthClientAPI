namespace Clientes.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; protected set; }
        public DateOnly BirthDay { get; protected set; }
        public string Sex { get; protected set; }
        public IEnumerable<HealthProblem> healthProblems { get; protected set; }
        protected Client(){ }
        public Client(string name, DateOnly birthDay, string sex)
        {
            Name = name.Trim();
            BirthDay = birthDay;
            Sex = sex;
            Active = true;
        }
        public double GetScore()
        {
            int totalDegree = 0;
            foreach(HealthProblem healthProblem in this.healthProblems)
            {
                if(healthProblem.Active == true)
                {
                    totalDegree += healthProblem.Degree;
                }
            }   
            return (1 / (1 + Math.Exp(-(-2.8 + totalDegree))) * 100);
        }
    }
}