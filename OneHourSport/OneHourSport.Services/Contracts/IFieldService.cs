namespace OneHourSport.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IFieldService
    {
        IQueryable<SportField> GetAll();

        IQueryable<SportField> GetById(int id);

        int Create(SportField field);

        void Update(SportField field);
    }
}
