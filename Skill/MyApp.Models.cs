namespace MyApp.Models
{
    public class Info
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public DateTime BirthDate { get; set; }
        public Profession Profession { get; set; }
        public List<PersonSkill> Skills { get; set; } = new List<PersonSkill>();
    }
}
