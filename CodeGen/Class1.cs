// FSHARPFIX
// Orleans generates C# code for serialization so we need a C# project to compile the generated code
// Point this attribute to the assembly where Grains are
[assembly: GenerateCodeForDeclaringAssembly(typeof(Grains.HelloGrain))]