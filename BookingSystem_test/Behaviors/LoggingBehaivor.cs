using MediatR;

namespace API.Behaviors;

public class LoggingBehaivor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehaivor<TRequest, TResponse>> _logger;

    public LoggingBehaivor(ILogger<LoggingBehaivor<TRequest, TResponse>> logger)
    {
         _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Handing {typeof(TRequest).Name}");

        var responce = await next();
        _logger.LogInformation($"Handed {typeof(TResponse).Name}");

        return responce;
    }
}
