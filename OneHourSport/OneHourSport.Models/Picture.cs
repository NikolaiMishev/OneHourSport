namespace OneHourSport.Models
{
    using Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Picture : IDeletableEntity, IAuditInfo
    {
        public Picture()
        {
            this.CreatedOn = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public byte[] Content { get; set; }

        [Required]
        public string FileExtension { get; set; }
    }
}
