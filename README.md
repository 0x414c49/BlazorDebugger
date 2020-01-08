# BlazorDebugger
A class which is just a hack by making interop between JS and .NET inside Blazor. I called BlazeDBG.


This repo is part of medium article: 
[Debugging Blazor Web Assembly Apps](https://itnext.io/debugging-blazor-web-assembly-apps-c47ef25bcb5f)


Register IBlazeDebugger as Singleton in your services.

```
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IBlazeDebugger, BlazeDebugger>();
        }
    }
```

Inject the object in your razor pages:

```
@using BlazeDBG;
@inject IBlazeDebugger BlazeDbg;
```

Log whatever you wanted to the console:

```
@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        BlazeDbg.ConsoleLog("counterCount before", currentCount);
        currentCount++;
        BlazeDbg.ConsoleLog("counterCount before", currentCount, LogLevel.Warn);
    }

}
```


