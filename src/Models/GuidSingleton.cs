namespace AspNetMvcCSP.Models;

public interface IGuidSingleton
{
    Guid Guid { get; }
}
public class GuidSingleton : IGuidSingleton
{
    public Guid Guid { get; } = Guid.NewGuid();
}
