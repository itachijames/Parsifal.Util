using BenchmarkDotNet.Running;

namespace Parsifal.Util.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            //_ = BenchmarkRunner.Run<CrcBenchmarkTest>();
            var switcher = new BenchmarkSwitcher(new[] {
                typeof(CrcBenchmarkTest)
            });
            switcher.Run(args);
        }
    }
}
