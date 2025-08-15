using Microsoft.EntityFrameworkCore;
using MultiPageApplication.Models.DomainModels.ProductAggregates;
using MultiPageApplication.Models.Services.Contracts;

namespace MultiPageApplication.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MultiPageDbContext _context;

        #region [-Constractor-]
        public ProductRepository(MultiPageDbContext context)
        {
            _context = context;
        } 
        #endregion


        #region [-Insert-]
        public async Task Insert(Product product)
        {
            //todo:use response framework
            if (product == null) { return; }
           
                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();

                }
                catch (Exception)
                {

                    throw;
                }
               
            
        }
        #endregion

        #region [-Update-]
        public async Task Update(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    throw;
                }
                
        }
        #endregion

        #region [-Delete-]
        public async Task Delete(Product product)
        {

                try
                {
                    if (product != null)
                    {
                        _context.Attach(product); 
                        _context.Remove(product);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
               
            
        }
        #endregion

        #region [-selectAll-]
        public async Task<List<Product>> SelectAll()
        {
                try
                {
                    var products = await _context.Product.ToListAsync();
                    await _context.SaveChangesAsync();
                    return products;

                }
                catch (Exception)
                {

                    throw;
                }
            
        }
        #endregion

        #region [-SelectById-]
        public async Task<Product> SelectById(Guid id)
        {
            if (id == Guid.Empty) { return null; }
            
                try
                {
                    var product = await _context.Product.FindAsync(id);
                    return product;


                }
                catch (Exception ex)
                {

                    return null;
                }

        }
        #endregion

        //private method

    }
}
