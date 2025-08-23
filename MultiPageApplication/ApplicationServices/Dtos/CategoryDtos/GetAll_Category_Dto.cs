namespace MultiPageApplication.ApplicationServices.Dtos.CategoryDtos
{
    public class GetAll_Category_Dto
    {
        public List<GetById_Category_Dto> getById_Category_Dtos { get; set; } = new List<GetById_Category_Dto>();
    }
}
