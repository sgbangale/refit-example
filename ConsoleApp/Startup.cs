using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

var builder = Host.CreateApplicationBuilder(args);
// Register Refit Http Client and include possible http client options like base address, default request headers, authorization jwt token etc.
builder.Services.AddRefitClient<IDogService>()
    .ConfigureHttpClient((p, client) =>
    {
        client.BaseAddress = new Uri("https://dog.ceo/api");
        client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
    });
// register main App class as singleton 
builder.Services.AddSingleton<App>();
using var host = builder.Build();

var app = host.Services.GetRequiredService<App>();

// call Run method to initiate program.
await app.Run();