using MediatR;
using Microsoft.Extensions.Logging;

namespace Ordering.Application.Behaviours
{
    //public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    //{
    //    private readonly ILogger<TRequest> _logger;

    //    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    //    {
    //        _logger = logger;
    //    }

    //    //public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    //    //{
    //    //    try
    //    //    {
    //    //        return await next();
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        var requestName = typeof(TRequest).Name;

    //    //        _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

    //    //        throw;
    //    //    }
    //    //}

    //    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            // Pre-processing: Log the request
    //            Console.WriteLine($"Handling {typeof(TRequest).Name}");
    //            Console.WriteLine($"Request Data: {request}");

    //            // Call the next handler in the pipeline
    //            var response = await next();

    //            // Post-processing: Log the response
    //            Console.WriteLine($"Handled {typeof(TRequest).Name}");
    //            Console.WriteLine($"Response Data: {response}");

    //            return response;
    //        }
    //        catch (Exception)
    //        {
    //            var requestName = typeof(TRequest).Name;

    //            _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

    //            throw;
    //        }
    //    }
    //}
}
