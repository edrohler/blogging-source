using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Services
{
    public static class Context
    {
        public static Categories Categories = new();
        public static Customers Customers = new();
        public static Employees Employees = new();
        public static Products Products = new();
        public static Suppliers Suppliers = new();
    }
}
