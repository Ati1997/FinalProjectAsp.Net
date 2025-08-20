using MultiPageApplication.Models.DomainModels.ProductAggregates;
using ResponseFramework;

namespace MultiPageApplication.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<IResponse<List<Product>>> SelectAll();
        Task<IResponse<Product>> SelectById(Guid id);
        Task<IResponse<Product>> Insert(Product product);
        Task<IResponse<Product>> Update(Product product);
        Task<IResponse<Product>> Delete(Product product);

    }
}
