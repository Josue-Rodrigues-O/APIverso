using APIverso.Domain.Enums;
using APIverso.Domain.Exceptions;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace APIverso.Api.Grpc.Interceptors
{
    public class ErrorHandlingInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (DomainFailureException ex)
            {
                Status status = new(MapStatusCode(ex.Failure.Type), ex.Failure.Title);
                throw new RpcException(status);
            }
            catch (Exception ex)
            {
                Status status = new(StatusCode.Internal, ex.Message);
                throw new RpcException(status);
            }
        }

        private static StatusCode MapStatusCode(FailureTypeEnum failureType)
        {
            return failureType switch
            {
                FailureTypeEnum.NOT_FOUND => StatusCode.NotFound,
                FailureTypeEnum.VALIDATION_ERROR => StatusCode.InvalidArgument,
                _ => StatusCode.Internal
            };
        }
    }
}