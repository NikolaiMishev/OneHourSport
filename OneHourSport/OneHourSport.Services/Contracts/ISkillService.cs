namespace OneHourSport.Services.Contracts
{
    using Common.Constants;
    using OneHourSport.Models;
    using System.Linq;

    public interface ISkillService
    {
        IQueryable<Skill> GetByUserName(string username);

       void Create(SportCategory category, string creatorUsername, string resieverUsername);
    }
}
