using System.Data;
using BestBuyApp.Models;
using Dapper;

namespace BestBuyApp.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM products;");
    }

    public Product GetProduct(int id)
    {
        return _connection.QuerySingleOrDefault<Product>("SELECT * FROM products WHERE ProductID = @id;", new { id });
    }

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @productID", 
            new { name = product.Name, price = product.Price, productID = product.ProductID });
    }
}