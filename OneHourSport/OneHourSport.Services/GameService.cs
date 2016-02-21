namespace OneHourSport.Services
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Data.Repositories;
    public class GameService : IGameService
    {
        private IRepository<OccupiedHour> hours;

        public GameService(IRepository<OccupiedHour> hours)
        {
            this.hours = hours;
        }

        public IQueryable<OccupiedHour> GetLastGames(string username)
        {
            var result = this.hours
                .All()
                .Where(x => x.OccupiedBy.UserName == username)
                .OrderByDescending(x => x.Date)
                .ThenByDescending(x => x.HourFrom);

            return result;
        }
    }
}
