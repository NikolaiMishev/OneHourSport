namespace OneHourSport.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data.Repositories;
    using Models;

    public class StatisticService : IStatisticService
    {
        private IRepository<User> users;

        public StatisticService(IRepository<User> users)
        {
            this.users = users;
        }

        public ICollection<int> GetYearlyStatistics(int year, string OwnerName)
        {
            var groupedHours = this.users
                .All()
                .Where(x => x.UserName == OwnerName)
                .Select(x => x.SportComplex)
                .SelectMany(x => x.Fields.SelectMany(r => r.OccupiedHours.Where(rx => rx.Date.Year == year).GroupBy(rs => rs.Date.Month)));

            var result = new List<int>();

            foreach (var group in groupedHours)
            {
                result.Add(group.Count());
            }

            return result;
        }
    }
}
