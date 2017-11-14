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
            for (int x = 0; x < _numberOfTests; x++)
            {                
                SimpleIoc.Default.Register(() => { return new Test();  }, String.Format("Class{0}", x));
            }
        }

        public void RunResolveTests()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                SimpleIoc.Default.GetInstance<Test>(String.Format("Class{0}", x));
            }
        }
    }
}
