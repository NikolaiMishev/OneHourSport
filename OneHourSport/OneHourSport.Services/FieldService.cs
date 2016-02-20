namespace OneHourSport.Services
{
    using Contracts;
    using System.Collections.Generic;
    using Models;
    using System;
    using System.Linq;
    using Data.Repositories;
    using Common.Constants;
    public class FieldService : IFieldService
    {
        private IRepository<SportField> fields;

        public FieldService(IRepository<SportField> fields)
        {
            this.fields = fields;
        }

        public int Create(SportField field)
        {
            //TODO Fix it

            this.fields.Add(field);
            this.fields.SaveChanges();

            return 0;
        }

        public IQueryable<SportField> GetAll()
        {
            //Add .Where(x => x.isApprooved)
            return this.fields.All();
        }

        public IQueryable<SportField> GetById(int id)
        {
            return this.fields.All().Where(x => x.Id == id);
        }

        public void Update(SportField field)
        {
            this.fields.Update(field);
            this.fields.SaveChanges();
        }
        
        public IQueryable<SportField> GetAllByCategory(SportCategory category)
        {
            var result = this.fields
                .All()
                .Where(x => x.Category == category)
                .OrderByDescending(x => (int)Math.Ceiling((double)x.Ratings.Sum(r => r.Value) / x.Ratings.Count()));

            return result;
        }

        public IQueryable<SportField> GetTopThree()
        {
            var result = this.fields
                .All()
                .OrderByDescending(x => (int)Math.Ceiling((double)x.Ratings.Sum(r => r.Value) / x.Ratings.Count()))
                .Skip(0)
                .Take(3);

            return result;
        }
    }
}
