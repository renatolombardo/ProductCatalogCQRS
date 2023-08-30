using MediatR;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Commands;

public class DeleteProductCommand : IRequest<Product>
{
    public int Id { get; set; }
}
