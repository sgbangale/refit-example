public class App
{
    private readonly IDogService _dogService;

    // use constructor dependency injection to get IDogService instance.
    public App(IDogService dogService)
    {
        _dogService = dogService;
    }

    public async Task Run()
    {
        // call GetBreedImages method
        var data = await _dogService.GetBreedImages("hound");
        Console.WriteLine(
            $"Images = {Environment.NewLine}{string.Join(Environment.NewLine, data.Message)}{Environment.NewLine} Status = {data.Status}");
    }
}