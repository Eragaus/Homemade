namespace Homade.Models;

public class AbstractId
{
    public Guid Id { get; set; } = Guid.NewGuid();
}