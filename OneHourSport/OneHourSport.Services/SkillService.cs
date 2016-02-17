namespace OneHourSport.Services
{
    using System.Linq;
    using Models;
    using OneHourSport.Services.Contracts;
    using Data.Repositories;
    using Common.Constants;
    using System;

    public class SkillService : ISkillService
    {
        private IRepository<Skill> skills;

        private IRepository<User> users;


        public SkillService(IRepository<Skill> skills, IRepository<User> users)
        {
            this.users = users;
            this.skills = skills;

        }

        public void Create(SportCategory category, string creatorUsername, string resieverUsername)
        {
            var creator = this.users.All().Where(x => x.UserName == creatorUsername).FirstOrDefault();
            var resiever = this.users.All().Where(x => x.UserName == resieverUsername).FirstOrDefault();
            var model = new Skill
            {
                Category = category,
                Creator = creator,
                Resiever = resiever
            };

            this.skills.Add(model);
            this.skills.SaveChanges();
        }

        public IQueryable<Skill> GetByUserName(string username)
        {
            return this.skills.All().Where(x => x.Resiever.UserName == username);
        }
    }
}
