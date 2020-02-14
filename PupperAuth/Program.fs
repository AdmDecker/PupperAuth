namespace PupperAuth

open System
open System.Threading
open Suave

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main argv = 
      let cts = new CancellationTokenSource()
      let conf = { defaultConfig with cancellationToken = cts.Token }
      let listening, server = startWebServerAsync conf (Successful.OK "Hello World")
        
      Async.Start(server, cts.Token)
      printfn "Make requests now"
      Console.ReadKey true |> ignore
        
      cts.Cancel()

      exitCode // return an integer exit code
