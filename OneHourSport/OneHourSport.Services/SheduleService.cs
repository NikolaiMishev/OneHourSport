using OneHourSport.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneHourSport.Models;
using OneHourSport.Data.Repositories;

namespace OneHourSport.Services
{
    public class SheduleService : ISheduleService
    {
        private IRepository<OccupiedHour> hours;

        private IRepository<SportField> fields;

        public SheduleService(IRepository<OccupiedHour> hours, IRepository<SportField> fields)
        {
            this.hours = hours;
            this.fields = fields;
        }

        public IQueryable<OccupiedHour> GetAllHoursByDateAndField(DateTime date, int fieldId)
        {
            var result = this.hours.All().Where(r => r.SportFieldId == fieldId && r.Date == date);

            return result;
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void MakeAppointment()
        {
            throw new NotImplementedException();
        }
    }
}
