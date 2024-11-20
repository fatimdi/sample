using tgworkshop.domain.models;
using tgworkshop.models.ProductModels;
using tgworkshop.models.ResponseModels;

namespace tgworkshop.database.repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task AddProduct(AddProductModel product);
}
