using System;
using System.Collections.Generic;
using System.IO;
using ExercisesLibrary.Application;
using ExercisesLibrary.Trainings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var builder = new ConfigurationBuilder();
			BuildConfig(builder);

			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Build())
				.Enrich.FromLogContext()
				.WriteTo.Console()
				.WriteTo.File("_logs/log.txt",
					rollingInterval: RollingInterval.Day,
					outputTemplate: "{Timestamp:u} [{Level}] ({ContextId}) {Message}{NewLine}{Exception}")
				.CreateLogger();

			Log.Logger.Information("App is starting");

			var host = Host.CreateDefaultBuilder()
				.ConfigureServices((context, services) =>
				{
					services.AddTransient<ITrainingSetup, TrainingSetup>();
				})
				.UseSerilog()
				.Build();

			var service = ActivatorUtilities.CreateInstance<TrainingSetup>(host.Services);

			service.Setup("C# training", new List<Participant>
			{
				new Participant { Email = "johndoe@email.com" }
			});
		}

		static void BuildConfig(IConfigurationBuilder builder)
		{
			builder.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddEnvironmentVariables();
		}
	}
}
