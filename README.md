# dva229-lab3
This is the template repository for Lab 3 in the course Functional Programming with F#, DVA229 in Mälardalen University.

## Setup
In this lab, you will need to create a program. To make the instructions IDE-agnostic, we provide them in command form.

Run the following set of commands (assuming that `dotnet` is in your path)

`dotnet new sln --name DVA229_Lab3`

This will create a solution file.

`dotnet new console -lang "F#" --name Lab3`

This will create the project folder using the console template in the F# language.

`dotnet sln add .\Lab3\Lab3.fsproj`

This will add the project to the solution.

You should now have a solution containing a project with some code that looks like this.
```fs
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
```

To make it possible to send and process arguments, here is a template of a minimal F# program that will print a message and its arguments.
```fs
// For more information see https://aka.ms/fsharp-console-apps

[<EntryPoint>]
let main args = 
    printfn "Hello From F#"
    printfn "Arguments: %A" args
    0
```

## Adding a Test Project
It is generally good practice to separate the test and production code. The convention is to keep them in separate projects, as it may be desirable to build and ship such artefacts separately.

To add a test project, create a new NUnit Project, add it to the same solution. Finally, add the project being tested (*Lab3*) as a reference to the test project (*Lab3_Test*).

Assuming you have followed the abovementioned naming convention, the following set of commands should set this up:

```
dotnet new nunit -lang "F#" --name Lab3_Test
dotnet sln add .\Lab3_Test\Lab3_Test.fsproj
dotnet add .\Lab3_Test\Lab3_Test.fsproj reference .\Lab3\Lab3.fsproj
```

Assuming that all has gone well, you may use the command `dotnet test`, which should automatically build, detect and run the tests.

The NUnit template project comes with a test that just passes. It is of course up to you to write your own test cases to check the functionality. 

We suggest that you start early, and test often!

We will expect completed submissions to have at least some reasonable test cases, and that tests are passing. This will be subject to automated checking, so please do not neglect it.
