namespace OneHourSport.Web.Models.Comment
{
    public class CommentRequestViewModel
    {
        public string Text { get; set; }

        public string CreatorId { get; set; }

        public int FieldId { get; set; }
    }
}