
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using BankSystem.InternetBank.Exceptions;
using BankSystem.Common.Models;

namespace InternetBank.Api.Middlewares
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
            HttpResultStatus status,
            Exception e)
        {
            _logger.LogError(e, e.Message);

            var problem = new HttpResult
            {
                Message = e.Message,
                Status = status
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
            catch (CardAlreadyExistsException e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (UserAlreadyExistsException e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (ArgumentNullException e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (ArgumentException e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.Error, e);
            }
        }
    }
}
