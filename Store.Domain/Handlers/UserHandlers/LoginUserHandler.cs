using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class LoginUserHandler : Handler, IHandler<LoginUserCommand>
{

    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public LoginUserHandler(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(LoginUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        // Build Value Objects
        var email = new Email(command.Email);

        // Get user repository
        var user = await _repository.GetByEmailAsync(email);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Email, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        if (!PasswordHasher.Verify(user.PasswordHash, command.Password))
        {
            AddNotification(command.Password, "Usuario ou senha inválidos");
            return new CommandResult(false, Notifications);
        }

        var token = _tokenService.GenerateToken(user);

        // Procedure for refresh token
        var refreshToken = _tokenService.GenerateRefreshToken();
        _tokenService.DeleteRefreshToken(user.Link);
        await _tokenService.SaveRefreshTokenAsync(user.Link, refreshToken);

        return new CommandResult(true, new
        {
            userName = user.Link,
            token,
            refreshToken
        });
    }
}