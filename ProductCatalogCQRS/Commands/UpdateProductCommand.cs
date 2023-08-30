using MediatR;
using ProductCatalogCQRS.Models;

namespace ProductCatalogCQRS.Commands;

public class UpdateProductCommand : IRequest<Product>
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool Active { get; set; } = true;
    public decimal Price { get; set; }
}
