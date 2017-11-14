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
            for (int x = 0; x < _numberOfTests; x++)
            {
                //_unityContainer.RegisterType<Test>();
                _unityContainer.RegisterType<ITest, Test>(String.Format("Class{0}", x));
            }
        }

        public void RunResolveTests()
        {
            for (int x = 0; x < _numberOfTests; x++)
            {
                _unityContainer.Resolve<ITest>(String.Format("Class{0}", x));
            }            
        }
    }
}
