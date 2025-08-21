using System.ComponentModel.DataAnnotations;
using static MultiPageApplication.Models.DomainModels.CategoryAggregates.Category;
using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPageApplication.Models.DomainModels.ProductAggregates
{
    public class Product
    {

        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? ProductDescription { get; set; }
        public decimal UnitPrice { get; set; }

        
        //[Required]
        //public Guid CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }
    }
}
