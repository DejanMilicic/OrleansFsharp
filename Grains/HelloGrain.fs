namespace Grains

open System.Threading.Tasks
open Orleans

// FSHARPFIX
// following three lines are necessary to make the Orleans codegen work
// "CodeGen" is the name of the C# codegen project
open System.Runtime.CompilerServices
[<assembly: InternalsVisibleTo("CodeGen")>]
do()

// FSHARPFIX
// the following line is necessary to make the Orleans codegen work
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
                Task.FromResult($"Greeter received number: *{number}*")
