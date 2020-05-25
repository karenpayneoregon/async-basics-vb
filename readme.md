# Basic asynchronous  operations (VB.NET)

This repository contains very simple/basic examples for working with asynchronous  operations in Windows Forms solutions.

By following the basics will allow a developer to expand on the basics to use in every day programming task. Way too many times developers will attempt to use asynchronous operations in complex task and fail because they have not mastered the basics which is the intent here.


More code samples will be added over time.

#### Entity Framework Core 3 async

See the following [GitHub repository](https://github.com/karenpayneoregon/ef-core-projections-vb) for code samples using async operations against SQL-Server.


#### Microsoft TechNet article
TBA

#### Async improves responsiveness
([From Microsoft](https://docs.microsoft.com/en-us/dotnet/visual-basic/programming-guide/concepts/async/))
>Asynchrony is essential for activities that are potentially blocking, such as when your application accesses the web. Access to a web resource sometimes is slow or delayed. If such an activity is blocked within a synchronous process, the entire application must wait. In an asynchronous process, the application can continue with other work that doesn't depend on the web resource until the potentially blocking task finishes.
>
>Asynchrony proves especially valuable for applications that access the UI thread because all UI-related activity usually shares one thread. If any process is blocked in a synchronous application, all are blocked. Your application stops responding, and you might conclude that it has failed when instead it's just waiting.
>
>When you use asynchronous methods, the application continues to respond to the UI. You can resize or minimize a window, for example, or you can close the application
> if you don't want to wait for it to finish.

#### Requires

[BaseConnectionLibrary](https://www.nuget.org/packages/BaseConnectionLibrary/) from NuGet for project CopyFileAsync. This means before running the project CopyFileAsync perform a Nuget Restore packages. The library has [full source](https://github.com/karenpayneoregon/BaseConnectionsVisualBasicNet). 

