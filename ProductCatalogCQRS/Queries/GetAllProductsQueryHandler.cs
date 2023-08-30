using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalogCQRS.Data;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly ProductDbContext _dbContext;

    public GetAllProductsQueryHandler(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) =>
        await _dbContext.Products.ToListAsync();
    
}
