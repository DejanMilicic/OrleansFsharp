namespace Grains

open System.Threading.Tasks
open Orleans

// FSHARPFIX
// the following line is necessary to make the Orleans codegen work
// it will instruct the Orleans codegen to generate the code for the message
[<GenerateSerializer>]
type GreeterMessage =
    | Greeting of string
    | Number of int

type IHelloGrain =
    inherit IGrainWithStringKey
    abstract member Receive : msg:GreeterMessage -> Task<string>

type HelloGrain() = 
    inherit Grain()
    
    interface IHelloGrain with
        member this.Receive(msg: GreeterMessage) =
            match msg with
            | Greeting greeting ->
                Task.FromResult($"Greeter received greeting: *{greeting}*")
            | Number number ->
                Task.FromResult($"Coffee number: *{number}*")
