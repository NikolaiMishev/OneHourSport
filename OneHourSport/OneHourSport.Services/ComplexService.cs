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

        public ComplexService(IRepository<SportComplex> complexes)
        {
            this.complexes = complexes;
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

        public IQueryable<SportComplex> GetByFieldId(int fieldId)
        {
            //TODO make the right querry
            return this.complexes.All();
        }

        public void Update(SportComplex complex)
        {
            this.complexes.Update(complex);
            this.complexes.SaveChanges();
        }
    }
}
