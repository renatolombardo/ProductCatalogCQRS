using MediatR;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
}
