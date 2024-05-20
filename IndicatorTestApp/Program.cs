using System;
using rsi_indicator;

namespace IndicatorTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing the RSI Indicator...");

            // Assuming you have a class named `CustomRsiIndicator` in your `rsi_indicator` library
            var rsiIndicator = new CustomRsiIndicator();
            rsiIndicator.Initialize();  // Call appropriate methods for testing

            Console.WriteLine("RSI Indicator Test Completed.");
        }
    }
}