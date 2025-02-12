﻿using DL.DataContext;
using PhoneBook.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PhoneBook.Extensions.Xaml;

namespace PhoneBook
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices((builder,services) =>
            {
                services.AddSingleton<App>();
                services.AddSqlite<PBDataContext>("DataSource=database.db");
                services.AddSingleton<NumberInfoService>();
            });
            var host = builder.Build();
            var app = host.Services.GetService<App>();
            DISource.ServiceProvider = host.Services;
            app?.Run();
        }
    }
}
