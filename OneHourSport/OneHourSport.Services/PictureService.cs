namespace OneHourSport.Services
{
    using OneHourSport.Services.Contracts;
    using System;
    using System.Linq;
    using OneHourSport.Models;
    using Data.Repositories;
    public class PictureService : IPictureService
    {
        private IRepository<Picture> pictures;

        public PictureService(IRepository<Picture> pictures)
        {
            this.pictures = pictures;
        }

        public void Create(Picture picture)
        {
            this.pictures.Add(picture);
            this.pictures.SaveChanges();
        }

        public IQueryable<Picture> GetAll()
        {
            return this.pictures.All();
        }

        public Picture GetById(int id)
        {
            return this.pictures.All().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
