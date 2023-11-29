using Microsoft.EntityFrameworkCore;
using N70HomeTask.Application.Service;
using N70HomeTask.Domain.Entities;
using N70HomeTask.Domain.Enums;

namespace N70HomeTask.Infrastructure.Service;

public class AuthService(IUserService userService, 
    IRoleService roleService,
    ITokenGeneratorService tokenGeneratorService) : IAuthService
{
    public async ValueTask<bool> RegisterAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var role = roleService.Get(role => true).FirstOrDefault();
        user.Id = Guid.Empty;
        user.Role = role;
        var newUser = await userService.CreateAsync(user);

        return user is not null;
    }

    public async ValueTask<string> LoginAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var loggedUser = await userService.GetByEmail(user,true,cancellationToken);

        return tokenGeneratorService.GenerateToken(loggedUser!);
    }

    public async ValueTask<User> GrandRoleAsync(Guid userId, UserRole role, bool saveChanges = true,
        CancellationToken cancellationToken = default)
    {
        var foundUser = await userService.GetById(userId,true,cancellationToken);
        var givenRole = await roleService.Get(role => role.RoleType.Equals(role)).FirstOrDefaultAsync();

        foundUser.Role = givenRole;

        return await userService.UpdateAsync(foundUser, saveChanges, cancellationToken);

    }
}