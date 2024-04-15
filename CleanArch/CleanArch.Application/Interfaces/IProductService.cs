using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> GetProducts();

    Task<ProductViewModel?> GetProductById(int id);   

    Task AddProduct(ProductViewModel product);
    Task UpdateProduct(ProductViewModel updateProduct, int id);
    Task DeleteProduct(int id);
}