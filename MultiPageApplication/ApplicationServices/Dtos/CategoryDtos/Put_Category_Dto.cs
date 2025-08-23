namespace MultiPageApplication.ApplicationServices.Dtos.CategoryDtos
{
    public class Put_Category_Dto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? CategoryDescription { get; set; }
    }
}
