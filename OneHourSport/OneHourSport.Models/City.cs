namespace OneHourSport.Models
{
    using System;

    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}