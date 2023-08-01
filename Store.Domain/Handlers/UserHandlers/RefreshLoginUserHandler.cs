using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class RefreshLoginUserHandler : Handler, IHandler<RefreshLoginUserCommand>
{

    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public RefreshLoginUserHandler(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(RefreshLoginUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var userClaims = _tokenService.GetClaimsFromExpiredToken(command.Token);
        var userName = userClaims.Identity!.Name;
        var savedRefreshToken = await _tokenService.GetRefreshTokenAsync(userName!);

        // Query refreshToken valid
        if (savedRefreshToken != command.RefreshToken)
        {
            AddNotification(command.RefreshToken, "Refresh Token inválido");
            return new CommandResult(false, Notifications);
        }


        // Procedure for refresh token
        var newToken = _tokenService.GenerateToken(userClaims.Claims);
        var newRefreshToken = _tokenService.GenerateRefreshToken();

        _tokenService.DeleteRefreshToken(userName!);
        await _tokenService.SaveRefreshTokenAsync(userName!, newRefreshToken);


        return new CommandResult(true, new
        {
            userName,
            newToken,
            newRefreshToken
        });
    }
}