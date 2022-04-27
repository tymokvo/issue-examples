namespace PluginLib

open HostApp
open System
open Eto.Forms

type MyPlugin() =
    interface IPlugin with
        member z.Name = "FSharpPlugin"
        member z.Execute (data: CommandData) =
            let a = (new Application())
            let f = new Form()
            f.Title <- data.Content
            // a.Run(f) // Throws null reference exception
            Result.Success
