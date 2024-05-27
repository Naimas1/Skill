using MyApp.Models;

namespace MyApp.Services1
{
    public interface ISkillService
    {
        List<Skill> GetAllSkills();
        Skill GetSkillById(int id);
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
