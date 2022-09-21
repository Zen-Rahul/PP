using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PP.TestWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IComputeService _computeService;

        public Worker(ILogger<Worker> logger, IComputeService computeService)
        {
            _logger = logger;
            _computeService = computeService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var ran = new Random();

                var a = ran.Next();
                var b = ran.Next();
                var res = 0;
                _logger.LogInformation($"resolved compute service address = {_computeService.GetHashCode()}");
                switch (ran.Next(1, 4))
                {
                    case 1:
                        res = _computeService.Add(a, b);
                        _logger.LogInformation($"invoked Add for input {a} and {b}, result is {res}");
                        break;
                    case 2:
                        res = _computeService.Diff(a, b);
                        _logger.LogInformation($"invoked Diff for input {a} and {b}, result is {res}");
                        break;
                    case 3:
                        res = _computeService.Multiply(a, b);
                        _logger.LogInformation($"invoked Multiply for input {a} and {b}, result is {res}");
                        break;
                    default:
                        _logger.LogInformation($"Ooopss!!! Invalid operation.");
                        break;
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
