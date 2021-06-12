using Sample.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Services
{
    public class Suppliers : BaseService
    {
        public static IEnumerable<Supplier> GetSuppliers()
        {
            return Enumerable.Range(1, 5).Select(i => new Supplier
            {
                Name = $"Supplier {i}",
                CreatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                UpdatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange))
            });
        }
    }
}
