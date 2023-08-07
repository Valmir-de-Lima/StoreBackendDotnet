using Store.Domain.Commands.UserCommands;

namespace Store;

public static class Configuration
{
    public const string MANAGER = "Manager";
    public const string EMPLOYEE = "Employee";
    public const string CUSTUMER = "Custumer";
    public static string JwtKey = "";
    public static SmtpConfiguration Smtp = new();

    public static CreateManagerCommand CreatePrimaryManager(IConfiguration config)
    {
        var createManagerCommand = new CreateManagerCommand();

        config.GetSection("Manager").Bind(createManagerCommand);

        return createManagerCommand;
    }

    public class SmtpConfiguration
    {
        public string Host { get; set; } = "";
        public int Port { get; set; } = 25;
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
    }
}