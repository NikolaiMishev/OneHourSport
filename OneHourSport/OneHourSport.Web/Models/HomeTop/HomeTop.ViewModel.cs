namespace OneHourSport.Web.Models.HomeTop
{
    using OneHourSport.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class HomeTop
    {
        public IEnumerable<SportField> TopFields { get; set; }

        public IEnumerable<SportComplex> TopComplexes { get; set; }

    }
}