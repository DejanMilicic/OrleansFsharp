namespace Grains

open System.Threading.Tasks
open Orleans

type IHelloGrain =
    inherit IGrainWithStringKey
    abstract member SayHello : greeting:string -> Task<string>

type HelloGrain() = 
    inherit Grain()
    
    interface IHelloGrain with
        member this.SayHello(greeting:string) =
            Task.FromResult($"Hello, You said: {greeting}")
