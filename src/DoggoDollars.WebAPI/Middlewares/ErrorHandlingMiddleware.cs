using Domain.Exceptions;
using System.Net;

namespace DoggoDollars.WebAPI.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            ErrorModel error = await GetExceptionResponseAsync(ex);
            await HandleExceptionAsync(context, error);
            return;
        }
    }

    private Task<ErrorModel> GetExceptionResponseAsync(Exception exception)
    {
        int statusCode;

        switch (exception)
        {
            case AccountNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                break;
            case InsufficientFundsException:
                statusCode = (int)HttpStatusCode.BadRequest;
                break;
            case InvalidAmountException:
                statusCode = (int)HttpStatusCode.BadRequest;
                break;
            case UserNotFoundException:
                statusCode = (int)HttpStatusCode.NotFound;
                break;
            case MaxAccountsException:
                statusCode = (int)HttpStatusCode.Forbidden;
                break;
            case UserExistsException:
                statusCode = (int)HttpStatusCode.Conflict;
                break;
            case SameAccountException:
                statusCode = (int)HttpStatusCode.BadRequest;
                break;
            default:
                statusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        string? message = exception.Message;

        return Task.FromResult(new ErrorModel()
        {
            Status = statusCode,
            Message = message,
        });
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, ErrorModel error)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = error.Status;

        await httpContext.Response.WriteAsJsonAsync<ErrorModel>(error);
    }
}

