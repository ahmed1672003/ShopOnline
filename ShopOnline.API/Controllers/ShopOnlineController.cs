using Microsoft.AspNetCore.Mvc;

namespace ShopOnline.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShopOnlineController : Controller
{
    public IMediator Mediator { get; private set; }
    public ShopOnlineController(IMediator mediator)
    {
        Mediator = mediator;
    }


    #region Results 
    public IActionResult NewResult<TData>(Response<TData> response) where TData : class
    {
        switch (response.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(response);

            case HttpStatusCode.NotFound:
                return new NotFoundObjectResult(response);

            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(response);

            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(response);

            case HttpStatusCode.Conflict:
                return new ConflictObjectResult(response);

            default:
                return new ObjectResult(response)
                {
                    StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError),
                };
        }
    }
    #endregion
}
