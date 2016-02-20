namespace OneHourSport.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRatingService
    {
        int GetRatingByFieldId(int fieldId);

        void CreateRating(int fieldId, string creatorUsername, int value);
    }
}
