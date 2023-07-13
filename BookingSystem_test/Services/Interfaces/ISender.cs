using MediatR;

namespace API.Services.Interfaces;

public interface ISender
{
    Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    Task<object?> SendAsync(object request, CancellationToken cancellationToken = default);
}
