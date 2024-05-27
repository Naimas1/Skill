using MyApp.Models;

namespace MyApp.Services4
{
    internal interface IInfoService
    {
        List<PersonSkill>? GetById(int personId);
        void Update(List<PersonSkill> person);
    }
}