using Refit;

public interface IDogService
{
    // Dog Service GET Breed image API
    [Get("/breed/{breedName}/images/random/3")]
    Task<BreedImageModel> GetBreedImages(string breedName);
}
