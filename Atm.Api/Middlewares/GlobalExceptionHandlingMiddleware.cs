using ATM.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace ATM.Api.Middlewares
{
    public class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandlingMiddleware(
            ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        private async Task HandleExceptionAsync(
            HttpContext httpContext,
            HttpStatusCode status,
            Exception e)
        {
            _logger.LogError(e, e.Message);

            var problem = new ProblemDetails
            {
                Detail = e.Message,
                Status = (int)status
            };

            httpContext.Response.StatusCode = (int)status;

            httpContext.Response.ContentType = "application/json";

            var json = JsonConvert.SerializeObject(problem);

            await httpContext.Response.WriteAsync(json);

        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (ArgumentException e)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, e);
            }
            catch (CashOutLimitExceededException e)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, e);
            }
            catch (CardIsDeprecatedException e)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.Gone, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, e);
            }
        }
    }

}
