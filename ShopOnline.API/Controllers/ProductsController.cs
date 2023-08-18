using Microsoft.AspNetCore.Mvc;

using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

namespace ShopOnline.API.Controllers;
[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ProductsController : ShopOnlineController
{
    public ProductsController(IMediator mediator) : base(mediator) { }

    [HttpGet, ActionName("get-all-products")]
    public async Task<IActionResult> RetrieveAllProducts()
    {
        var respone = await Mediator.Send(new RetrieveAllProductsQuery());
        return NewResult(respone);
    }

    [HttpGet, ActionName("get-product-by-id")]
    public async Task<IActionResult> RetrieveProductById(int? id)
    {
        var response = await Mediator.Send(new RetrieveProductByIdQuery(id));
        return NewResult(response);
    }
}
