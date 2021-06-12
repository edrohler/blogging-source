using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Services
{
    public class BaseService
    {
        internal static Random RandomGenerator = new();
        internal static PersonNameGenerator PersonGenerator = new();
        internal static PlaceNameGenerator PlaceGenerator = new();
        internal static int DateRange = (DateTime.Today - new DateTime(DateTime.Today.Year - 18, 1, 1)).Days;
        internal static DateTime StartDate = new(DateTime.Today.Year - 18, 1, 1);
        internal static int VacationTotal = RandomGenerator.Next(80, 120);
        internal static string[] Genders =
        {
            "Male",
            "Female",
            "Other",
            "Unspecified"
        };
        internal static string[] Positions =
        {
            "CEO",
            "Developer",
            "Technical Support Engineer",
            "Sales Representative",
            "Sales Engineer",
            "Manager",
            "Customer Advocate",
            "IT Specialist",
            "President",
        };
    }
}
