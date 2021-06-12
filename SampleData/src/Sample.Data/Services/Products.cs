using Sample.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Services
{
    public class Products : BaseService
    {
        public static IEnumerable<Product> GetProducts(int count = 35)
        {
            return Enumerable.Range(1, count).Select(i => new Product
            {
                Name = $"Product {i}",
                SupplierId = RandomGenerator.Next(1, 5),
                CategoryId = RandomGenerator.Next(1, 5),
                QuantityPerUnit = RandomGenerator.Next(0, i).ToString(),
                UnitPrice = Convert.ToDecimal(RandomGenerator.NextDouble() * 100),
                UnitsInStock = Convert.ToInt16(RandomGenerator.Next(1, 100)),
                UnitsOnOrder = Convert.ToInt16(RandomGenerator.Next(1, 100)),
                ReorderLevel = Convert.ToInt16(RandomGenerator.Next(5, 30)),
                Discontinued = i % 5 == 0,
            });
        }
    }
}
