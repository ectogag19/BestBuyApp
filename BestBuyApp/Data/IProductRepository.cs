using BestBuyApp.Models;

namespace BestBuyApp.Data;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public Product GetProduct(int id);
}