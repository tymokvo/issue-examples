namespace PluginLib

open HostApp
open System
open Eto.Forms

type Instantiate() =
    interface IPlugin with
        member z.Name = "Instantiate"
        member z.Execute (data: CommandData) =
            let a = (new Application())
            let f = new Form()
            f.Title <- data.Content
            // a.Run(f) // Throws null reference exception
            a.Dispose()
            Result.Success

type CheckInstance() =
    interface IPlugin with
        member z.Name = "CheckInstance"
        member z.Execute (data: CommandData) =
            let a = match Application.Instance with
                    | null -> (new Application())
                    | a -> a

            let f = new Form()
            f.Title <- data.Content
            // a.Run(f) // Throws null reference exception
            a.Dispose()
            Result.Success

type Attach() =
    interface IPlugin with
        member z.Name = "Attach"
        member z.Execute (data: CommandData) =
            let a = match Application.Instance with
                    | null -> (new Application()).Attach()
                    | a -> a

            let f = new Form()
            f.Title <- data.Content
            // a.Run(f) // Throws null reference exception
            a.Dispose()
            Result.Success
