using Refit;
var builder = WebApplication.CreateBuilder(args);
// Register Refit Http Client and include possible http client options like base address, default request headers, authorization jwt token etc.
builder.Services.AddRefitClient<IDogService>()
    .ConfigureHttpClient((p, client) =>
    {
        client.BaseAddress = new Uri("https://dog.ceo/api");
        client.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
    });

var app = builder.Build();

app.MapGet("/", async (IDogService _dogService) => {

    return (await _dogService.GetBreedImages("poodle")).Message;
});

app.Run();

public interface IDogService
{
    // Dog Service GET Breed image API
    [Get("/breed/{breedName}/images/random/3")]
    Task<BreedImageModel> GetBreedImages(string breedName);
}

public record BreedImageModel(string[]? Message, string? Status);
