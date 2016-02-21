namespace OneHourSport.Web.Areas.Admin.Models.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment lenght is not in bounds!")]
        public string Text { get; set; }
    }
}