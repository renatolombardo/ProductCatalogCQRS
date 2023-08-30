using MediatR;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Queries;

public class GetProductbyIdQuery : IRequest<Product>
{
    public int Id { get; set; }
}
