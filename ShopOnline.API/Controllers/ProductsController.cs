using Microsoft.AspNetCore.Mvc;

using ShopOnline.API.Application.Features.Products.Queries.ProductQueries;

namespace ShopOnline.API.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class ProductsController : ShopOnlineController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet, ActionName("get-all-products")]
    public async Task<IActionResult> RetrieveAllProducts()
    {
        var respone = await Mediator.Send(new RetrieveAllProductsQuery());
        return NewResult(respone);
    }
}
