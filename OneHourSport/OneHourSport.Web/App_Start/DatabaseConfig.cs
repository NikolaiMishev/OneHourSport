namespace OneHourSport.Web
{
    using OneHourSport.Data;
    using OneHourSport.Data.Migrations;
    using System.Data.Entity;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OneHourSportDbContext, Configuration>());
            OneHourSportDbContext.Create().Database.Initialize(true);
        }
    }
}