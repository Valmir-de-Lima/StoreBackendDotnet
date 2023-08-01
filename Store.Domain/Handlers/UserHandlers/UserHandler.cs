using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UserHandler : Handler,
    IHandler<CreateUserCommand>,
    IHandler<UpdateUserCommand>,
    IHandler<DeleteUserCommand>,
    IHandler<LoginUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly ITokenService _tokenService;

    public UserHandler(IUserRepository repository, ITokenService tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ICommandResult> HandleAsync(CreateUserCommand command)
    {
        return await new CreateUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(UpdateUserCommand command)
    {
        return await new UpdateUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(DeleteUserCommand command)
    {
        return await new DeleteUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(string command)
    {
        return await new GetUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(LoginUserCommand command)
    {
        return await new LoginUserHandler(_repository, _tokenService).HandleAsync(command);
    }
}