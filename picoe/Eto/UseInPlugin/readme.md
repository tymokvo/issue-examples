# Using `Eto.Forms` from a .NET plugin

## Problem

Running a `Eto.Forms.Application` from a plugin where the plugin author doesn't
have control over the `Main` method of the host application.

E.g. writing a plugin for a closed-source app.

## To Demonstrate

Run this in `pwsh`

```powershell
dotnet build
dotnet run --project HostApp
```

This will put you into the main loop of the console app. In order, enter:
```console
FSharpPlugin
y
FSharpPlugin
```

## Expected result

```console
System.InvalidOperationException: The Eto.Forms Application is already created.
   at Eto.Forms.Application.InitializePlatform(Platform platform)
   at Eto.Forms.Application..ctor(Platform platform)
   at PluginLib.MyPlugin.HostApp.IPlugin.Execute(CommandData data)
```

## Desired result

Is there a way to instantiate an application and `.Run` forms in it from plugin
libraries such that the `Application` instance can be:

- Kept from being `.Dispose()`'d?
- Replaced with `Application.Instance = new Application()`?
- Some other method?
