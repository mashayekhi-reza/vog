﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace VogCodeChallenge.Infrastructure
{
    public class VogDBContextDesignTimeFactory : IDesignTimeDbContextFactory<VogDBContext>
    {
        public VogDBContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("VogDB");
            var optionsBuilder = new DbContextOptionsBuilder<VogDBContext>()
                .UseSqlite(connectionString);

            return new VogDBContext(optionsBuilder.Options);
        }
    }
}
