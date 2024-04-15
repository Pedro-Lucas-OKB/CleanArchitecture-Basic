using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IProductRepository repository)
    {
        _mapper = mapper;
        _productRepository = repository;
    }

    public async Task<ProductViewModel?> GetProductById(int id)
    {
        var product = await _productRepository.GetProductById(id);
        return _mapper.Map<ProductViewModel>(product);
    }

    public async Task<IEnumerable<ProductViewModel>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        return _mapper.Map<IEnumerable<ProductViewModel>>(products);
    }

    public async Task AddProduct(ProductViewModel product)
    {
        var mapProduct = _mapper.Map<Product>(product);
        await _productRepository.AddProduct(mapProduct);
    }

    public async Task UpdateProduct(ProductViewModel updateProduct, int id)
    {
        var mapProduct = _mapper.Map<Product>(updateProduct);

        var product = _productRepository.GetProductById(id).Result;

        if(product != null) {
            await _productRepository.UpdateProduct(mapProduct, id);
        }
    }

    public async Task DeleteProduct(int id)
    {
        var product = _productRepository.GetProductById(id).Result;

        if(product != null) {
            await _productRepository.DeleteProduct(id);
        }
    }
}