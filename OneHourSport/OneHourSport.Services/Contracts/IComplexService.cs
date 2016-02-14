namespace OneHourSport.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface IComplexService
    {
        IQueryable<SportComplex> GetAll();

        IQueryable<SportComplex> GetById(int id);

        int Create(SportComplex complex);

        IQueryable<SportComplex> GetByFieldId(int fieldId);

        void Update(SportComplex complex);

    }
}
