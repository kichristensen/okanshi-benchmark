using BenchmarkDotNet.Running;

namespace OkanshiBenchmark {
    public class Program {
        public static void Main() {
            var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);
            switcher.RunAll();
        }
    }
}