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

public class RecoveryPasswordUserHandler : Handler
{

    private readonly IUserRepository _repository;
    private readonly IEmailService _emailService;

    public RecoveryPasswordUserHandler(IUserRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<ICommandResult> HandleAsync(RecoveryPasswordUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        // Get user repository
        var user = await _repository.GetByEmailAsync(new Email(command.Email));

        // Query user exist
        if (user == null)
        {
            AddNotification("command.Email", "Usuario não cadastrado");
            return new CommandResult(false, Notifications);
        }

        if (!_emailService.Send(user.Name, user.Email.Address, "Início da recuperação de senha", FormatEmailBody(user, command.GetUrlOfSite())))
        {
            AddNotification(command.GetUrlOfSite(), "Não foi possível enviar o email para recuperação de senha");
            return new CommandResult(false, Notifications);
        }

        user.Update(false);
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }

    private string FormatEmailBody(User user, string urlOfSite)
    {
        var body = $"Olá, <strong>{user.Name}</strong>! "
        + "<p>Clique <a href=\"" + urlOfSite + "/v1/users/login/recovery-password/" + user.Id + "\">aqui</a> para cadastrar uma nova senha.</p>";
        return body;
    }
}