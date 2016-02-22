namespace OneHourSport.Services.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IStatisticService
    {
        ICollection<int> GetYearlyStatistics(int year, string OwnerName);
    }
}
