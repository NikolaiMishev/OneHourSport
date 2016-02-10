﻿namespace OneHourSport.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class City
    {
        public City()
        {
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 3)]
        public string Name { get; set; }
    }
}