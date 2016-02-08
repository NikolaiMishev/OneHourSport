﻿namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; }

        public string ResieverId { get; set; }

        [Required]
        [ForeignKey("ResieverId")]

        public virtual User Resiever { get; set; }
    }
}
