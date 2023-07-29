using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class UserHandler : Handler,
    IHandler<CreateUserCommand>,
    IHandler<UpdateUserCommand>,
    IHandler<DeleteUserCommand>
{
    private readonly IUserRepository _repository;

    public UserHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateUserCommand command)
    {
        return new CreateUserHandler(_repository).Handle(command);
    }

    public ICommandResult Handle(UpdateUserCommand command)
    {
        return new UpdateUserHandler(_repository).Handle(command);
    }

    public ICommandResult Handle(DeleteUserCommand command)
    {
        return new DeleteUserHandler(_repository).Handle(command);
    }
}