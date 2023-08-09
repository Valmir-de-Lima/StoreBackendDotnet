using SecureIdentity.Password;
using Store.Domain.Commands.UserCommands;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Entities;
using Store.Shared.Commands;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Handlers;
using Store.Domain.Services;

namespace Store.Domain.Handlers.UserHandlers;

public class UpdateRecoveryPasswordUserHandler : Handler, IHandler<UpdateRecoveryPasswordUserCommand>
{

    private readonly IUserRepository _repository;
    private readonly IEmailService _emailService;

    public UpdateRecoveryPasswordUserHandler(IUserRepository repository, IEmailService emailService)
    {
        _repository = repository;
        _emailService = emailService;
    }

    public async Task<ICommandResult> HandleAsync(UpdateRecoveryPasswordUserCommand command)
    {
        // Fail Fast Validations
        command.Validate();
        if (!command.IsValid)
        {
            AddNotifications(command);
            return new CommandResult(false, Notifications);
        }

        // Get user repository
        var user = await _repository.GetByIdAsync(command.Id);

        // Query user exist
        if (user == null)
        {
            AddNotification(command.Id.ToString(), "Usuário não cadastrado");
            return new CommandResult(false, Notifications);
        }

        var passwordHash = PasswordHasher.Hash(command.Password);

        user.UpdatePassword(passwordHash);

        // Send user email
        if (!_emailService.Send(user.Name, user.Email.Address, "Conclusão da recuperação da senha", FormatEmailBody(user, command.GetUrlOfSite())))
        {
            AddNotification(command.GetUrlOfSite(), "Não foi possível enviar o email para registro");
            return new CommandResult(false, Notifications);
        }

        // Save database
        _repository.Update(user);

        return new CommandResult(true, new UserCommandResult(user));
    }

    private string FormatEmailBody(User user, string urlOfSite)
    {
        var body = $"Olá, <strong>{user.Name}</strong>! "
        + "<p>Clique <a href=\"" + urlOfSite + "/v1/users/login/active/" + user.Id + "\">aqui</a> para ativar a sua conta.</p>";
        return body;
    }
}