using MyApp.Controllers;
using MyApp.Models;
using MyApp.Services;
using MyApp.Services1;

namespace MyApp.Controllers2
{
    public class PersonSkillController : Controller
    {
        private readonly IPersonSkillService _personSkillService;
        private readonly ISkillService _skillService;

        public object ViewBag { get; private set; }

        public PersonSkillController(IPersonSkillService personSkillService, ISkillService skillService)
        {
            _personSkillService = personSkillService;
            _skillService = skillService;
        }

        public IActionResult Index(int personId)
        {
            var skills = _personSkillService.GetAllPersonSkills(personId);
            ViewBag.PersonId = personId;
            return View(skills);
        }

        private IActionResult View(List<PersonSkill> skills)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(int personId)
        {
            ViewBag.PersonId = personId;
            ViewBag.Skills = _skillService.GetAllSkills();
            return View();
        }

        private IActionResult View(PersonSkill personSkill)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(int personId, PersonSkill personSkill)
        {
            if (ModelState.IsValid)
            {
                _personSkillService.AddPersonSkill(personId, personSkill);
                return RedirectToAction(nameof(Index), new { personId });
            }
            ViewBag.PersonId = personId;
            ViewBag.Skills = _skillService.GetAllSkills();
            return View(personSkill);
        }

        private IActionResult RedirectToAction(string v, object value)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int personId, int skillId)
        {
            var skills = _personSkillService.GetAllPersonSkills(personId);
            var personSkill = skills.FirstOrDefault(s => s.SkillId == skillId);
            if (personSkill == null)
            {
                return NotFound();
            }
            ViewBag.PersonId = personId;
            ViewBag.Skills = _skillService.GetAllSkills();
            return View(personSkill);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(int personId, PersonSkill personSkill)
        {
            if (ModelState.IsValid)
            {
                _personSkillService.UpdatePersonSkill(personId, personSkill);
                return RedirectToAction(nameof(Index), new { personId });
            }
            ViewBag.PersonId = personId;
            ViewBag.Skills = _skillService.GetAllSkills();
            return View(personSkill);
        }

        public IActionResult Delete(int personId, int skillId)
        {
            _personSkillService.DeletePersonSkill(personId, skillId);
            return RedirectToAction(nameof(Index), new { personId });
        }
    }
}
