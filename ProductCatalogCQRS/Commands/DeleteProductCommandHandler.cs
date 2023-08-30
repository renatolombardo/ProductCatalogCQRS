using MediatR;
using ProductCatalogCQRS.Data;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Product>
{
    private readonly ProductDbContext _dbContext;

    public DeleteProductCommandHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == request.Id);

        if (product is null)
            return default;

        _dbContext.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;

    }
}
