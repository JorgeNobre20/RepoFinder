using RepoFinder.Business.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using RepoFinder.Api.DTOs;

namespace RepoFinder.Api.ExceptionHandler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var errorResponse = GetExceptionDetails(exception);
            httpContext.Response.StatusCode = errorResponse.StatusCode;

            await httpContext.Response
                .WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }

        private static ErrorResponse GetExceptionDetails(Exception exception)
        {
            var exceptionInfo = exception switch
            {
                NoContentException => new { Message = exception.Message, StatusCode = StatusCodes.Status404NotFound },
                InvalidResultException => new { Message = exception.Message, StatusCode = StatusCodes.Status400BadRequest },
                InvalidInfoException => new { Message = exception.Message, StatusCode = StatusCodes.Status400BadRequest },
                _ => new { Message = "Erro interno no servidor", StatusCode = StatusCodes.Status500InternalServerError }
            };

            return new ErrorResponse
            {
                Message = exceptionInfo.Message,
                StatusCode = exceptionInfo.StatusCode,
            };
        
        }
    }
}