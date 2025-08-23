using MultiPageApplication.ApplicationServices.Dtos.ProductDtos;

namespace MultiPageApplication.ApplicationServices.Dtos.CategoryDtos
{
    public class GetById_Category_Dto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? CategoryDescription { get; set; }
        public List<GetById_Product_Dto>? Products { get; set; } = new List<GetById_Product_Dto>();
    }
}
