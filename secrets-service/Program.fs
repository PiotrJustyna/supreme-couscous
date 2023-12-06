module SecretsService.App

open System
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open SecretsService

[<EntryPoint>]
let main argv =
  let hostBuilder = Host.CreateDefaultBuilder(argv)

  let host =
    hostBuilder
      .ConfigureServices(fun hostContext services -> 
        services.AddHostedService<SecretsService.Workers.VanillaWorker>() |> ignore
      )
      .Build()
      .Run()
  
  0