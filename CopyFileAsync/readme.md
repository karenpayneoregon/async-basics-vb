# Copy a file async with progress bar

Typically clients like to see progress when copying files, this example shows copying a file async with a progress bar. To copy a file async without a progress bar see [CopyToAsync](https://docs.microsoft.com/en-us/dotnet/api/system.io.stream.copytoasync?view=netcore-3.1).

#### Note
In stream extension CopyToWithProgressAsync there is a Task.Delay, remove this for code out in the real world, the delay is needed here for a small file (5,000 lines) so the progress does not happen in a split second.