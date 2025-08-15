namespace MultiPageApplication.ApplicationServices.Dtos.ProductDtos
{
    public class Delete_Product_Dto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ProductDescription { get; set; }
        //public int Price { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
