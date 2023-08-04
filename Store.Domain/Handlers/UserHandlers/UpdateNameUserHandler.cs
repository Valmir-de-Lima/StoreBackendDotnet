using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UpdateNameUserHandler : Handler, IHandler<UpdateNameUserCommand>
{

    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public UpdateNameUserHandler(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(UpdateNameUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        var claims = _tokenService.GetUserClaims();
        var link = claims.Identity!.Name;

        if (link == null)
        {
            AddNotification(link, "Identificacao do usuário não disponível");
            return new CommandResult(false, Notifications);
        }
        // Get user repository
        var user = await _repository.GetByLinkAsync(link);

        // Query user exist
        if (user == null)
        {
            AddNotification(link, "Usuário não cadastrado");
            return new CommandResult(false, Notifications);
        }

        user.Update(command.Name);

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }
}