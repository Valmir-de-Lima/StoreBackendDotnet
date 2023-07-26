using Store.Shared.Commands.Interfaces;

namespace Store.Shared.Commands;
public class CommandResult : ICommandResult
{
    public CommandResult(bool success, string message, object data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public CommandResult(bool success, string message)
    {
        Success = success;
        Message = message;
        Data = new Object();
    }

    public CommandResult(bool success, object data)
    {
        Success = success;
        Message = "";
        Data = data;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}
