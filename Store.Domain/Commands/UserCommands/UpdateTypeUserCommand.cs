using Store.Domain.Enums;
using Store.Domain.ValueObjects;
using Store.Domain.Entities.Contracts;
using Store.Shared.Commands.Interfaces;
using Store.Shared.Commands;

namespace Store.Domain.Commands.UserCommands;

public class UpdateTypeUserCommand : Command, ICommand
{
    public string ManagerEmail { get; set; } = "";
    public string ManagerPassword { get; set; } = "";
    public string EmployeeEmail { get; set; } = "";
    public int EmployeeType { get; set; }

    public void Validate()
    {
        var managerEmail = new Email(ManagerEmail);
        var employeeEmail = new Email(EmployeeEmail);
        AddNotifications(
            new UpdateTypeUserContract((EType)EmployeeType),
            managerEmail,
            employeeEmail
        );
    }
}