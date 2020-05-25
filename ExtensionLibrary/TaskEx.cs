using System.Threading.Tasks;

namespace ExtensionLibrary
{
    /// <summary>
    /// Wrappers for WhenAll
    /// </summary>
    /// <remarks>With some mods these wrappers can used named tuples</remarks>
    public static class TaskEx
    {
        /// <summary>
        /// C# Wrapper for performing WhenAll and return results of the awaited task.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="task1"></param>
        /// <param name="task2"></param>
        /// <returns></returns>
        public static async Task<(T1, T2)> WhenAll<T1, T2>(Task<T1> task1, Task<T2> task2) => (await task1, await task2);
        /// <summary>
        /// C# Wrapper for performing WhenAll and return results of the awaited task.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <param name="task1"></param>
        /// <param name="task2"></param>
        /// <param name="task3"></param>
        /// <returns></returns>
        public static async Task<(T1, T2, T3)> WhenAll<T1, T2, T3>(Task<T1> task1, Task<T2> task2, Task<T3> task3) => (await task1, await task2, await task3);
        /// <summary>
        /// C# Wrapper for performing WhenAll and return results of the awaited task.
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <typeparam name="T4"></typeparam>
        /// <param name="task1"></param>
        /// <param name="task2"></param>
        /// <param name="task3"></param>
        /// <param name="task4"></param>
        /// <returns></returns>
        public static async Task<(T1, T2, T3, T4)> WhenAll<T1, T2, T3, T4>(Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4) => (await task1, await task2, await task3, await task4);
    }
}
