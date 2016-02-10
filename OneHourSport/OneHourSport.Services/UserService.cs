namespace OneHourSport.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using System;
    using Data.Repositories;

    public class UserService : IUserService
    {
        private IRepository<User> users;

        public UserService(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetById(string id)
        {
            return this.users.All().Where(u => u.Id == id);
        }

        public IQueryable<User> GetByUsername(string username)
        {
            return this.users.All().Where(u => u.UserName == username);
        }

        public void UpdateUserComplex(User user)
        {
            this.users.Update(user);
        }
    }
}
