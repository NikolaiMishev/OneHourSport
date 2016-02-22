namespace OneHourSport.Data.Repositories
{
    using System;
    using System.Linq;
    using Models.Contracts;
    
    public interface IRepository<T> : IDisposable
        where T : class, IDeletableEntity, IAuditInfo
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();
        
        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void HardDelete(T entity);

        void HardDelete(object id);
        
        void Delete(T entity);

        T Attach(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
