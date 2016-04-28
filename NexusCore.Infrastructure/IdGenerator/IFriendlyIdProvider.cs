namespace NexusCore.Infrastructure.IdGenerator
{
    public interface IFriendlyIdProvider
    {
        string GetFriendlyId(string prefix, string suffix = "");
    }
}
