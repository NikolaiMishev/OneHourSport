namespace OneHourSport.Services
{
    using System;
    using System.Linq;
    using Models;
    using OneHourSport.Services.Contracts;
    using Data.Repositories;

    public class ComplexService : IComplexService
    {
        private IRepository<SportComplex> complexes;

        private IRepository<SportField> fields;

        public ComplexService(IRepository<SportComplex> complexes, IRepository<SportField> fields)
        {
            this.fields = fields;
            this.complexes = complexes;
        }

        public IQueryable<SportComplex> GetTopThree()
        {
            return this.complexes
                .All()
                .OrderByDescending(r => r.Fields.Select(x => x.OccupiedHours.Count()).Sum())
                .Skip(0)
                .Take(3);
        }

        public int Create(SportComplex complex)
        {
            this.complexes.Add(complex);
            this.complexes.SaveChanges();

            return this.complexes.All().Where(x => x.Description == complex.Description).FirstOrDefault().Id;
            
        }

        public IQueryable<SportComplex> GetAll()
        {
            return this.complexes.All();
        }

        public IQueryable<SportComplex> GetById(int id)
        {
            return this.complexes.All().Where(x => x.Id == id);
        }

        public SportComplex GetByFieldId(int fieldId)
        {
            var result = this.fields.GetById(fieldId).SportComplex;
            return result;
        }

        public void Update(SportComplex complex)
        {
            this.complexes.Update(complex);
            this.complexes.SaveChanges();
        }
    }
}
