using System;
using Aruba.Data;
using Microsoft.Extensions.Logging;

namespace Aruba.Services
{
    public class DummyMailService : IMailService
    {
        private readonly ILogger<DummyMailService> _logger;

        public DummyMailService(ILogger<DummyMailService> logger)
        {
            _logger = logger;
        }

        public ILogger<DummyMailService> Logger { get; }

        public void SendMessage(string to, string subject, string body)
        {
            _logger.LogInformation($"To: {to} Subject: {subject}, body: {body}");

        }

    }
}