# Nullable by Example

## Getting Started with Null-Aware Code
1. Enable nullable types for the entire project by adding the `<Nullable>enable</Nullable>` element to your _.csproj_ files.
1. Add the `#nullable disable` pragma to every source file you want to remain null-unaware.
1. As you work on each file, remove the `#nullable` pragma and address any warnings.

## Null-Aware Code Exercises
This repository contains two exercise files with their corresponding solutions.
* [Exercise_Methods.cs](Exercise_Methods.cs) focuses on nullable annotations for methods.
* [Exercise_Properties.cs](Exercise_Properties.cs) focuses on nullable annotations for properties.

## Personal Anecdotes
* In [LambdaSharp](https://github.com/LambdaSharp/LambdaSharpTool) parser, helper functions return null when something cannot be parsed and emit an error. In one case, I was checking if the parsed result did not match the expected type and would emit an error, forgetting that `null` results also emitted an error message. After making the parser code null-aware, my mistake became apparent and was quickly fixed.
* Consider doing `x.Foo ?? throw new InvalidOperationException()` instead of this `x.Foo!`, because `NullReferenceException` can happen anywhere, which can make it hard to track down exactly which expression is the culprit.
* Nullable annotations have proven very useful to validate expectations, which may be different from the time a type is declared to when it is used.
* Note that a null-aware file will trust the type annotations of a non-aware file. This means that as you convert files to become null-aware, warning may pop-up in files you already converted. Optimally, you should try to convert files from least dependent to most dependent (similar to a build system).