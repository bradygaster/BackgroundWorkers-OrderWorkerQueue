using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderQueueWorker
{
    public class Worker : BackgroundService
    {
        internal const string VERSION = "0.0.4";
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($"OrderQueueWorker v{VERSION} entering ExecuteAsync");
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
