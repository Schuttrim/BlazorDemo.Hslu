using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using contract;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using ProtoBuf.Grpc.Client;

namespace client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            // Setzt einen HttpClient auf, welcher auf die wwwroot directory zeigt
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            
            builder.Services.AddMudServices();
            
            // Setzt einen GrpcChannel auf, welcher via GrpcWeb funktioniert (damit läuft grp auf HTTP /2)
            builder.Services.AddSingleton(services => 
            { 
                var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())); 
                var channel = GrpcChannel.ForAddress("https://localhost:6001", new GrpcChannelOptions { HttpClient = httpClient });
                return channel;
            });

            await builder.Build().RunAsync();
        }
    }
}
