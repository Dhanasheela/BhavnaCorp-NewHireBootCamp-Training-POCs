using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnlineVotingSystem.Repository;
using OnlineVotingSystem.VoteSystemApp;

namespace OnlineVotingSystem
{
    public class Worker
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<Worker> _logger;
        private readonly IsampleRepo _repo;
        private readonly IVoteApp _voteApp;
        public void Run()
        {
            _logger.LogInformation("helloworld");
            var connstring = _configuration.GetConnectionString("DevConnection");
            _logger.LogInformation($"Connection String:{connstring}");
            _repo.DoSomething();
           

            //we are calling our voteapp methods by using interfaces
            _voteApp.AppMenu();
            
        }
        public Worker(IsampleRepo repo, IVoteApp voteapp, IConfiguration configuration, ILogger<Worker> logger)
        {
            _repo = repo;
            _voteApp = voteapp;
            _configuration = configuration;
            _logger = logger;

        }
       
    }
}
