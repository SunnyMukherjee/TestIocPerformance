using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Models;

namespace TestIocPerformance.Tests
{
    internal class MvvmLightPerformanceTest : IPerformanceTest
    {
        private int _numberOfTests;

        public MvvmLightPerformanceTest(int numberOfTests)
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            _numberOfTests = numberOfTests;
        }

        public void RunRegistrationTests()
        {
            Console.WriteLine("MvvmLight: Running {0} registration tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {                
                SimpleIoc.Default.Register(() => { return new Test();  }, String.Format("Class{0}", x));
            }
        }

        public void RunResolveTests()
        {
            Console.WriteLine("MvvmLight: Running {0} resolution tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {
                SimpleIoc.Default.GetInstance<Test>(String.Format("Class{0}", x));
            }
        }
    }
}
