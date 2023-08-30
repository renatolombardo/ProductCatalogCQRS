using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductCatalogCQRS.Data;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Queries;

public class GetProductdQueryHandler : IRequestHandler<GetProductbyIdQuery, Product>
{

    private readonly ProductDbContext _context;

    public GetProductdQueryHandler(ProductDbContext context)
    {
        _context = context;
    }

    public async Task<Product> Handle(GetProductbyIdQuery request, CancellationToken cancellationToken) =>
        await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
}
