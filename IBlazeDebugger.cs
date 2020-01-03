using System.Threading.Tasks;

namespace BlazeDBG
{
    public interface IBlazeDebugger
    {
        Task ConsoleLog(string title, object data, LogLevel level = LogLevel.Info);
    }
}
