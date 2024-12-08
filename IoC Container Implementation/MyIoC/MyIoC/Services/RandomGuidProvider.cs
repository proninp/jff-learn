namespace MyIoC.Services;
public class RandomGuidProvider : IRandomGuidProvider
{
    public Guid RandomGuid { get; } = Guid.NewGuid();
}
