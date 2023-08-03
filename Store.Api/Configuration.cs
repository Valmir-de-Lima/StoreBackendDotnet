using Store.Domain.Commands.UserCommands;

namespace Store;

public static class Configuration
{
    public const string MANAGER = "Manager";
    public const string EMPLOYEE = "Employee";
    public const string CUSTUMER = "Custumer";
    public static string JwtKey = "";

    public static CreateManagerCommand CreateManager(IConfiguration config)
    {
        var createManagerCommand = new CreateManagerCommand();

        config.GetSection("Manager").Bind(createManagerCommand);

        return createManagerCommand;
    }
}