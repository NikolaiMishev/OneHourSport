namespace OneHourSport.Web.Models.HomeTop
{
    using Complex;
    using Field;
    using System.Collections.Generic;

    public class HomeTop
    {
        public IEnumerable<FieldDisplayViewModel> TopFields { get; set; }

        public IEnumerable<ComplexDisplayViewModel> TopComplexes { get; set; }

    }
}