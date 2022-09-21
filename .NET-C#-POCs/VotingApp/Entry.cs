using System;
using System.Configuration;
using System.Data.SqlClient;
using VotingApp.Enums;
using VotingApp.Interfaces.Admin;
using VotingApp.Interfaces.Voter;
using VotingApp.Models;
using VotingApp.Models.Admin;
using VotingApp.Models.Voter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VotingApp
{
    class Entry
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var worker = ActivatorUtilities.CreateInstance<Worker>(host.Services);
            worker.Run();
            try
            {

                string answer = "Y";
                for (; answer.ToUpper() == "Y";)
                {
                    Console.WriteLine("*------------------Welcome To India Online Voting System------------------*");
                    Console.WriteLine("\nPress 1 For Admin Login");
                    Console.WriteLine("\nPress 2 for Voter Login");
                    int n = int.Parse(Console.ReadLine());

                    if (n == (int)Elogin.admin)
                    {
                        IAdminLogin admin = new AdminLogin();
                        Predicate<string> obj = new Predicate<string>(admin.ALogin);
                        bool status = obj.Invoke("");

                        if (status == true)
                        {
                            string ay = "Y";
                            for (; ay.ToUpper() == "Y";)
                            {
                                Console.WriteLine("\nHi, Admin Select the Desired Option:");
                                Console.WriteLine("\nPress 1 for Voter Registration:");
                                Console.WriteLine("\nPress 2 for Counting the Votes");
                                Console.WriteLine("\nPress 3 for Party Registeration");



                                int b = int.Parse(Console.ReadLine());

                                switch (b)
                                {
                                    case (int)EAdmin.registeration:
                                        IVoterRegisteration registeration = new VoterRegistration();
                                        Action<string> ob = new Action<string>(registeration.registeration);
                                        ob.Invoke("\nVoter Details Added Successfully");
                                        break;

                                    case (int)EAdmin.count:
                                        ICountVotes countVotes = new CountVotes();
                                        countVotes.Count();
                                        break;




                                    case (int)EAdmin.pregister:
                                        IPartyRegistration partyRegistration = new PartyRegistration();
                                        Action<string> o = new Action<string>(partyRegistration.Pregisteration);
                                        o.Invoke("\nParty info inserted sucessfully in the database");
                                        break;


                                      default:
                                        Console.WriteLine("\nYou have entered the wrong Input");
                                        break;

                                }
                                Console.WriteLine("Do you wish to continue with Admin Operations? Y/N");
                                ay = Console.ReadLine();
                            }
                        }
                    }

                    else if (n == (int)Elogin.voter)
                    {
                        IVoterLogin login = new VoterLogin();
                        Predicate<string> obj1 = new Predicate<string>(login.VLogin);
                        bool stat = obj1.Invoke("");
                        if (stat == true)
                        {
                            IVoteCasting voteCasting = new VoteCasting();
                            voteCasting.VoteCaste();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered the wrong choice");
                    }
                    Console.WriteLine("Do you wish to continue with Another Login? Y/N");
                    answer = Console.ReadLine();
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
          return   Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults((context,configuration) =>
                {
                configuration.Sources.Clear();
                configuration.AddJsonFile("appsettings.json", optional: true, relodOnChange: true);
                });

        }
    }

}