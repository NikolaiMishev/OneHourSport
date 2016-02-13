namespace OneHourSport.Services
{
    using OneHourSport.Services.Contracts;
    using System;
    using System.Linq;
    using OneHourSport.Models;
    using OneHourSport.Data.Repositories;

    public class CommentService : ICommentService
    {
        private IRepository<Comment> comments;

        public CommentService(IRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Create(Comment comment)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetAllByFieldId(int id)
        {
            // TODO Check it
            return this.comments.All().OrderByDescending(x => x.DateCreated).Where(x => x.FieldId == id);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }
    }
}
