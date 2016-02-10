namespace OneHourSport.Services
{
    using Contracts;
    using System.Collections.Generic;
    using Models;
    using System;
    using System.Linq;
    using Data.Repositories;
    public class FieldService : IFieldService
    {
        private IRepository<SportField> fields;

        public FieldService(IRepository<SportField> fields)
        {
            this.fields = fields;
        }

        public int Create(SportField field)
        {
            throw new NotImplementedException();
        }

        public IQueryable<SportField> GetAll()
        {
            return this.fields.All();
        }

        public IQueryable<SportField> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SportField field)
        {
            throw new NotImplementedException();
        }
    }
}
