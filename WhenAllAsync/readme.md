# WhenAll - simple

Several WhenAll code samples. Note that a C# helper library is used in this project which could had been done in VB.NET yet C# in this case is more elegant and VB.NET developers need to consider that not all code that fits their needs will be in VB.NET. By introducing a C# class project and referencing the C# project into a VB.NET Window form project works no different than when the code is VB.NET.

[C# code](https://github.com/karenpayneoregon/async-basics-vb/blob/master/ExtensionLibrary/TaskEx.cs)

```csharp
public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> task1, Task<T2> task2) => (await task1, await task2);
```

