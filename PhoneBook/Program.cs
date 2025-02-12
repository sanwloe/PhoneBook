using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var builder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args);
            builder.ConfigureServices((builder,services) =>
            {
                services.AddSingleton<App>();
            });
            var host = builder.Build();
            var app = host.Services.GetService<App>();
            app?.Run();
        }
    }
}
