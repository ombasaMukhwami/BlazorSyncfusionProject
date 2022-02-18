using BlazoeProject.Server.services;
using BlazoeProject.Server.services.Implementation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazoeProject.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {



            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg0MDUxQDMxMzkyZTM0MmUzMFVmaEF5YXdjNEExckwrNUlZRkVUNzNlVjBVWUZFNEdoYnJ2L1NGQ0F1NXM9");

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(Client =>
             {
                 Client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
             });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
