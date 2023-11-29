using System.Security.Claims;
using Microsoft.Extensions.Options;
using N76_HomeTask.Domain.Constants;

namespace N76_HomeTask.Domain.Brokers;

public class RequestedUserContextProvider(IHttpContextAccessor accessor,
    IOptions<RequestedUserContextSettings> options) : IRequestedUserContextProvider
{
    public Guid GetUserIdAsync(CancellationToken cancellationToken = default)
    {
        var user = accessor.HttpContext.User.Claims.FirstOrDefault(claim=>claim.Type ==ClaimsConstant.UserId).Value;

        return user is not null ? Guid.Parse(user) : options.Value.SystemUserId;

    }
}