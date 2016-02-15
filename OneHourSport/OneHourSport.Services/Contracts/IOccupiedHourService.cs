namespace OneHourSport.Services.Contracts
{
    using OneHourSport.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOccupiedHourService
    {
        IQueryable<OccupiedHour> GetAllByFieldId(int id);

        OccupiedHour GetById(int id);

        void Create(DateTime date, int hourFrom, string OccupiedByUserName, int fieldId);
    }
}
