using AutoMapper;

namespace ShopOnline.API.Application.Responses;

public class ResponseHandler : IResponseHandler
{
    public ResponseHandler(IUnitOfWork context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
    public IUnitOfWork Context { get; }
    public IMapper Mapper { get; }


    public static Response<TData> Success<TData>(
       TData data = null,
       object meta = null,
       string message = null,
       object errors = null) where TData : class => new(
           statusCode: HttpStatusCode.OK,
           isSucceeded: true,
           message: message == null ? "Success" : message,
           data: data,
           errors: errors,
           meta: meta);

    public static Response<TData> NotFound<TData>(
        TData data = null,
        object meta = null,
        string message = null,
        object errors = null) where TData : class => new(
            statusCode: HttpStatusCode.NotFound,
            isSucceeded: true,
            message: message,
            data: data,
            errors: errors,
            meta: meta);

    public static Response<TData> BadRequest<TData>(
        TData data = null,
        dynamic meta = null,
        string message = null,
        object errors = null) where TData : class => new(
            statusCode: HttpStatusCode.BadRequest,
            isSucceeded: false,
            message: message,
            data: data,
            errors: errors,
            meta: meta);

    public static Response<TData> UnAuthorized<TData>(
        TData data = null,
        dynamic meta = null,
        string message = null,
        List<dynamic> errors = null) where TData : class =>
        new(
            statusCode: HttpStatusCode.Unauthorized,
            isSucceeded: false,
            message: message,
            data: data,
            errors: errors,
            meta: meta);

    public static Response<TData> InternalServerError<TData>(
        TData data = null,
        object meta = null,
        string message = null,
        List<dynamic> errors = null) where TData : class => new(
            statusCode: HttpStatusCode.InternalServerError,
            isSucceeded: false,
            message: message,
            data: data,
            errors: errors,
            meta: meta);

    public static Response<TData> Conflict<TData>(
        TData data = null,
        object meta = null,
        string message = null,
        List<dynamic> errors = null) where TData : class => new(
            statusCode: HttpStatusCode.Conflict,
            isSucceeded: false,
            message: message,
            data: data,
            errors: errors,
            meta: meta);
}
