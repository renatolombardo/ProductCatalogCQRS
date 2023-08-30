using MediatR;
using ProductCatalogCQRS.Data;
using ProductCatalogCQRS.Models;
using System.Runtime.CompilerServices;

namespace ProductCatalogCQRS.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Product>
{
    private readonly ProductDbContext _dbContext;

    public UpdateProductCommandHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == request.Id);

        if (product is null)
            return default;

        product.Name = request.Name;
        product.Description = request.Description;
        product.Category = request.Category;
        product.Price = request.Price;
        product.Active = request.Active;

        await _dbContext.SaveChangesAsync();

        return product;
    }
}
