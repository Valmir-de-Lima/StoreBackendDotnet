using System.Net;
using System.Net.Mail;
using Store.Domain.Services;

namespace Store.Tests.Services;

public class MockEmailService : IEmailService
{
    public bool Send(
        string toName,
        string toEmail,
        string subject,
        string body,
        string fromName = "Valmir de Lima",
        string fromEmail = "valmirblima7@gmail.com")
    {
        // Todas as informacoes necessarias para criar o servico de email encontra-se no appsettings.json -> Configuration.cs
        return true;
    }
}