using AutoMapper;

namespace ShopOnline.API.Application.Responses;

public interface IResponseHandler
{
    public IUnitOfWork Context { get; }
    public IMapper Mapper { get; }
}
