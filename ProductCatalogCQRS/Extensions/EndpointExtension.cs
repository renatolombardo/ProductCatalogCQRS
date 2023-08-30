using MediatR;
using ProductCatalogCQRS.Commands;
using ProductCatalogCQRS.Models;
using ProductCatalogCQRS.Queries;

namespace ProductCatalogCQRS.Extensions;

public static class EndpointExtension
{
    public static WebApplication ConfigureEndpoints(this WebApplication app)
    {
        app.MapGet("/product", async (IMediator _mediator) =>
        {
            try
            {
                var command = new GetAllProductsQuery();
                var response = await _mediator.Send(command);
                return response is not null ? Results.Ok(response) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapGet("/product/{:id}", async (IMediator _mediator, int id) =>
        {
            try
            {
                var command = new GetProductbyIdQuery { Id = id };

                var response = await _mediator.Send(command);

                return response is not null ? Results.Ok(response) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapPost("/product", async (IMediator _mediator, Product product) =>
        {
            try
            {
                var command = new CreateProductCommand
                {
                    Category = product.Category,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price
                };

                var response = _mediator.Send(command);

                return response is not null ? Results.Ok(response) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapPut("/product", async (IMediator _mediator, Product product) =>
        {
            try
            {
                var command = new UpdateProductCommand
                {
                    Active = product.Active,
                    Category = product.Category,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price,
                    Id = product.Id
                };

                var response = await _mediator.Send(command);

                return response is not null ? Results.Ok(response) : Results.NotFound(product.Description);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        app.MapDelete("/product", async (IMediator _mediator, int id) =>
        {
            try
            {
                var command = new DeleteProductCommand { Id = id };

                var response = await _mediator.Send(command);

                return response is not null ? Results.Ok(response) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }
        });

        return app;
    }
}
