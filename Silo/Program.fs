namespace OKSilo

open Microsoft.Extensions.Hosting
open Microsoft.Extensions.DependencyInjection
open Orleans
open Orleans.Hosting
open Grains

module Program =
    [<EntryPoint>]
    let main args =
        use host = 
            Host
                .CreateDefaultBuilder(args)
                .UseOrleans(fun ctx sb -> 
                    sb                    
                        .UseInMemoryReminderService()
                        .UseDashboard()
                        .UseLocalhostClustering()
                        .AddMemoryGrainStorage("PubSubStore")
                        |> ignore
                )
                .Build()

        host.StartAsync() |> Async.AwaitTask |> Async.RunSynchronously

        let grainFactory = host.Services.GetRequiredService<IGrainFactory>()

        task {
            let friend = grainFactory.GetGrain<IHelloGrain>("abc")
            let! response = friend.SayHello("Good morning!")
            printfn "\n\n%s\n\n" response
        } |> Async.AwaitTask |> ignore

        // Keep the host running until Ctrl+C is pressed
        host.WaitForShutdown()
    
        // Clean shutdown when the app is terminated
        host.StopAsync() |> Async.AwaitTask |> Async.RunSynchronously

        0
