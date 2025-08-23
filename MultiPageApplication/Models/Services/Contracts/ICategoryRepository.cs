using MultiPageApplication.Models.DomainModels.CategoryAggregates;
using MultiPageApplication.Models.DomainModels.ProductAggregates;
using ResponseFramework;

namespace MultiPageApplication.Models.Services.Contracts
{
    public interface ICategoryRepository
    {
        Task<IResponse<List<Category>>> SelectAll();
        Task<IResponse<Category>> SelectById(Guid id);
        Task<IResponse<Category>> Insert(Category category);
        Task<IResponse<Category>> Update(Category category);
        Task<IResponse<Category>> Delete(Category category);
    }
}
