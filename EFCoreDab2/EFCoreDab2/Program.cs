﻿using System;
using System.Linq;
using CommandLine;
using EFCoreDab2.Models;

namespace EFCoreDab2
{
    class Program
    {
        public class Options
        {
            
            [Option('s', "server", Required = true, HelpText = "Set server to connect to.")]
            public string Server { get; set; }

            [Option('d', "database", Required = true, HelpText = "Set database.")]
            public string Database { get; set; }

            [Option('u', "username", Required = true, HelpText = "Set username")]
            public string Username { get; set; }

            [Option('p', "password", Required = true, HelpText = "Set password")]
            public string Password { get; set; }
            
            [Value(0, MetaName = "Command", HelpText = "Command to execute", Required = true)]
            public string Command { get; set; }


        }

        static void Main(string[] args)
        {
            Options options = null;
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    options = o;
                }); 
            DbClient client = new DbClient(options.Server, options.Database, options.Username, options.Password);
            string output = "Available commands: Municipalities, Societies, BookedRooms";
            switch (options.Command)
            {
                case "Municipalities":
                {
                    var a = client.GetRooms();
                    output = String.Join("\n", a);
                    break;
                }
                case "Societies":
                {
                    var a = client.GetSocieties();
                    output = String.Join("\n", a);
                    break;
                }
                case "BookedRooms":
                {
                    var a = client.GetBookedRooms().Select(room => room.GetBookedRooms());
                    output = String.Join("\n", a);
                    break;
                }
            }
            Console.WriteLine(output);
        }

        
        

    }
}