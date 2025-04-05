# Orleans FSharp Baseline

This is a baseline example of using Orleans with F#.

## Versions

- FSharp : 9
- .NET : 9.0
- Orleans : 9.1.2

## F# fixes

At the moment, four fixes are needed. All of them are marked with 'FSHARPFIX' comment in this project.

1. Host project either needs to be in [C#](https://github.com/DejanMilicic/orleans-fsharp-dotnet9), or you need to create a [C# class](./CodeGen/Class1.cs) with the following attribute

   ```csharp
   [assembly: GenerateCodeForDeclaringAssembly(typeof(TYPE_FROM_F#_PROJECT_WITH_GRAINS))]
   ```

2. In your F# Host project, you need a [module](./Silo/OrleansFsharpFix.fs) that will expose assemblies to the Orleans runtime

3. Grains project needs to [expose internal members](./Grains/OrleansFsharpFix.fs) to code gen project. Add the following

   ```fsharp
	open System.Runtime.CompilerServices
	[<assembly: InternalsVisibleTo("C#_PROJECT_WITH_CODEGEN_CLASS")>]
	do()
   ```

4. For each F# type, you need an [explicit attribute](./Grains/HelloGrain.fs#L9-L12) that will instruct Orleans to generate code for it

   ```fsharp
	[<GenerateSerializer>]
   ```
