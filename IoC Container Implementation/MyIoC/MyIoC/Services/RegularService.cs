namespace MyIoC.Services;
public class RegularService : IRegularService
{
    private readonly IRandomGuidProvider _randomGuidProvider;

    public RegularService(IRandomGuidProvider randomGuidProvider)
    {
        _randomGuidProvider = randomGuidProvider;
    }

    public void Print()
    {
        Console.WriteLine(_randomGuidProvider.RandomGuid);
    }
}
