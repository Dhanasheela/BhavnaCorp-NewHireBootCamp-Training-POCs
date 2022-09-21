using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    public class Worker
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        public void Run()
        {
            _logger.LogInformation("helloworld");
            var connstring = _configuration.GetConnectionString("DevConnection");
            _logger.LogInformation($"Connection String:{connstring}");
        }
        public Worker(IConfiguration configuration,Ilogger<Worker> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }
    }
}
