namespace OneHourSport.Web.Models.Complex
{
    using Infrastructure;
    using OneHourSport.Models;
    using System.Web;
    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ComplexEditViewModel : IMapFrom<SportComplex>
    {
        public HttpPostedFileBase EditPicture { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 100)]
        public string Description { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourFrom { get; set; }

        [Required]
        [Range(0, 24)]
        public int WorkHourTo { get; set; }

        [Required]
        public string Address { get; set; }
    }
}