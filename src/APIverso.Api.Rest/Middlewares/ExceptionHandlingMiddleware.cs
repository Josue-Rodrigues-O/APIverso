using System.Net;
using System.Text.Json;
using APIverso.Domain.Enums;
using APIverso.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APIverso.Api.Rest.Middlewares
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ProblemDetailsFactory problemDetailsFactory)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (DomainFailureException ex)
            {
                var problem = problemDetailsFactory.CreateProblemDetails(
                    httpContext,
                    statusCode: (int)MapStatusCode(ex.Failure.Type),
                    title: ex.Failure.Title,
                    detail: ex.StackTrace
                );
                httpContext.Response.StatusCode = problem.Status ?? 500;
                httpContext.Response.ContentType = "application/problem+json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
            catch (Exception ex)
            {
                var problem = problemDetailsFactory.CreateProblemDetails(
                    httpContext,
                    statusCode: 500,
                    title: ex.Message,
                    detail: ex.StackTrace
                );
                httpContext.Response.StatusCode = problem.Status ?? 500;
                httpContext.Response.ContentType = "application/problem+json";
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problem));
            }
        }

        private static HttpStatusCode MapStatusCode(FailureTypeEnum failureType)
        {
            return failureType switch
            {
                FailureTypeEnum.NOT_FOUND => HttpStatusCode.NotFound,
                FailureTypeEnum.VALIDATION_ERROR => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}