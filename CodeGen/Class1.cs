// FSHARPFIX
// Orleans generates C# code for serialization so we need a C# project to compile the generated code
[assembly: GenerateCodeForDeclaringAssembly(typeof(Grains.HelloGrain))]