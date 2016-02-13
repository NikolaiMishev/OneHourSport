namespace OneHourSport.Services.Contracts
{
    using OneHourSport.Models;
    using System.Linq;

    public interface ICommentService
    {
        IQueryable<Comment> GetAllByFieldId(int id);

        Comment GetById(int id);

        void Create(string text, string creatorUserName, int fieldId);
    }
}
