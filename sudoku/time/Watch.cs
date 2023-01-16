using System;
using System.Diagnostics;

namespace sudoku
{
    /* class of a stopwatch */
    class Watch
    {
        private Stopwatch stopwatch; // stopwatch

        // constructor - initializes the stopwatch
        public Watch()
        {
            stopwatch = new Stopwatch();
        }

        // starts the stopwatch
        public void Start()
        {
            stopwatch.Start();
        }

        // stops the stopwatch
        public void Stop()
        {
            stopwatch.Stop();
        }

        // returns the elapsed time in milliseconds
        public double GetElapsedTime()
        {
            return stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
