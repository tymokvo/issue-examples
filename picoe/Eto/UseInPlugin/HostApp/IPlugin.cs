namespace HostApp
{
    public enum Result
    {
        Success = 0,
        Failure = 1
    }

    public class CommandData
    {
        public string Content;
    }
    public interface IPlugin
    {
        string Name {get;}
        Result Execute(CommandData data);
    }
}
