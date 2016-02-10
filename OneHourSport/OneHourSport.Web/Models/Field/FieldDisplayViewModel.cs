namespace OneHourSport.Web.Models.Field
{
    using Infrastructure;
    using OneHourSport.Models;
    using System;

    public class FieldDisplayViewModel : IMapFrom<SportField>
    {
        public string Name { get; set; }
    }
}