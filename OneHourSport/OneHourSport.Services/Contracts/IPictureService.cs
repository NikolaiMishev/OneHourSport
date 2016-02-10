namespace OneHourSport.Services.Contracts
{
    using OneHourSport.Models;
    using System;
    using System.Linq;

    public interface IPictureService
    {
        IQueryable<Picture> GetAll();

        Picture GetById(int id);

        void Create(Picture picture);
    }
}
