using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class GetUserHandler : Handler
{

    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public GetUserHandler(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(string linkUser)
    {

        var claims = _tokenService.GetUserClaims();
        var linkToken = claims.Identity!.Name;
        var manager = claims.IsInRole("Manager");

        if ((linkToken != linkUser) && (manager == false))
        {
            AddNotification(linkUser, "Informação indisponível");
            return new CommandResult(false, Notifications);
        }

        // Get user repository
        var user = await _repository.GetByLinkAsync(linkUser);

        // Query user exist
        if (user == null)
        {
            AddNotification(linkUser, "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        return new CommandResult(true, new UserCommandResult(user));
    }
}