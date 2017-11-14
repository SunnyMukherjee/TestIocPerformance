using Autofac;
using System;
using TestIocPerformance.Interfaces;
using TestIocPerformance.Models;

namespace TestIocPerformance.Tests
{
    public class AutofacPerformanceTest : IPerformanceTest
    {
        private int _numberOfTests;
        private static ContainerBuilder _builder { get; set; }
        private static IContainer _container { get; set; }

        public AutofacPerformanceTest(int numberOfTests)
        {
            _numberOfTests = numberOfTests;

            _builder = new ContainerBuilder();            
        }

        public void RunRegistrationTests()
        {  
            for (int x = 0; x < _numberOfTests; x++)
            {
                _builder.RegisterType<Test>().As<ITest>().Named<Test>(String.Format("Class{0}", x));
            }

            _container = _builder.Build();
        }

        public void RunResolveTests()
        {
            using (var scope = _container.BeginLifetimeScope())
            {
                for (int x = 0; x < _numberOfTests; x++)
                {
                    scope.ResolveNamed<Test>(String.Format("Class{0}", x));
                }
            }
        }
    }
}
