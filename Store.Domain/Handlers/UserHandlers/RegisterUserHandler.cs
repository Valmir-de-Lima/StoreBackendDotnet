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

        var passwordHash = PasswordHasher.Hash(command.Password);

        // Build entity
        var user = new User(command.Name, email, passwordHash, EType.Customer);

        // Send user email
        if (!_emailService.Send(command.Name, command.Email, "Bem vindo a Loja!", FormatEmailBody(user)))
        {
            AddNotification(FormatEmailBody(user), "Não foi possível enviar o email para registro");
            return new CommandResult(false, Notifications);
        }

        // Save database
        await _repository.CreateAsync(user);

        return new CommandResult(true, new UserCommandResult(user));
    }

    private string FormatEmailBody(User user)
    {
        var body = $"Olá, <strong>{user.Name}</strong>! "
        + "<p>Clique <a href=\"https://localhost:7051/v1/users/login/active/" + user.Id + "\">aqui</a> para ativar a sua conta.</p>";
        return body;
    }
}