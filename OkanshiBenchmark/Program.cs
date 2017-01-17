using BenchmarkDotNet.Running;

namespace OkanshiBenchmark {
    public class Program {
        public static void Main() {
            var switcher = new BenchmarkSwitcher(typeof(Program).Assembly);
            switcher.Run(new [] { "StopwatchVsBasicTimer" });
            //switcher.RunAll();
        }
    }
}