namespace OneHourSport.Services.Contracts
{
    using Models;
    using System;
    using System.Linq;

    public interface IComplexService
    {
        IQueryable<SportComplex> GetAll();

        IQueryable<SportComplex> GetTopThree();
        
        IQueryable<SportComplex> GetById(int id);

        int Create(SportComplex complex);

        SportComplex GetByFieldId(int fieldId);

        void Update(SportComplex complex);

    }
}
