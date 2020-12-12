using Microsoft.Extensions.Logging;

namespace MVCCoreAngular.Services
{
    public class NullMailServices : IMailServices
    {
        private readonly ILogger<NullMailServices> _logger;

        public NullMailServices(ILogger<NullMailServices> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string to, string subject, string body)
        {
            //Log Message
            _logger.LogInformation($"To: {to} Subject: {subject} Body: {body}");
        }

    }
}
