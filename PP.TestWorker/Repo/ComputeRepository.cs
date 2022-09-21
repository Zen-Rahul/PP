using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace PP.TestWorker.Repo
{
    public interface IComputeRepository
    {
        void Print();
    }
    public class ComputeRepository : IComputeRepository
    {
        private ILogger _logger;

        public ComputeRepository(ILogger<ComputeRepository> logger)
        {
            _logger = logger;
        }
        public void Print()
        {
            _logger.LogInformation("repo logger invoked");
            Console.WriteLine("Print Called");
        }
    }
}
