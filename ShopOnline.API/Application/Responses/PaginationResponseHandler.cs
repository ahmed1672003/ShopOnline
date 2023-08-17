using AutoMapper;

using ShopOnline.Models.ResponseModels;

namespace ShopOnline.API.Application.Responses;

public class PaginationResponseHandler : IResponseHandler
{
    public PaginationResponseHandler(IUnitOfWork context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
    public IUnitOfWork Context { get; private set; }
    public IMapper Mapper { get; private set; }
    public PaginationResponse<TData> Success<TData>(
       TData data = null,
       dynamic meta = null,
       string message = null,
       object errors = null,
       int count = 0,
       int currentPage = 1,
       int pageSize = 10
        ) where TData : class => new(
           statusCode: HttpStatusCode.OK,
           isSucceeded: true,
           message: message,
           data: data,
           errors: errors,
           meta: meta,
           count: count,
           currentPage: currentPage,
           pageSize: pageSize);

    public PaginationResponse<TData> NotFound<TData>(
      TData data = null,
      dynamic meta = null,
      string message = null,
      object errors = null,
      int count = 0,
      int currentPage = 1,
      int pageSize = 10
       ) where TData : class => new(
          statusCode: HttpStatusCode.OK,
          isSucceeded: true,
          message: message,
          data: data,
          errors: errors,
          meta: meta,
          count: count,
          currentPage: currentPage,
          pageSize: pageSize);
}