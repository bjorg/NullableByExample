# Nullable by Example

## Getting Started with Null-Aware Code
1. Enable nullable types for the entire project by adding the `<Nullable>enable</Nullable>` element to your _.csproj_ files.
1. Add the `#nullable disable` pragma to every source file you want to remain null-unaware.
1. As you work on each file, remove the `#nullable` pragma and address any warnings.

## Null-Aware Code Exercises
This repository contains two exercise files with their corresponding solutions.
* [Exercise_Methods.cs](Exercise_Methods.cs) focuses on nullable annotations for methods. This exercise covers the nullable type suffix `?`, as well as the following attributes: [`NotNull`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullattribute?view=netcore-3.1), [`NotNullWhen`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullwhenattribute?view=netcore-3.1), and [`NotNullIfNotNull`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.notnullifnotnullattribute?view=netcore-3.1).
* [Exercise_Properties.cs](Exercise_Properties.cs) focuses on nullable annotations for properties. This exercise covers the following attributes: [`AllowNull`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.allownullattribute?view=netcore-3.1) and [`DisallowNull`](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.codeanalysis.disallownullattribute?view=netcore-3.1).

## Mixing Null-Aware and Null-Unaware Code
Mixing null-aware and null-unaware code has some unfortunate, but understandable, negative side-effects. To demonstrate, this  repository contains two classes which call each other. The first class is null-aware ([`Mixed_NullAware.cs`](Mixed_NullAware.cs)) and the second class is not ([`Mixed_NullUnaware.cs`](Mixed_NullUnaware.cs)). Neither code shows any warnings. The null-unaware code does not provide sufficient information to null-aware code to make a determination that a null exception could occur. And, of course, the null-unaware code doesn't take advantage of the null annotations in the null-aware code.

The short of it, is that as projects are converted from null-unaware to null-aware, code that were previously warning-free and null-aware may start to show new warnings, because the compiler is supplied new information with each converted class.

## Personal Anecdotes
* In [LambdaSharp](https://github.com/LambdaSharp/LambdaSharpTool) parser, helper functions return null when something cannot be parsed and emit an error. In one case, I was checking if the parsed result did not match the expected type and would emit an error, forgetting that `null` results also emitted an error message. After making the parser code null-aware, my mistake became apparent and was quickly fixed.
* Consider doing `x.Foo ?? throw new InvalidOperationException()` instead of this `x.Foo!`, because `NullReferenceException` can happen anywhere, which can make it hard to track down exactly which expression is the culprit.
* Nullable annotations have proven very useful to validate expectations, which may be different from the time a type is declared to when it is used.
* Note that a null-aware file will trust the type annotations of a non-aware file. This means that as you convert files to become null-aware, warning may pop-up in files you already converted. Optimally, you should try to convert files from least dependent to most dependent (similar to a build system).

## Additional Reading
* [Tutorial: Express your design intent more clearly with nullable and non-nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/nullable-reference-types)
* [Tutorial: Migrate existing code with nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/upgrade-to-nullable-references)
* [Update libraries to use nullable reference types and communicate nullable rules to callers](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-attributes)
