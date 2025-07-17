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
}