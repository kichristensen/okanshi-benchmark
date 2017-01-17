using System;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using Okanshi;

namespace OkanshiBenchmark {
    public class StopwatchVsBasicTimer {
        private readonly BasicTimer basicTimer = OkanshiMonitor.BasicTimer("Test");
        private readonly Stopwatch stopwatch = new Stopwatch();

        [Benchmark]
        public long Stopwatch() {
            return TimeUsingStopwatch(() => 1);
        }

        [Benchmark]
        public int BasicTimer() {
            return basicTimer.Record(() => 1);
        }

        [Benchmark]
        public int BasicTimerManual() {
            return TimeUsingManualOkanshiTimer(() => 1);
        }

        private T TimeUsingStopwatch<T>(Func<T> f) {
            stopwatch.Start();
            var result = f();
            stopwatch.Stop();
            return result;
        }

        private T TimeUsingManualOkanshiTimer<T>(Func<T> f) {
            var timer = basicTimer.Start();
            var result = f();
            timer.Stop();
            return result;
        }
    }
}