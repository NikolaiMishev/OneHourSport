namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Skill
    {
        public Skill()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public SportCategory Category { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        public string ResieverId { get; set; }

        [Required]
        public virtual User Resiever { get; set; }

    }
}
