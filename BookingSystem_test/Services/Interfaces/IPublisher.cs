using MediatR;

namespace API.Services.Interfaces;

public interface IPublisher
{
    Task PublishAsync(object notification, CancellationToken cancellationToken = default);

    Task PublishAsync<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification: INotification;
}
