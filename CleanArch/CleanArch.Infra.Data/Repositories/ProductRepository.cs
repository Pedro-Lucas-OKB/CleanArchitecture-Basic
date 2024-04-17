using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context = default!;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task AddProduct(Product product)
    {
        if (_context.Products != null)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateProduct(Product updateProduct, int id)
    {
        if(_context.Products != null) 
        {
            var product = await _context.Products.FindAsync(id);

            if(product != null) 
            {
                product.Name = updateProduct.Name;
                product.Description = updateProduct.Description;
                product.Price = updateProduct.Price;

                _context.Update(product);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task DeleteProduct(int id)
    {
        if(_context.Products != null) 
        {
            var product = await _context.Products.FindAsync(id);

            if(product != null) 
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}