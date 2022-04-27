namespace PluginLib

open HostApp

type MyPlugin() =
    interface IPlugin with
        member z.Name = "FSharpPlugin"
        member z.Execute (data: CommandData) =
            Result.Success

module Say =
    let hello name =
        printfn "Hello %s" name
