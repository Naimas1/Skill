namespace MyApp.Models
{
    public class PersonSkill
    {
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public int ProficiencyLevel { get; set; }
    }
}
