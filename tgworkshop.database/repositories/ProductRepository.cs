using Microsoft.EntityFrameworkCore;
using tgworkshop.domain.models;
using tgworkshop.models.ProductModels;
namespace tgworkshop.database.repositories;

public class ProductRepository:IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Set<Product>().ToListAsync();
    }
    public async Task AddProduct(AddProductModel product)
    {
        try
        {

            var productInstance = new Product
            {
                CategoryId = product.CategoryId,
                Stock=product.Stock,
                Name = product.Name,
                Price = product.Price
            };

            await _context.Set<Product>().AddAsync(productInstance);
            await _context.SaveChangesAsync();            

        }
        catch (Exception exp)
        {
            //it redirect to errorhandler
            throw new Exception(exp.Message);
        }
    }
}
