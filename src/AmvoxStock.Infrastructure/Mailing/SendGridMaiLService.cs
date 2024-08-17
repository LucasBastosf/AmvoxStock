using AmovoxStock.Application.Common.Mailing;
using Microsoft.Extensions.Logging;

namespace AmvoxStock.Infrastructure.Maling;

public class SendGridMailService : IMailService
{
    private readonly ILogger<SendGridMailService> _logger;

    public SendGridMailService(ILogger<SendGridMailService> logger)
    {
        _logger = logger;
    }

    public Task SendAsync(MailRequest request, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}