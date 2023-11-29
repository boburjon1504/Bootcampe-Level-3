﻿using N76_HomeTask.Application.Services;
using N76_HomeTask.Domain.Models;
using N76_HomeTask.Persistense.Repositories;

namespace N76_HomeTask.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Func<User, bool> predicate, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<User?> GetById(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetById(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteAsync(user, saveChanges, cancellationToken);
    }
}