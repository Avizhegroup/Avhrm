using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Avhrm.Server.Intercepters;

public class LogInterceptor : Interceptor
{
    private readonly ILogger<LogInterceptor> _logger;

    public LogInterceptor(ILogger<LogInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
    {
        _logger.LogWarning($"Starting receiving call. Type: {MethodType.Unary}. Method: {context.Method}.");
     
        try
        {
            return await continuation(request, context);
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, ex.Message);

            throw;
        }
    }
}
