using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OnlineVotingSystem.Repository
{
    public class SampleRepo: IsampleRepo
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SampleRepo> _logger;
        public void DoSomething()
        {
            _logger.LogInformation($"{nameof(SampleRepo)}.DoSomething-just did something");
            var connstring = _configuration.GetConnectionString("DevConnection");
            _logger.LogInformation($"The connection from sample repo:{connstring}");
        }
        public SampleRepo( IConfiguration configuration,ILogger<SampleRepo> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        
    }
}
