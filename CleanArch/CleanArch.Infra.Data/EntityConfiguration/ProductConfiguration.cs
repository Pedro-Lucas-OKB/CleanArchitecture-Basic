using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infra.Data.EntityConfiguration;

// Define configurações para as entidades da camada Domain
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(2000);
        builder.Property(p => p.Price).HasPrecision(10, 2);

        builder.HasData(
            new Product {
                Name = "Tênis Olympikus",
                Description = "Tênis esportivo. Tamanho 43/44",
                Price = 199.90m,
            },
            new Product {
                Name = "Tênis Nike",
                Description = "Tênis para corrida. Tamanho 33/34",
                Price = 399.90m,
            },
            new Product {
                Name = "Sandália Havaianas",
                Description = "Sandália de uso casual. Tamanho 30/31",
                Price = 79.90m,
            }
        );
    }
}