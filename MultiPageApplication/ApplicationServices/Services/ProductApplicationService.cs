using Humanizer;
using MultiPageApplication.ApplicationServices.Dtos.ProductDtos;
using MultiPageApplication.ApplicationServices.Services.Contracts;
using MultiPageApplication.Models.DomainModels.ProductAggregates;
using MultiPageApplication.Models.Services.Contracts;

namespace MultiPageApplication.ApplicationServices.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        private readonly IProductRepository _productRepository;

        #region [-Constructor]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        } 
        #endregion

        #region [-Delete-]
        public async Task Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Invalid product ID");

            var product = await _productRepository.SelectById(id);
            if (product == null)
                throw new InvalidOperationException("Product not found");

            await _productRepository.Delete(product);

        } 
        #endregion

        #region [-Get-]
        public async Task<GetById_Product_Dto> Get(Guid id)
        {
            //Task<Product> SelectById(Guid id);

            if (id == Guid.Empty)
                throw new ArgumentException("Invalid ID");

            var product = await _productRepository.SelectById(id);
            if (product == null)
                throw new InvalidOperationException("Product not found");

            return new GetById_Product_Dto
            {
                Id = product.Id,
                Title = product.Title,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice
            };
        } 
        #endregion

        #region [-GetAll-]
        public async Task<List<GetAll_Product_Dto>> GetAll()
        {
            var products = await (_productRepository.SelectAll());
            if (products == null || !products.Any())
            {
                return new List<GetAll_Product_Dto>();
            }
            var getAll_Product_Dto = new List<GetAll_Product_Dto>();

            foreach (var product in products)
            {
                var dto = new GetAll_Product_Dto
                {
                    Id = product.Id,
                    Title = product.Title,
                    ProductDescription = product.ProductDescription,
                    UnitPrice = product.UnitPrice
                };
                getAll_Product_Dto.Add(dto);
            }
            return getAll_Product_Dto;

        } 
        #endregion

        #region [-Post-]
        public async Task Post(Post_Product_Dto product_Dto)
        {
            if (product_Dto == null)
                throw new ArgumentNullException(nameof(product_Dto));

            if (string.IsNullOrWhiteSpace(product_Dto.Title))
                throw new ArgumentException("Title is required");

            if (product_Dto.UnitPrice <= 0)
                throw new ArgumentException("Price must be greater than zero");

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = product_Dto.Title,
                ProductDescription = product_Dto.ProductDescription,
                UnitPrice = product_Dto.UnitPrice
            };
            //Task Insert(Product product);

            await _productRepository.Insert(product);
        } 
        #endregion

        #region [-Put-]
        public async Task Put(Put_Product_Dto product_Dto)
        {
            if (product_Dto == null || product_Dto.Id == Guid.Empty)
                throw new ArgumentException("Invalid product data");

            var product = await _productRepository.SelectById(product_Dto.Id);
            if (product == null)
                throw new InvalidOperationException("Product not found");


            product.Title = product_Dto.Title;
            product.ProductDescription = product_Dto.ProductDescription;
            product.UnitPrice = product_Dto.UnitPrice;

            await _productRepository.Update(product);
        } 
        #endregion
    }
}
