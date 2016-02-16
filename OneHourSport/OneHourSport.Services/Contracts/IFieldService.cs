namespace OneHourSport.Services.Contracts
{
    using Common.Constants;
    using Models;
    using System.Linq;

    public interface IFieldService
    {
        IQueryable<SportField> GetAll();

        IQueryable<SportField> GetTopThree();

        IQueryable<SportField> GetAllByCategory(SportCategory category, int page = 1);
        
        IQueryable<SportField> GetById(int id);

        int Create(SportField field);

        void Update(SportField field);
    }
}
