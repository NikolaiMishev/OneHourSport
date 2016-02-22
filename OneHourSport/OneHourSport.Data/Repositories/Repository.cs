namespace OneHourSport.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models.Contracts;
    
    public class Repository<T> : IRepository<T>
       where T : class, IDeletableEntity, IAuditInfo
    {
        public Repository(IOneHourSportDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected IOneHourSportDbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable().Where(x => !x.IsDeleted);
        }

        public virtual T GetById(object id)
        {
            // TODO something is funny around here

            var result = this.DbSet.Find(id);
            if (result.IsDeleted)
            {
                return null;
            }

            return result;
        }

        public virtual void Add(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            entity.ModifiedOn = DateTime.UtcNow;
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void HardDelete(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void HardDelete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.HardDelete(entity);
            }
        }

        public virtual T Attach(T entity)
        {
            return this.Context.Set<T>().Attach(entity);
        }

        public virtual void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;

            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
