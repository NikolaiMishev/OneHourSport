namespace OneHourSport.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface ISheduleService
    {
        IQueryable<OccupiedHour> GetAllHoursByDateAndField(DateTime date, int fieldId);

        Comment GetById(int id);

        void MakeAppointment();
    }
}
