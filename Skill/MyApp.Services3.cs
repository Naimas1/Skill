using System.Collections.Generic;
using MyApp.Models;

namespace MyApp.Services
{
    public interface IPersonSkillService
    {
        List<PersonSkill> GetAllPersonSkills(int personId);
        void AddPersonSkill(int personId, PersonSkill personSkill);
        void UpdatePersonSkill(int personId, PersonSkill personSkill);
        void DeletePersonSkill(int personId, int skillId);
    }
}
