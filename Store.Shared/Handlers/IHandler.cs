using Store.Shared.Commands.Interfaces;

namespace Store.Shared.Handlers;
public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> HandleAsync(T command);
}
