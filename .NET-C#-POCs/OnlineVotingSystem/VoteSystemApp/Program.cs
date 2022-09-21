using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineVotingSystem.Repository;
using OnlineVotingSystem.VoteSystemApp;
using System;
using System.Configuration;

namespace OnlineVotingSystem
{
  public class Program
    {
       
       
        static int tableWidth = 73;
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Worker>(host.Services);
            worker.Run();
            VoteApp voteApp = new VoteApp();
            //voteApp.Login();
            //  voteApp.CheckAdminNameAndPasswordAsync();
            //   voteApp.list();
            //Console.WriteLine("eter ur option");
           
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                  .ConfigureAppConfiguration((context, configuration) => {
                      configuration.Sources.Clear();
                      configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                      configuration.AddCommandLine(args);
                  })
            .ConfigureServices((context, services) => {
                services.AddScoped<IsampleRepo, SampleRepo>();
                services.AddScoped<IVoteApp, VoteApp>();
            });
        }

    }

}
