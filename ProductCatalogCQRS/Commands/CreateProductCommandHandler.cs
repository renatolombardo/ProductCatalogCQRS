using MediatR;
using ProductCatalogCQRS.Data;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly ProductDbContext _dbContext;

    public CreateProductCommandHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Category = request.Category,
            Description = request.Description,
            Name = request.Name,
            Price = request.Price
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }
}
