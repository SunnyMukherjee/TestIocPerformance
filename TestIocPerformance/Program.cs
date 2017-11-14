using System;
using System.Diagnostics;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Tests;

namespace TestIocPerformance
{
    class Program
    {
        internal static Stopwatch StopwatchObj { get; set; }        

        internal static int NumberOfTests { get; set; }

        static void Main(string[] args)
        {
            NumberOfTests = 100;
            StopwatchObj = new Stopwatch();

            UnityPerformanceTest unityPerformanceTest = new UnityPerformanceTest(NumberOfTests);
            MvvmLightPerformanceTest mvvmLightPerformanceTest = new MvvmLightPerformanceTest(NumberOfTests);
            AutofacPerformanceTest autofacPerformanceTest = new AutofacPerformanceTest(NumberOfTests);
            TinyIocPerformanceTest tinyIocPerformanceTest = new TinyIocPerformanceTest(NumberOfTests);

            RunTests(unityPerformanceTest, "Unity");
            RunTests(mvvmLightPerformanceTest, "MvvmLight");
            RunTests(autofacPerformanceTest, "AutoFac");
            RunTests(tinyIocPerformanceTest, "TinyIOC");

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void RunTests(IPerformanceTest performanceTest, string testName)
        {
            try
            {
                Logger.WriteToScreen(testName, ConsoleColor.Cyan);
                Logger.WriteToScreen("---------------------------", ConsoleColor.Cyan);
                Logger.WriteToScreen(String.Format("Starting performance test"), ConsoleColor.Green);               
                                
                StopwatchObj.Start();

                performanceTest.RunRegistrationTests();

                Logger.WriteToScreen(String.Format("IOC Registration Time for {0} tests: {1} ms", NumberOfTests, StopwatchObj.Elapsed.Milliseconds.ToString()));

                StopwatchObj.Restart();

                performanceTest.RunResolveTests();

                Logger.WriteToScreen(String.Format("IOC Resolution Time for {0} tests: {1} ms", NumberOfTests, StopwatchObj.Elapsed.Milliseconds.ToString()));
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                StopwatchObj.Stop();

                Logger.WriteToScreen("Ending performance test\n", ConsoleColor.Red);
            }           
        }       
    }
}
