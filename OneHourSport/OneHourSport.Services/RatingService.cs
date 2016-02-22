namespace OneHourSport.Services
{
    using Contracts;
    using Data.Repositories;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RatingService : IRatingService
    {
        public IRepository<Rating> ratings;

        public IRepository<SportField> fields;


        public IUserService userService;
        
        public RatingService(IRepository<Rating> ratings, IUserService userService, IRepository<SportField> fields)
        {
            this.ratings = ratings;
            this.userService = userService;
            this.fields = fields;
        }

        public void CreateRating(int fieldId, string creatorUsername, int value)
        {
            var creator = this.userService.GetByUsername(creatorUsername).FirstOrDefault();
            var field = this.fields.All().Where(x => x.Id == fieldId).FirstOrDefault();

            var rating = new Rating
            {
                Creator = creator,
                SportField = field,
                Value = value
            };

            this.ratings.Add(rating);
            this.ratings.SaveChanges();

        }

        public int GetRatingByFieldId(int fieldId)
        {
            throw new NotImplementedException();
        }
    }
}
