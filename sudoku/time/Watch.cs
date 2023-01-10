using System;
using System.Diagnostics;

namespace sudoku
{
    class Watch
    {
        private Stopwatch stopwatch;

        public Watch()
        {
            // Create a stopwatch
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            // Start the stopwatch
            stopwatch.Start();
        }

        public void Stop()
        {
            // Stop the stopwatch
            stopwatch.Stop();
        }

        public double GetElapsedTime()
        {
            // Return the elapsed time
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
