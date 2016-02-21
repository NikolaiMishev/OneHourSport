namespace OneHourSport.Web.Areas.Admin.Models.Complex
{
    using Infrastructure;
    using OneHourSport.Models;
    using AutoMapper;

    public class ComplexViewModel : IMapFrom<SportComplex>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int WorkHourFrom { get; set; }
        
        public int WorkHourTo { get; set; }
                
        public string Address { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportComplex, ComplexViewModel>("ComplexViewModel")
               .ForMember(r => r.Description, opt => opt.MapFrom(r => r.Description.Length > 50 ? r.Description.Substring(0, 50) + "..." : r.Description))
               .ForMember(r => r.CityName, opt => opt.MapFrom(r => r.City.Name));
        }
    }
}