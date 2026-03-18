using BenchmarkDotNet.Running;
using Benchmarks.CollectionContains;

namespace Benchmarks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<CollectionContainsBenchmark>();
        }
    }
}