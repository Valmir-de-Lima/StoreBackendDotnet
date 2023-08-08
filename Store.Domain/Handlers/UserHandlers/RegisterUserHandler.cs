using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Entities;
using Store.Domain.Services;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.ValueObjects;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;

namespace Store.Domain.Handlers.UserHandlers;

public class RegisterUserHandler : Handler, IHandler<RegisterUserCommand>
{

    private readonly IUserRepository _repository;
    private readonly IEmailService _emailService;

    public RegisterUserHandler(IUserRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<ICommandResult> HandleAsync(RegisterUserCommand command)
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

        // Query e-mail exist
        if (await _repository.ExistsEmailAsync(email))
        {
            AddNotification(command.Email, "Email já cadastrado");
            return new CommandResult(false, Notifications);
        }

        // Build entity
        var user = new User(command.Name, email, command.Password, EType.Customer);

        // Send user email
        if (!_emailService.Send(command.Name, command.Email, "Bem vindo a Loja!", FormatEmailBody(command)))
        {
            AddNotification(FormatEmailBody(command), "Não foi possível enviar o email para registro");
            return new CommandResult(false, Notifications);
        }

        return new CommandResult(true, new UserCommandResult(user));
    }

    private string FormatEmailBody(RegisterUserCommand command)
    {
        var body = $"Olá, <strong>{command.Name}</strong>! Para confirmar o seu registro, clique no link a seguir: ";
        // + "<a href=\"https://localhost:7051/v1/users"
        // + "--header 'Content-Type: application/json' "
        // + "--data-raw '{\"name\": " + command.Name + ", \"email\": " + command.Email + ", \"password\": " + command.Password + "}'"
        // + "\" >";
        return body;
    }
}