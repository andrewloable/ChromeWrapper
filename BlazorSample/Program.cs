using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChromeWrapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorSample
{
    public class Program
    {
        private static int port = 8000;
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            port = rnd.Next(8000, 65535);
            UI.New($"http://localhost:{port.ToString()}", 400, 400, true);
            CreateHostBuilder(args).Build().Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls($"http://localhost:{port.ToString()}").UseStartup<Startup>();
                });
        }            
    }
}
