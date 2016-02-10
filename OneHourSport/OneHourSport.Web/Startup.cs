using Microsoft.Owin;
using OneHourSport.Common.Constants;
using Owin;

[assembly: OwinStartupAttribute(typeof(OneHourSport.Web.Startup))]
namespace OneHourSport.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperConfig.Execute();
            DatabaseConfig.Initialize();
        }
    }
}
