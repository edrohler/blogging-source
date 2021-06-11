using Sample.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class Suppliers
    {
        public IEnumerable<Supplier> GenerateSupplierData()
        {
            return Enumerable.Range(1, 5).Select(i => new Supplier
            {
                Name = $"Supplier {i}"
            });
        }
    }
}
