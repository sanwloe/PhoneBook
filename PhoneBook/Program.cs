using DL.DataContext;
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
using System.Windows.Navigation;
using PhoneBook.Abstractions.Interfaces;

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
                services.AddSqlServer<PBDataContext>(null);
                services.AddSingleton<INumberInfoService,NumberInfoService>();
                services.AddSingleton<ThemeService>();
            });
            var host = builder.Build();
            var app = host.Services.GetService<App>();
            DISource.ServiceProvider = host.Services;
            app?.Run();
        }
    }
}
