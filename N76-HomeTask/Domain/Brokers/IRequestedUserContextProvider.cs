namespace N76_HomeTask.Domain.Brokers;

public interface IRequestedUserContextProvider
{
    Guid GetUserIdAsync(CancellationToken cancellationToken = default);
}