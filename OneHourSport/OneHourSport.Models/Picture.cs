namespace OneHourSport.Models
{
    using System;

    public class Picture
    {
        public Picture()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Path { get; set; }
    }
}
