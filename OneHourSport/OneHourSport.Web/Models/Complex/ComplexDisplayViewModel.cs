namespace OneHourSport.Web.Models.Complex
{
    using Infrastructure;
    using AutoMapper;
    using OneHourSport.Models;
    using Contracts;

    public class ComplexDisplayViewModel : IMapFrom<SportComplex>, IHaveCustomMappings, IPageable
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Name { get; set; }
        
        public int PictureId { get; set; }
        
        public int WorkHourFrom { get; set; }
        
        public int WorkHourTo { get; set; }
                
        public string Address { get; set; }

        public string CityName { get; set; }

        public int FieldsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<SportComplex, ComplexDisplayViewModel>("ComplexDisplay")
                .ForMember(r => r.PictureId, opts => opts.MapFrom(r => r.Picture.Id))
                .ForMember(r => r.CityName, opts => opts.MapFrom(r => r.City.Name))
                .ForMember(r => r.FieldsCount, opts => opts.MapFrom(r => r.Fields.Count));
        }
    }
}