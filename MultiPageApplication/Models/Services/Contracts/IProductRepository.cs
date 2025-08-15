using MultiPageApplication.Models.DomainModels.ProductAggregates;

namespace MultiPageApplication.Models.Services.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> SelectAll();
        Task<Product> SelectById(Guid id);
        Task Insert(Product product);
        Task Update(Product product);
        //Task Delete(Guid id);
        Task Delete(Product product);
    }
}
