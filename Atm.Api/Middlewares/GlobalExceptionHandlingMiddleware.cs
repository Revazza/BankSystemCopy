using BankSystem.Atm.Exceptions;
using BankSystem.Common.Models;
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
            HttpResultStatus status,
            Exception e)
        {
            _logger.LogError(e, e.Message);

            var problem = new HttpResult
            {
                Status = status,
                Message = e.Message,
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
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (CashOutLimitExceededException e)
            {
                await HandleExceptionAsync(httpContext, HttpResultStatus.BadRequest, e);
            }
            catch (CardIsDeprecatedException e)
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
