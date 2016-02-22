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

        private IRepository<SportField> fields;

        private IRepository<User> users;

        public CommentService(IRepository<Comment> comments, IRepository<SportField> fields, IRepository<User> users)
        {
            this.comments = comments;
            this.users = users;
            this.fields = fields;
        }

        public void Create(string text, string creatorUserName, int fieldId)
        {
            var user = this.users.All().Where(x => x.UserName == creatorUserName).FirstOrDefault();

            var field = this.fields.All().Where(x => x.Id == fieldId).FirstOrDefault();
            var comment = new Comment
            {
                Creator = user,
                Field = field,
                Text = text
            };
            this.comments.Add(comment);
            this.fields.SaveChanges();
        }

        public IQueryable<Comment> GetAllByFieldId(int id)
        {
            // TODO Check it
            return this.comments.All().OrderByDescending(x => x.CreatedOn).Where(x => x.FieldId == id);
        }

        public Comment GetById(int id)
        {
            return this.comments.All().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
