using Microsoft.EntityFrameworkCore;
using N70HomeTask.Application.Service;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Persistense.Repositories.UserRepositories;

namespace N70HomeTask.Infrastructure.Service;

public class UserService(IUserRespository userRespository) : IUserService
{
    public IQueryable<User> Get(Func<User, bool> predicate, bool asNoTracking = false)
    {
        return userRespository.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRespository.GetById(id,asNoTracking,cancellationToken);
    }

    public ValueTask<User?> GetByEmail(User user, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return new(userRespository.Get(user => true).Include(us=>us.Role)
            .FirstOrDefault(us => us.EmailAddress == user.EmailAddress));
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRespository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var updatingUser =await  userRespository.GetById(user.Id,true,cancellationToken);
        updatingUser.FirstName = user.FirstName;
        updatingUser.LastName = user.LastName;
        
        return await userRespository.UpdateAsync(updatingUser);
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var deletingUser = await GetById(user.Id,true,cancellationToken);

        return await userRespository.DeleteAsync(deletingUser, saveChanges, cancellationToken);


    }
}