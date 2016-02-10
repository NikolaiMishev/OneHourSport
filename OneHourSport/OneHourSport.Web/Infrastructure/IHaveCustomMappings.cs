namespace OneHourSport.Web.Infrastructure
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}