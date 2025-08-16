// 代码生成时间: 2025-08-17 02:22:55
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using System.Net;

// Http request handler class
namespace HttpServiceDemo
{
    public class HttpService : IHttpClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        // Create a named client (e.g., for a specific API)
        public HttpClient CreateClient(string name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));

            return _httpClientFactory.CreateClient(name);
        }
    }

    // Main application class
    public class MauiApp : Application
    {
        public MauiApp()
        {
            var services = new ServiceCollection();
            // Register the HTTP client factory and configure named client for HttpClient
            services.AddHttpClient("MyApi", client =>
            {
                client.BaseAddress = new Uri("https://api.example.com/"); // Set your API endpoint here
            }).AddHttpMessageHandler<MyApiHandler>();

            services.AddSingleton<HttpService>();

            // Add any other service configurations here
            // ...

            // Build and configure MauiApp to use .NET MAUI controls and services
            MauiApp.CreateBuilder()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSans"))
                .Build()
                .Services.AddSingleton(services.BuildServiceProvider());
        }
    }

    // Custom HTTP message handler
    public class MyApiHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                // Add any custom logic here (e.g., logging, authentication)
                // ...

                // Call the base handler to send the request
                var response = await base.SendAsync(request, cancellationToken);

                // Check if the response status code is successful
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                }

                return response;
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Console.WriteLine($"Exception caught in MyApiHandler: {ex.Message}");
                throw; // Re-throw the exception to allow further handling (e.g., by the caller)
            }
        }
    }

    // Main application entry point
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = MauiApplication.CreateBuilder(args);
            builder.RegisterMauiApp<MauiApp>();
            var app = builder.Build();
            app.MainPage = new ContentPage
            {
                Content = new Label
                {
                    Text = "Welcome to the .NET MAUI HTTP Request Handler Demo!",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                }
            };
            app.Run();
        }
    }
}
