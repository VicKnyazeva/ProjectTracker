using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using ProjectTracker.DAL;
using ProjectTracker.DAL.Models;

using System;
using System.Collections.Generic;

#pragma warning disable 1591

namespace ProjectTracker.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            CreateDbIfNotExists(host);

            host.Run();
        }

        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var dbc = services.GetRequiredService<ProjectTrackerDbContext>();

                    if (dbc.Database.EnsureCreated())
                    {
                        Console.WriteLine("Initializsing database");

                        #region seed data

                        var projects = new List<Project>
                        {
                            new Project { Name = "Project #1", Description = "desc #1", Started = new System.DateTime(2022,01,01), Status = Domain.ProjectStatus.Active },
                            new Project { Name = "Project #2", Description = "desc #2", Started = new System.DateTime(2022,01,05), Status = Domain.ProjectStatus.NotStarted }
                        };
                        dbc.Projects.AddRange(projects);

                        var tasks = new List<ProjectTask>
                        {
                            new ProjectTask { Project = projects[0], Name = "Task #1.1", Description = "task desc #1.1", Status = Domain.TaskStatus.InProgress },
                            new ProjectTask { Project = projects[0], Name = "Task #1.2", Description = "task desc #1.2", Status = Domain.TaskStatus.ToDo },
                            new ProjectTask { Project = projects[1], Name = "Task #2.1", Description = "task desc #2.1", Status = Domain.TaskStatus.ToDo },
                        };
                        dbc.ProjectTasks.AddRange(tasks);

                        var fields = new List<ProjectTaskField>
                        {
                            new ProjectTaskField { Task = tasks[2], Name = "FIELD1", Value = "f 1" },
                            new ProjectTaskField { Task = tasks[2], Name = "Field1", Value = "f 1 low" },
                            new ProjectTaskField { Task = tasks[2], Name = "FIELD #2", Value = "f 1" },
                        };
                        dbc.ProjectTaskFields.AddRange(fields);

                        #endregion seed data

                        dbc.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
