using Microsoft.AspNetCore.Mvc;

using ShopOnline.API.Application.Features.Categories.Queries.CategoryQueries;

namespace ShopOnline.API.Controllers;
[Route("api/v1/[controller]/[action]")]
[ApiController]
public class CategoriesController : ShopOnlineController
{
    public CategoriesController(IMediator mediator) : base(mediator) { }

    [HttpGet, ActionName("get-all-categories")]
    public async Task<IActionResult> RetrieveAllCategories() =>
        NewResult(await Mediator.Send(new RetrieveAllCategoriesQuery()));
}
