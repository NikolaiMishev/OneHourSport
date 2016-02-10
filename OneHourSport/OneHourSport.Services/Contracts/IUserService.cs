namespace OneHourSport.Services.Contracts
{
    using System.Linq;
    using OneHourSport.Models;
    using System.Collections.Generic;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        IQueryable<User> GetById(string id);

        IQueryable<User> GetByUsername(string username);

        //void UpdateUser(string id, string username, string firstname, string lastname, string image);
    }
}
