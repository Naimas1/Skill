using MyApp.Models;
using MyApp.Services1;

namespace MyApp.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            var skills = _skillService.GetAllSkills();
            return View(skills);
        }

        private IActionResult View(List<Skill> skills)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.AddSkill(skill);
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        private IActionResult View(Skill skill)
        {
            throw new NotImplementedException();
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(int id)
        {
            var skill = _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            return View(skill);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit(Skill skill)
        {
            if (ModelState.IsValid)
            {
                _skillService.UpdateSkill(skill);
                return RedirectToAction(nameof(Index));
            }
            return View(skill);
        }

        public IActionResult Delete(int id)
        {
            var skill = _skillService.GetSkillById(id);
            if (skill == null)
            {
                return NotFound();
            }
            _skillService.DeleteSkill(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
