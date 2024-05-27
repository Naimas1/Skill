using MyApp.Models;
using MyApp.Services1;

namespace MyApp.Services2
{
    public class SkillService : ISkillService
    {
        private readonly List<Skill> skills;

        public SkillService()
        {
            skills = new List<Skill>
            {
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "ASP.NET Core" },
                new Skill { Id = 3, Name = "JavaScript" }
            };
        }

        public List<Skill> GetAllSkills() => skills;

        public Skill GetSkillById(int id) => skills.FirstOrDefault(s => s.Id == id);

        public void AddSkill(Skill skill)
        {
            skill.Id = skills.Any() ? skills.Max(s => s.Id) + 1 : 1;
            skills.Add(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            var existingSkill = skills.FirstOrDefault(s => s.Id == skill.Id);
            if (existingSkill != null)
            {
                existingSkill.Name = skill.Name;
            }
        }

        public void DeleteSkill(int id)
        {
            var skill = skills.FirstOrDefault(s => s.Id == id);
            if (skill != null)
            {
                skills.Remove(skill);
            }
        }
    }
}
