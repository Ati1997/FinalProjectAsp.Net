using MultiPageApplication.Models.DomainModels.ProductAggregates;
using System.ComponentModel.DataAnnotations;

namespace MultiPageApplication.Models.DomainModels.CategoryAggregates
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
 }

