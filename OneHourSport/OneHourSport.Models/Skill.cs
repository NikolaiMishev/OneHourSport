namespace OneHourSport.Models
{
    using System;

    public class Skill
    {
        public Skill()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public SportCategory Category { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public string ResieverId { get; set; }

        public virtual User Resiever { get; set; }

    }
}
