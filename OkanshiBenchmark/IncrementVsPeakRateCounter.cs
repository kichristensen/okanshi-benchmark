using System.Threading;
using BenchmarkDotNet.Attributes;
using Okanshi;

namespace OkanshiBenchmark {
    public class IncrementVsPeakRateCounter {
        private readonly PeakRateCounter peakRateCounter = OkanshiMonitor.PeakRateCounter("Test");
        private int manualCounter = 0;

        [Benchmark]
        public int InterlockedIncrement() {
            return Interlocked.Increment(ref manualCounter);
        }

        [Benchmark]
        public int NonInterlockedIncrement() {
            manualCounter = manualCounter + 1;
            return manualCounter;
        }

        [Benchmark]
        public void PeakRateCounter() {
            peakRateCounter.Increment();
        }
    }
}