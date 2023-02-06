# dva229-lab3
This is the template repository for Lab 3 in the course Functional Programming with F#, DVA229 in Mälardalen University.

## Setup
In this lab, you will need to create an executable program. To make the instructions IDE-agnostic, we provide them in command form.

Run the following set of commands (assuming that `dotnet` is in your path *AND* that F# templates are installed)

To create a new solution file - which .NET uses to group projects together.

`dotnet new sln --name DVA229_Lab3`

This will create the project folder using the console template in the F# language. This will be your "runner" project

`dotnet new console -lang "F#" --name Lab3`

This will add the project to the solution.

`dotnet sln add .\Lab3\Lab3.fsproj`

You should now have a solution containing a project with some code that looks like this.
```fs
// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"
```

To make it possible to send and process arguments, here is a template of a minimal F# program with a specified entrypoint that will print a message and its arguments. For the sake of convention, the name `main` has been kept.
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

We suggest that you start early, and test often! A simple introduction to NUnit in F# can be found at https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-fsharp-with-nunit#creating-the-first-test.

We will expect completed submissions to have at least some reasonable test cases, and that tests are passing. This will be subject to automated checking, so please do not neglect it.

### On Test Design
In this lab, your task is to design a small program from scratch based on some specified behaviour. As such, we have not given you any test setup - as this would likely bias you w.r.t., how functions are designed, named etc.

We can however note that functional-style programming lends itself well to the concept of "unit-level" testing. As pure functions should be able to consider only the inputs and expected outputs, it is quite straightforward to test each function in isolation, in a unit-test like manner. You may then compose those functions into new functions that can be tested, until you have a final program.

Note that testing should not just cover the functioning, "happy" path of the functionality. You should also consider and test the negative side, e.g., error handling. That way you can easily show that you have considered and taken care of those cases - which will hopefully lead to less nasty surprises further down the line.
