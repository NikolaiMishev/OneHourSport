namespace OneHourSport.Services.Contracts
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IGameService
    {
        IQueryable<OccupiedHour> GetLastGames(string username);
    }
}
