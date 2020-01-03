using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazeDBG
{
    public class BlazeDebugger : IBlazeDebugger
    {
        private readonly IJSRuntime _jsRuntime;

        public BlazeDebugger(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task ConsoleLog(string title, object data, LogLevel level = LogLevel.Info)
        {
#if DEBUG
            var output = data != null ? Serialize(data) : null;
            var logMethod = "";

            switch (level)
            {
                case LogLevel.Info:
                    logMethod = "window.console.info";
                    break;
                case LogLevel.Warn:
                    logMethod = "window.console.warn";
                    break;
                case LogLevel.Error:
                    logMethod = "window.console.error";
                    break;
            }


            await _jsRuntime.InvokeVoidAsync($"{logMethod}", title, output);
#endif
        }

        private string Serialize(object obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }
    }

    public enum LogLevel
    {
        Info = 0,
        Warn = 1,
        Error = 2
    }
}
