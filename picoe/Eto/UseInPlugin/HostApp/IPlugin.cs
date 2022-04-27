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
        Result Execute(CommandData data);
    }
}
