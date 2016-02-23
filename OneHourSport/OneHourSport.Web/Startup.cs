using Microsoft.Owin;
using OneHourSport.Common.Constants;
using Owin;
using System.Reflection;

[assembly: OwinStartupAttribute(typeof(OneHourSport.Web.Startup))]
namespace OneHourSport.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());

            DatabaseConfig.Initialize();
        }
    }
}
