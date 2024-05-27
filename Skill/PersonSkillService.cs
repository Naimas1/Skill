using System.Collections.Generic;
using System.Linq;
using MyApp.Models;

namespace MyApp.Services4
{
    public class PersonSkillService(IInfoService infoService) : IPersonSkillService, IEquatable<PersonSkillService?>
    {
        private readonly IInfoService _infoService = infoService;

        public List<PersonSkill> GetAllPersonSkills(int personId)
        {
            var person = _infoService.GetById(personId);
            return person?.Skills ?? new List<PersonSkill>();
        }

        public void AddPersonSkill(int personId, PersonSkill personSkill)
        {
            var person = _infoService.GetById(personId);
            if (person != null)
            {
                object value = person.Skills.Add(personSkill);
                _infoService.Update(person);
            }
        }

        public void UpdatePersonSkill(int personId, PersonSkill personSkill)
        {
            var person = _infoService.GetById(personId);
            if (person != null)
            {
                var existingSkill = person.Skills.FirstOrDefault(s => s.SkillId == personSkill.SkillId);
                if (existingSkill != null)
                {
                    existingSkill.ProficiencyLevel = personSkill.ProficiencyLevel;
                    _infoService.Update(person);
                }
            }
        }

        public void DeletePersonSkill(int personId, int skillId)
        {
            var person = _infoService.GetById(personId);
            if (person != null)
            {
                var skill = person.Skills.FirstOrDefault(s => s.SkillId == skillId);
                if (skill != null)
                {
                    person.Skills.Remove(skill);
                    _infoService.Update(person);
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as PersonSkillService);
        }

        public bool Equals(PersonSkillService? other)
        {
            return other is not null &&
                   EqualityComparer<IInfoService>.Default.Equals(_infoService, other._infoService);
        }
    }
}
