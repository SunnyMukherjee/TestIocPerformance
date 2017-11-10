using System;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Models;
using Unity;

namespace TestIocPerformance.Tests
{
    internal class UnityPerformanceTest : IPerformanceTest
    {
        private int _numberOfTests;

        private readonly IUnityContainer _unityContainer;

        public UnityPerformanceTest(int numberOfTests)
        {
            _unityContainer = new UnityContainer();
            _numberOfTests = numberOfTests;
        }

        public void RunRegistrationTests()
        {
            Console.WriteLine("Unity: Running {0} registration tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {
                //_unityContainer.RegisterType<Test>();
                _unityContainer.RegisterType<ITest, Test>(String.Format("Class{0}", x));
            }
        }

        public void RunResolveTests()
        {
            Console.WriteLine("Unity: Running {0} resolution tests", _numberOfTests);

            for (int x = 0; x < _numberOfTests; x++)
            {
                _unityContainer.Resolve<ITest>(String.Format("Class{0}", x));
            }            
        }
    }
}
