namespace OneHourSport.Services
{
    using OneHourSport.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OneHourSport.Models;
    using Data.Repositories;

    public class OccupiedHourService : IOccupiedHourService
    {
        private IRepository<OccupiedHour> hours;

        private IRepository<User> users;
        
        private IRepository<SportField> fields;


        public OccupiedHourService(IRepository<OccupiedHour> hours, IRepository<SportField> fields, IRepository<User> users)
        {
            this.fields = fields;
            this.users = users;
            this.hours = hours;
        }

        public void Create(DateTime date, int hourFrom, string occupiedByUserName, int fieldId)
        {
            var field = this.fields.GetById(fieldId);

            var occupiedBy = this.users
                .All()
                .Where(x => x.UserName == occupiedByUserName)
                .FirstOrDefault();


            var occHour = new OccupiedHour
            {
                Date = date,
                HourFrom = hourFrom,
                HourTo = hourFrom + 1,
                OccupiedBy = occupiedBy,
                SportField = field
            };

            this.hours.Add(occHour);
            this.hours.SaveChanges();
        }

        public IQueryable<OccupiedHour> GetAllByFieldId(int id)
        {
            throw new NotImplementedException();
        }

        public OccupiedHour GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
