using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Services;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UserHandler : Handler,
    IHandler<CreateUserCommand>,
    IHandler<CreateManagerCommand>,
    IHandler<UpdateUserCommand>,
    IHandler<UpdatePasswordUserCommand>,
    IHandler<UpdateTypeUserCommand>,
    IHandler<DeleteUserCommand>,
    IHandler<LoginUserCommand>,
    IHandler<RefreshLoginUserCommand>

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

    public async Task<ICommandResult> HandleAsync(CreateManagerCommand command)
    {
        return await new CreateManagerHandler(_repository).HandleAsync(command);
    }
    public async Task<ICommandResult> HandleAsync(string command)
    {
        return await new GetUserHandler(_repository, _tokenService).HandleAsync(command);
    }
    public async Task<ICommandResult> HandleAsync(UpdateUserCommand command)
    {
        return await new UpdateUserHandler(_repository).HandleAsync(command);
    }
    public async Task<ICommandResult> HandleAsync(UpdatePasswordUserCommand command)
    {
        return await new UpdatePasswordUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(UpdateTypeUserCommand command)
    {
        return await new UpdateTypeUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(DeleteUserCommand command)
    {
        return await new DeleteUserHandler(_repository).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(LoginUserCommand command)
    {
        return await new LoginUserHandler(_repository, _tokenService).HandleAsync(command);
    }

    public async Task<ICommandResult> HandleAsync(RefreshLoginUserCommand command)
    {
        return await new RefreshLoginUserHandler(_repository, _tokenService).HandleAsync(command);
    }
}