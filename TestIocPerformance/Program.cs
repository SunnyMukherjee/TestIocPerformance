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

            UnityPerformanceTest unityPerformanceTest = new UnityPerformanceTest(NumberOfTests);
            MvvmLightPerformanceTest mvvmLightPerformanceTest = new MvvmLightPerformanceTest(NumberOfTests);
            AutofacPerformanceTest autofacPerformanceTest = new AutofacPerformanceTest(NumberOfTests);
            TinyIocPerformanceTest tinyIocPerformanceTest = new TinyIocPerformanceTest(NumberOfTests);

            RunTests(unityPerformanceTest);
            RunTests(mvvmLightPerformanceTest);
            RunTests(autofacPerformanceTest);
            RunTests(tinyIocPerformanceTest);

            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        private static void RunTests(IPerformanceTest performanceTest)
        {
            try
            {
                Console.WriteLine("\nStarting performance test");

                StopwatchObj = new Stopwatch();
                StopwatchObj.Start();

                performanceTest.RunRegistrationTests();

                Console.WriteLine("IOC Registration Time: {0} ms", StopwatchObj.Elapsed.Milliseconds.ToString());

                StopwatchObj.Restart();

                performanceTest.RunResolveTests();

                Console.WriteLine("IOC Resolution Time: {0} ms", StopwatchObj.Elapsed.Milliseconds.ToString());
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                StopwatchObj.Stop();
                StopwatchObj = null;

                Console.WriteLine("Ending performance test\n");
            }           
        }       
    }
}
