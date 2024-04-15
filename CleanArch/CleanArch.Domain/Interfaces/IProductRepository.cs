using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetProducts();

    Task<Product?> GetProductById(int id);   

    Task AddProduct(Product product);
    Task UpdateProduct(Product updateProduct, int id);
    Task DeleteProduct(int id);
}