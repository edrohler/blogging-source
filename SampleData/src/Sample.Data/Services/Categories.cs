namespace Sample.Data.Services
{
    using Sample.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class Categories : BaseService
    {
        public static IEnumerable<Category> GetCategories()
        {
            return Enumerable.Range(1, 5).Select(i => new Category
            {
                Name = $"Category {i}",
                CreatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange)),
                UpdatedDate = StartDate.AddDays(RandomGenerator.Next(DateRange))
            });
        }
    }
}
