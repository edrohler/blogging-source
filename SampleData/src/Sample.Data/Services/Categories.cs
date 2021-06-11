using Sample.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
    public class Categories
    {
        public IEnumerable<Category> GenerateCategories()
        {
            return Enumerable.Range(1, 5).Select(i => new Category
            {
                Name = $"Category {i}"
            });
        }
    }
}
